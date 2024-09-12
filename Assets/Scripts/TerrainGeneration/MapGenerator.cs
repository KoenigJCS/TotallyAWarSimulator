using JetBrains.Annotations;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth; 
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    public float persistance;
    public float lacunarity;

    public bool autoUpdate;
    
    public void GenerateMap() {
        float[,] noiseMap = NoiseGenerator.GenerateNoiseMap(mapWidth,mapHeight,noiseScale,
        octaves,persistance,lacunarity);

        MapDisplay display = GetComponent<MapDisplay>();

        display.DrawNoiseMap(noiseMap);
    }
}
