using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructZoneBehaviour : MonoBehaviour
{
    //Destruct object leaving game
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            Destroy(other.gameObject);
    }
}
