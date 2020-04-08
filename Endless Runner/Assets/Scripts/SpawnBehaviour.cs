using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObject ennemi;

    public int deltaTimeWave;
    public float deltaTimeRangeMax, deltaTimeRangeMin;
    private int _deltaTimeWave;

    public int transX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_deltaTimeWave <= 0) {
            _deltaTimeWave = deltaTimeWave;
            CreateNewObstacle();
        }
        _deltaTimeWave -= Mathf.RoundToInt(Random.Range(deltaTimeRangeMin, deltaTimeRangeMax));
    }

    public void CreateNewObstacle(){

        int scheme = Mathf.RoundToInt(Random.Range(0,5));

        switch (scheme){
            case 0:
                Instantiate(ennemi, transform.position, new Quaternion()); break;
            case 1:
                Instantiate(ennemi, transform.position+Vector3.up*transX, new Quaternion()); break;
            case 2:
                Instantiate(ennemi, transform.position + Vector3.down * transX, new Quaternion()); break;
            case 3:
                Instantiate(ennemi, transform.position, new Quaternion());
                Instantiate(ennemi, transform.position + Vector3.forward * transX, new Quaternion()); break; break;
            case 4:
                Instantiate(ennemi, transform.position, new Quaternion()); 
                Instantiate(ennemi, transform.position + Vector3.down * transX, new Quaternion()); break;
            case 5:
                Instantiate(ennemi, transform.position + Vector3.down * transX, new Quaternion());
                Instantiate(ennemi, transform.position + Vector3.forward * transX, new Quaternion()); break;
            default:
                Instantiate(ennemi, transform.position, new Quaternion()); break;

        };
    }
}
