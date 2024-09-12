using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilties
{
    public static Bounds GetViewportBounds(Camera camera, Vector3 screenPos1, Vector3 screenPos2)
    {
        Vector3 v1 = Camera.main.ScreenToViewportPoint(screenPos1);
        Vector3 v2 = Camera.main.ScreenToViewportPoint(screenPos2);
        Vector3 min = Vector3.Min(v1,v2);
        Vector3 max = Vector3.Max(v1,v2);
        min.z = camera.nearClipPlane;
        max.z = camera.farClipPlane;

        Bounds bounds = new Bounds();
        bounds.SetMinMax(min,max);
        return bounds;
    }

    public static float Epsilon = 1f;
    public static bool ApproxEqual(float a, float b)
    {
        return(Mathf.Abs(a-b) < Epsilon);
    }

    public static bool ApproxEqual(float a, float b, float mag)
    {
        return(Mathf.Abs(a-b) < Epsilon * mag);
    }

    public static float AngleDifrenceNegatives(float a, float b)
    {
        float dif = b-a;
        if(dif > 180)
            return dif - 360f;
        else if(dif < -180)
            return dif + 360f;
        return dif;
    }
    
    public static float ConvertTo360(float a)
    {
        while(a>360)
            a -= 360f;
        while(a<0)
            a += 360f;
        return a;
    }

    public static Rect GetScreenRect(Vector3 screenPos1, Vector3 screenPos2)
    {
        screenPos1.y = Screen.height - screenPos1.y;
        screenPos2.y = Screen.height - screenPos2.y;

        Vector3 topLeft = Vector3.Min(screenPos1,screenPos2);
        Vector3 bottomRight = Vector3.Max(screenPos1,screenPos2);

        return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
    }
    static Texture2D _whiteTexture;
    public static Texture2D WhiteTexture
    {
        get
        {
            if(_whiteTexture == null)
            {
                _whiteTexture = new Texture2D(1,1);
                _whiteTexture.SetPixel(0,0,Color.white);
                _whiteTexture.Apply();
            }
            return _whiteTexture;
        }
    }

    public static void DrawScreenRect(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.DrawTexture(rect, WhiteTexture);
        GUI.color = Color.white;
    }

    public static void DrawScreenBorder(Rect rect, float thickness, Color color)
    {
        //Top
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
        //Left
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
        //Right
        DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
        //Bottom
        DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
    }

    //Taken from here: https://discussions.unity.com/t/finding-shortest-line-segment-between-two-rays-closest-point-of-approach/32614
    public static float ClosestTimeOfApproach(Vector3 pos1, Vector3 vel1, Vector3 pos2, Vector3 vel2)
    {
        //float t = 0;
        var dv = vel1 - vel2;
        var dv2 = Vector3.Dot(dv, dv);
        if (dv2 < 0.0000001f)      // the tracks are almost parallel
        {
            return 0.0f; // any time is ok.  Use time 0.
        }
        
        var w0 = pos1 - pos2;
        return (-Vector3.Dot(w0, dv)/dv2);
    }

    public static float ClosestDistOfApproach(Vector3 pos1, Vector3 vel1, Vector3 pos2, Vector3 vel2)
    {
        Vector3 p1, p2;
        var t = ClosestTimeOfApproach(pos1,vel1,pos2,vel2);
        p1 = pos1 + (t * vel1);
        p2 = pos2 + (t*vel2);

        return Vector3.Distance(p1, p2);           // distance at CPA
    }

    public static Vector3 ClosestPointOfApproach(Vector3 pos1, Vector3 vel1, Vector3 pos2, Vector3 vel2)
    {
        var t = ClosestTimeOfApproach(pos1, vel1, pos2, vel2);
        if (t<0) // don't detect approach points in the past, only in the future;
        {
            return (pos1); 
        }

        return (pos1 + (t * vel1));
        
    }
}
