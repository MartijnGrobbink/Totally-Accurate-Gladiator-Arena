using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AIData))]
public class SeenObjectEditor : Editor
{
    private void OnSceneGUI()
    {
        AIData data = (AIData)target;

        //if the target can see the player draw a green line from the target to the player
        if (data.ally.Count != 0)
        {

            for (int i = 0; i < data.ally.Count; i++)
            {
                Handles.color = Color.green;
                Handles.DrawLine(data.transform.position, data.ally[i].transform.position);
            }
        }
        if (data.weapons.Count != 0)
        {

            for (int i = 0; i < data.weapons.Count; i++)
            {
                Handles.color = Color.cyan;
                Handles.DrawLine(data.transform.position, data.weapons[i].transform.position);
            }
        }
        if (data.enemies.Count != 0)
        {

            for (int i = 0; i < data.enemies.Count; i++)
            {
                Handles.color = Color.red;
                Handles.DrawLine(data.transform.position, data.enemies[i].transform.position);
            }
        }
    }
}
