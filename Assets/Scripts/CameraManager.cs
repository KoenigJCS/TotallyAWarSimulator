using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager inst;
    private void Awake() {
        inst = this;
    }

    void Start() 
    {
        
    }

    [Header("Nodes")]
    public GameObject RTSCamera;
    public GameObject YawNode; //Child of ^
    public GameObject PitchNode; //Child of ^
    public GameObject RollNode; //Child of ^
    [Header("Calibration")]
    public float cameraSenitiivity = 100;
    public float turnRate = 50;
    
    public Vector3 currentPitchEulerAngles= Vector3.zero;
    public Vector3 currentYawEulerAngles= Vector3.zero;
    // public bool isRTSMode = true;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse2))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(Input.GetKeyUp(KeyCode.Mouse2))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        float moveCoefficent = Time.deltaTime * cameraSenitiivity * YawNode.transform.position.y;
        moveCoefficent = Mathf.Clamp(moveCoefficent, 0.0001f, 999f);

        if(!Input.GetKey(KeyCode.Mouse2)) 
        {
            
            if(Input.GetKey(KeyCode.UpArrow))
            {
                YawNode.transform.Translate(Vector3.forward * moveCoefficent);
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                YawNode.transform.Translate(Vector3.back * moveCoefficent);
            }

            if(Input.GetKey(KeyCode.LeftArrow))
            {
                YawNode.transform.Translate(Vector3.left * moveCoefficent);
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                YawNode.transform.Translate(Vector3.right * moveCoefficent);
            }

            if(Input.GetKey(KeyCode.KeypadPlus))
            {
                YawNode.transform.Translate(Vector3.up * moveCoefficent);
            }
            if(Input.GetKey(KeyCode.KeypadMinus))
            {
                YawNode.transform.Translate(Vector3.down * moveCoefficent);
            }

            // currentPitchEulerAngles = PitchNode.transform.localEulerAngles;
            // if(Input.GetKey(KeyCode.Z))
            // {
            //     currentPitchEulerAngles.x -= turnRate * Time.deltaTime;
            // }
            // if(Input.GetKey(KeyCode.X))
            // {
            //     currentPitchEulerAngles.x += turnRate * Time.deltaTime;
            // }
        } 
        else 
        {
            Vector3 mouseDelta = Input.mousePositionDelta;

            YawNode.transform.Translate(moveCoefficent * new Vector3(mouseDelta.x,0,mouseDelta.y));
        }

        YawNode.transform.Translate(-2f * moveCoefficent * Input.mouseScrollDelta );

        float newY = Mathf.Clamp(YawNode.transform.position.y,20f,900f);
        
        YawNode.transform.position = new(YawNode.transform.position.x,newY,YawNode.transform.position.z);
    }
}

