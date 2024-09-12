using UnityEditor;
using UnityEngine;


public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI() {
        MapGenerator mapGenerator = (MapGenerator)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Generate")) {
            mapGenerator.GenerateMap();
        }
    }
}
