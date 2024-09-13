using JetBrains.Annotations;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public const int mapChunkSize =241; 
    public float mapScale;
    [Range(0,6)]
    public int levelOfDetail;
    public float noiseScale;
    public int octaves;
        [Range(0,1)]
    public float persistance;
    public float lacunarity;

    public bool autoUpdate;

    public float heightMultiplier;
    public AnimationCurve meshHeightCurve;

    public int seed;
    public Vector2 offset;
    MapDisplay display;
    public MeshFilter mapMeshFilter;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        display = GetComponent<MapDisplay>();
        GenerateMap();
    }
    
    public void GenerateMap() {
        float[,] noiseMap = NoiseGenerator.GenerateNoiseMap(mapChunkSize,mapChunkSize,noiseScale,
        octaves,persistance,lacunarity,seed,offset);

        display.DrawNoiseMap(noiseMap);
        PaintingManger.inst.SetCurrentMap(noiseMap);

        display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap,heightMultiplier,meshHeightCurve,levelOfDetail,mapScale),mapMeshFilter);
    }

    public void GenerateMapFromArray(float [,] newMap) {
        display.DrawMesh(MeshGenerator.GenerateTerrainMesh(newMap,heightMultiplier,meshHeightCurve,levelOfDetail,mapScale),mapMeshFilter);
    }

    public void GeneratePaintMapFromArray(float [,] newMap,MeshFilter targetMesh) {
        display.DrawMesh(MeshGenerator.GenerateTerrainMesh(newMap,heightMultiplier,meshHeightCurve,0,mapScale),targetMesh);
    }
    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    void OnValidate() {
        display = GetComponent<MapDisplay>();
        if(lacunarity < 1) {
            lacunarity = 1;
        }

        if(octaves < 0) {
            octaves = 0;
        }
    }
}
