using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BackgroundGenerator))]
public class BackgroundGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BackgroundGenerator backgroundGenerator = (BackgroundGenerator)target;

        GUILayout.Label("Timing", EditorStyles.boldLabel);
        GUILayout.Label("Timer for Change: " + backgroundGenerator.timerForChange);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Minimum: ");
        backgroundGenerator.leastTimeToChange = EditorGUILayout.IntField(backgroundGenerator.leastTimeToChange);
        GUILayout.Label("Maximum: ");
        backgroundGenerator.mostTimeToChange = EditorGUILayout.IntField(backgroundGenerator.mostTimeToChange);

        GUILayout.EndHorizontal();

        GUILayout.Space(5);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Offsets", EditorStyles.boldLabel);
        GUILayout.Label("X: " + backgroundGenerator.offsetX);
        GUILayout.Label("Y: " + backgroundGenerator.offsetY);
        
        GUILayout.EndHorizontal();

        GUILayout.Space(5);
        
        GUILayout.Label("Speeds", EditorStyles.boldLabel);
        GUILayout.Label("Background Speed: " + backgroundGenerator.backgroundSpeed);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Minimum: ");
        backgroundGenerator.backgroundSpeedMin = EditorGUILayout.FloatField(backgroundGenerator.backgroundSpeedMin);
        GUILayout.Label("Maximum: ");
        backgroundGenerator.backgroundSpeedMax = EditorGUILayout.FloatField(backgroundGenerator.backgroundSpeedMax);

        GUILayout.EndHorizontal();

        GUILayout.Space(5);

        GUILayout.Label("Background Size", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();

        GUILayout.Label("Width: ");
        backgroundGenerator.width = EditorGUILayout.IntField(backgroundGenerator.width);
        GUILayout.Label("Height: ");
        backgroundGenerator.height = EditorGUILayout.IntField(backgroundGenerator.height);

        GUILayout.EndHorizontal();

    }
}