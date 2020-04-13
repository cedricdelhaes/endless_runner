using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float hSpeed;

    public float separationRadius, alignmentRadius, cohesionRadius;

    FieldOfView fow;
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        fow = GetComponent<FieldOfView>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.AddForce(-hSpeed, 0, 0,ForceMode.VelocityChange);

        foreach(Transform neigbour in fow.visibleTargets)
        {
            if (neigbour == null)
                continue;
            if(Vector3.Distance(neigbour.position,transform.position) <= separationRadius) {
                Vector3 separationForce = neigbour.position - transform.position;
                rigidBody.AddForce(-separationForce.x, -separationForce.y, 0, ForceMode.VelocityChange);
            } else if (Vector3.Distance(neigbour.position, transform.position) <= alignmentRadius)
            {
                Vector3 alignmentForce = neigbour.eulerAngles - transform.eulerAngles;
                transform.Rotate(alignmentForce);
            } else if (Vector3.Distance(neigbour.position, transform.position) <= cohesionRadius)
            {
                Vector3 separationForce = neigbour.position - transform.position;
                rigidBody.AddForce(separationForce.x, separationForce.y, 0, ForceMode.VelocityChange);
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 1);
    }
}