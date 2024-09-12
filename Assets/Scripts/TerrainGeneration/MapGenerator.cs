using JetBrains.Annotations;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth; 
    public int mapHeight;
    public float noiseScale;
    public int octaves;
        [Range(0,1)]
    public float persistance;
    public float lacunarity;

    public bool autoUpdate;

    public float heightMultiplier;

    public int seed;
    public Vector2 offset;
    
    public void GenerateMap() {
        float[,] noiseMap = NoiseGenerator.GenerateNoiseMap(mapWidth,mapHeight,noiseScale,
        octaves,persistance,lacunarity,seed,offset);

        MapDisplay display = GetComponent<MapDisplay>();

        display.DrawNoiseMap(noiseMap);

        display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap,heightMultiplier));
    }

    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    void OnValidate() {
        if(mapWidth < 1) {
            mapWidth = 1;
        }
        
        if(mapHeight < 1) {
            mapHeight = 1;
        }

        if(lacunarity < 1) {
            lacunarity = 1;
        }

        if(octaves < 0) {
            octaves = 0;
        }
    }
}
