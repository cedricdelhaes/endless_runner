using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fow = (FieldOfView)target;

        Handles.color = Color.green;
        Handles.DrawWireArc(fow.transform.position, fow.transform.forward, fow.transform.right, fow.viewAngle / 2, fow.viewRadius);
        Handles.DrawWireArc(fow.transform.position, fow.transform.forward, fow.transform.right, -fow.viewAngle / 2, fow.viewRadius);

        //Calculate point on circle at angle to trace line (euler to take in account object rotation view line lik)
        float x1 = fow.viewRadius * Mathf.Cos((fow.viewAngle * Mathf.Deg2Rad)/2 + fow.transform.eulerAngles.z * Mathf.Deg2Rad) + fow.transform.position.x ;
        float y1 = fow.viewRadius * Mathf.Sin((fow.viewAngle * Mathf.Deg2Rad)/2 + fow.transform.eulerAngles.z * Mathf.Deg2Rad) + fow.transform.position.y;

        float x2 = fow.viewRadius * Mathf.Cos((-fow.viewAngle * Mathf.Deg2Rad) / 2 + fow.transform.eulerAngles.z * Mathf.Deg2Rad) + fow.transform.position.x;
        float y2 = fow.viewRadius * Mathf.Sin((-fow.viewAngle * Mathf.Deg2Rad) / 2 + fow.transform.eulerAngles.z * Mathf.Deg2Rad) + fow.transform.position.y;

        Handles.DrawLine(fow.transform.position, new Vector3(x1,y1, 0));
        Handles.DrawLine(fow.transform.position, new Vector3(x2, y2, 0));

    }
}
