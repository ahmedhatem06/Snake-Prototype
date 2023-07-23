using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using TheSnake;

[ExecuteInEditMode]
[CustomEditor(typeof(SnakeBodyParts))]
public class MyCustomScriptEditor_SnakeBodyParts : Editor
{
    private List<SerializedProperty> properties;

    private void OnEnable()
    {
        string[] hiddenProperties = new string[] { "bodyPrefab" }; //fields you do not want to show go here
        properties = EditorHelper.GetExposedProperties(serializedObject, hiddenProperties);
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI(); - (standard way to draw base inspector)

        //We draw only the properties we want to display here
        foreach (SerializedProperty property in properties)
        {
            EditorGUILayout.PropertyField(property, true);
        }
        serializedObject.ApplyModifiedProperties();
    }
}

[ExecuteInEditMode]
[CustomEditor(typeof(SnakeMaterialChanger))]
public class MyCustomScriptEditor_SnakeMaterialChanger : Editor
{
    private List<SerializedProperty> properties;

    private void OnEnable()
    {
        string[] hiddenProperties = new string[] { "bodyPrefab" }; //fields you do not want to show go here
        properties = EditorHelper.GetExposedProperties(serializedObject, hiddenProperties);
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI(); - (standard way to draw base inspector)

        //We draw only the properties we want to display here
        foreach (SerializedProperty property in properties)
        {
            EditorGUILayout.PropertyField(property, true);
        }
        serializedObject.ApplyModifiedProperties();
    }
}

[ExecuteInEditMode]
[CustomEditor(typeof(SnakeMovement))]
public class MyCustomScriptEditor_SnakeMovement : Editor
{
    private List<SerializedProperty> properties;

    private void OnEnable()
    {
        string[] hiddenProperties = new string[] { "bodyPrefab" }; //fields you do not want to show go here
        properties = EditorHelper.GetExposedProperties(serializedObject, hiddenProperties);
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI(); - (standard way to draw base inspector)

        //We draw only the properties we want to display here
        foreach (SerializedProperty property in properties)
        {
            EditorGUILayout.PropertyField(property, true);
        }
        serializedObject.ApplyModifiedProperties();
    }
}

[ExecuteInEditMode]
[CustomEditor(typeof(SnakeRotator))]
public class MyCustomScriptEditor_SnakeRotator : Editor
{
    private List<SerializedProperty> properties;

    private void OnEnable()
    {
        string[] hiddenProperties = new string[] { "bodyPrefab" }; //fields you do not want to show go here
        properties = EditorHelper.GetExposedProperties(serializedObject, hiddenProperties);
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI(); - (standard way to draw base inspector)

        //We draw only the properties we want to display here
        foreach (SerializedProperty property in properties)
        {
            EditorGUILayout.PropertyField(property, true);
        }
        serializedObject.ApplyModifiedProperties();
    }
}