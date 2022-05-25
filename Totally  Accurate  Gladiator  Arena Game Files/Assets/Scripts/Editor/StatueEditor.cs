using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StatueManager))]
public class StatueEditor : Editor
{
    private void OnSceneGUI()
    {
        StatueManager statue = (StatueManager)target; //In edit mode get the selected target with "field of view" script
                                                      //draw the range circle of the selected target
        Handles.color = Color.white;
        Handles.DrawWireArc(statue.transform.position, Vector3.up, Vector3.forward, 360, statue.radius);
    }
}
