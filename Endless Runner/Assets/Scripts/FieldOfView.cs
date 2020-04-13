using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FieldOfView : MonoBehaviour
{
    [Range(0,360)]
    public float viewAngle;
    public float viewRadius;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets;

    private void Start()
    {
        visibleTargets = new List<Transform>();
        StartCoroutine("FindTargetEveryXSeconds", 0.2f);
    }

    IEnumerator FindTargetEveryXSeconds (float x)
    {
        while (true)
        {
            yield return new WaitForSeconds(x);
            GetVisibleTarget();
        }
    }

    public void GetVisibleTarget()
    {
        //Clear for duplicates, everytime it's new analysis of target
        visibleTargets.Clear();
        Collider[] targetInsideSphereRadius = Physics.OverlapSphere(transform.position, viewRadius);

        foreach(Collider targetCollider in targetInsideSphereRadius)
        {
            if (targetCollider.transform == transform)
                continue;

            Transform targetTransform = targetCollider.transform;
            Vector3 targetDirectionComparedSourceView = (targetTransform.position - transform.position).normalized;

            //check if target inside viewRadius
            if (Vector3.Angle(targetDirectionComparedSourceView, transform.right) < viewAngle / 2)
            {
                if(!Physics.Raycast(transform.position, targetDirectionComparedSourceView, Vector3.Distance(transform.position, targetTransform.position), ~targetMask))
                    visibleTargets.Add(targetTransform);
            }
        }
    }
}
