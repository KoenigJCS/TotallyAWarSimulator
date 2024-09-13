using System;
using System.Linq.Expressions;
using UnityEngine;

public class PaintingManger : MonoBehaviour
{
    public static PaintingManger inst;
    float[,] currentMap;
    [SerializeField] MapGenerator mapGenerator;
    [SerializeField] GameObject mapPlane;
    [SerializeField] GameObject paintingPlane;
    public int brushSize;

    Vector3 flat = new(1,0,1);

    public void SetCurrentMap(float[,] newMap)
    {
        currentMap=newMap;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            int size = currentMap.GetLength(0);
            for(int y=0; y<size;y++) 
            {
                for(int x=0; x<size;x++) 
                {
                    currentMap[x,y] += 1f* Time.deltaTime;
                }
            }
        }

        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            LayerMask layers = ~((1<<5) | (1<<4) | (1<<3) );
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2000, layers))
            {   //Only Works with square maps atm
                
                float worldSpaceScale = mapGenerator.mapScale*(MapGenerator.mapChunkSize-1);
                
                paintingPlane.transform.position = new(hit.point.x,10,hit.point.z);
                
                Vector3 mapCordsOrigin = mapPlane.transform.position-(MapGenerator.mapChunkSize*worldSpaceScale*.5f*Vector3.one);
                Vector3 flatDelta = Vector3.Scale(hit.point,flat) - Vector3.Scale(mapCordsOrigin,flat);
                float [,] paintMap = new float[(brushSize*2),(brushSize*2)];
                

                int size = currentMap.GetLength(0);
                Vector2Int topRight = new((int)(flatDelta.x/worldSpaceScale)+brushSize,MapGenerator.mapChunkSize-(((int)(flatDelta.z/worldSpaceScale))-brushSize));
                Vector2Int bottomLeft = new((int)(flatDelta.x/worldSpaceScale)-brushSize,MapGenerator.mapChunkSize-(((int)(flatDelta.z/worldSpaceScale))+brushSize));
                int i=0,j=0;
                // Debug.Log(topRight);
                // Debug.Log(bottomLeft);
                // Debug.Log(size);
                for(int y=bottomLeft.y; y<topRight.y;y++) 
                {
                    i=0;
                    for(int x=bottomLeft.x; x<topRight.x;x++) 
                    {
                        if(x>=0 && y>=0 && x<size && y<=size) {
                            paintMap[i,j] = currentMap[x,y];
                        } else {
                            paintMap[i,j]=0f;
                        }
                        i++;
                    }
                    j++;
                }
                // Debug.Log(paintMap);
                mapGenerator.GeneratePaintMapFromArray(paintMap, paintingPlane.GetComponent<MeshFilter>());
            }
        }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        inst=this;
    }
}
