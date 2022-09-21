using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// referance : https://answers.unity.com/questions/1414634/can-i-add-an-enum-value-in-the-inspector.html
/// </summary>
[CustomEditor(typeof(PoolNamesEditor))]
public class EnumWriter : Editor
{
    PoolNamesEditor myScrip;
    string filePath = "Assets/Scripts/Pooling/Enums/";
    string fileName = "PoolNames";

    private void OnEnable()
    {
        myScrip = (PoolNamesEditor)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        filePath = EditorGUILayout.TextField("Path", filePath);
        fileName = EditorGUILayout.TextField("Name", fileName);
        if (GUILayout.Button("Save"))
        {
            EditorMetods.WriteToEnum(filePath, fileName, myScrip.poolnames);
        }
    }
}
