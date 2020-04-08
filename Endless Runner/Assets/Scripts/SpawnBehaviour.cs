using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObject[] ennemies;

    public int deltaTimeWave;
    public float deltaTimeRangeMax, deltaTimeRangeMin;
    private int _deltaTimeWave;

    public bool spawnEnable;

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

            if(spawnEnable)
                CreateNewObstacle();
        }
        _deltaTimeWave -= Mathf.RoundToInt(Random.Range(deltaTimeRangeMin, deltaTimeRangeMax));
    }

    public void CreateNewObstacle(){

        int scheme = Mathf.RoundToInt(Random.Range(0,5));

        int ennemy1 = Mathf.RoundToInt(Random.Range(0, ennemies.Length));
        int ennemy2 = Mathf.RoundToInt(Random.Range(0, ennemies.Length));

        switch (scheme) {
            case 0:
                Instantiate(ennemies[ennemy1], transform.position, new Quaternion()); break;
            case 1:
                Instantiate(ennemies[ennemy1], transform.position+Vector3.up*transX, new Quaternion()); break;
            case 2:
                Instantiate(ennemies[ennemy1], transform.position + Vector3.down * transX, new Quaternion()); break;
            case 3:
                Instantiate(ennemies[ennemy1], transform.position, new Quaternion());
                Instantiate(ennemies[ennemy2], transform.position + Vector3.up * transX, new Quaternion()); break;
            case 4:
                Instantiate(ennemies[ennemy1], transform.position, new Quaternion()); 
                Instantiate(ennemies[ennemy2], transform.position + Vector3.down * transX, new Quaternion()); break;
            case 5:
                Instantiate(ennemies[ennemy1], transform.position + Vector3.down * transX, new Quaternion());
                Instantiate(ennemies[ennemy2], transform.position + Vector3.up * transX, new Quaternion()); break;
            default:
                Instantiate(ennemies[ennemy1], transform.position, new Quaternion()); break;

        };
    }
}
