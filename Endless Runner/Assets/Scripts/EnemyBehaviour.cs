using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float hSpeed;

    public float separationRadius, alignmentRadius, cohesionRadius;

    private GameObject player;

    FieldOfView fow;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        fow = GetComponent<FieldOfView>();
        rigidBody = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //rigidBody.AddForce(new Vector2(hSpeed, 0));
        transform.Translate(hSpeed * Time.deltaTime, 0,0);
        //BoidsBehaviour();
    }

    private void BoidsBehaviour()
    {
        Vector2 boidForce = new Vector2();
        Vector2 boidTorque = new Vector2();

        foreach (Transform neigbour in fow.visibleTargets)
        {
            if (neigbour == null && gameObject.tag != neigbour.tag)
                continue;

            float dist = Vector3.Distance(neigbour.position, transform.position);
            if (dist <= separationRadius)
            {
                Vector3 separationForce = neigbour.position - transform.position;
                //rigidBody.AddForce(- 1/dist * separationForce.x, - 1/dist * separationForce.y, 0, ForceMode.Impulse);
                boidForce += new Vector2(-1 / dist * separationForce.x, -1 / dist * separationForce.y);
            }
            else if (dist <= alignmentRadius)
            {
                Vector2 alignmentForce = neigbour.eulerAngles - transform.eulerAngles;
                //transform.Rotate(alignmentForce);
                //rigidBody.AddTorque(alignmentForce, ForceMode.Impulse);
                boidTorque += alignmentForce;
            }
            else if (dist <= cohesionRadius)
            {
                Vector3 separationForce = neigbour.position - transform.position;
                //rigidBody.AddForce(1/dist * separationForce.x, 1/dist * separationForce.y, 0, ForceMode.VelocityChange);
                boidForce += new Vector2(1 / dist * separationForce.x, 1 / dist * separationForce.y);
            }
        }

        rigidBody.AddForce(boidForce);
        rigidBody.AddTorque(boidTorque.x);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 1);
       ;
    }
}