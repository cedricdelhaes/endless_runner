using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObject[] ennemies;
    public GameObject ennemieOnArea;

    public Area area;

    public int startTimeDelay;
    public float deltaTimeRangeMax, deltaTimeRangeMin;
    public float repeatRateDecreaseSpawnTimer;

    public bool spawnEnable;

    public int transX;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateNewEnemy", startTimeDelay);
        InvokeRepeating("DecreaseSpawnTimer", 0.5f, repeatRateDecreaseSpawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DecreaseSpawnTimer()
    {
        if (spawnEnable)
        {
            deltaTimeRangeMax = deltaTimeRangeMax - 0.1f < 0.1 ? deltaTimeRangeMax : deltaTimeRangeMax - 0.1f;
            deltaTimeRangeMin = deltaTimeRangeMin - 0.1f < 0.1 ? deltaTimeRangeMin : deltaTimeRangeMin - 0.1f;
        }
    }

    private void CreateNewEnemy(){

        if (spawnEnable)
        {
            int scheme = Mathf.RoundToInt(Random.Range(0, 5));

            int ennemy1 = Mathf.RoundToInt(Random.Range(0, ennemies.Length));
            int ennemy2 = Mathf.RoundToInt(Random.Range(0, ennemies.Length));

            float randPositionY = Random.Range((-area.y / 2 + ennemies[ennemy1].GetComponent<Collider2D>().bounds.size.y / 2), (area.y / 2 - ennemies[ennemy1].GetComponent<Collider2D>().bounds.size.y / 2));

            switch (scheme)
            {
                case 0:
                    Instantiate(ennemies[ennemy1], transform.position, new Quaternion(0, 0, 90, 0), ennemieOnArea.transform); break;
                case 1:
                    Instantiate(ennemies[ennemy1], transform.position + Vector3.up * randPositionY, new Quaternion(0, 0, 90, 0), ennemieOnArea.transform); break;
                case 2:
                    Instantiate(ennemies[ennemy1], transform.position + Vector3.down * randPositionY, new Quaternion(0, 0, 90, 0), ennemieOnArea.transform); break;
                case 3:
                    Instantiate(ennemies[ennemy1], transform.position, new Quaternion(0, 0, 90, 0), ennemieOnArea.transform);
                    Instantiate(ennemies[ennemy2], transform.position + Vector3.up * randPositionY, new Quaternion(0, 0, 90, 0), ennemieOnArea.transform); break;
                case 4:
                    Instantiate(ennemies[ennemy1], transform.position, new Quaternion(0, 0, 90, 0), ennemieOnArea.transform);
                    Instantiate(ennemies[ennemy2], transform.position + Vector3.down * randPositionY, new Quaternion(0, 0, 90, 0), ennemieOnArea.transform); break;
                case 5:
                    Instantiate(ennemies[ennemy1], transform.position + Vector3.down * randPositionY, new Quaternion(0, 0, 90, 0), ennemieOnArea.transform);
                    Instantiate(ennemies[ennemy2], transform.position + Vector3.up * randPositionY, new Quaternion(0, 0, 90, 0), ennemieOnArea.transform); break;
                default:
                    Instantiate(ennemies[ennemy1], transform.position, new Quaternion(0, 0, 90, 0), ennemieOnArea.transform); break;

            };
        }

        Invoke("CreateNewEnemy", Random.Range(deltaTimeRangeMin, deltaTimeRangeMax));
    }
}
