using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
   
    public GameObject[] obsticlePrefab;
   
    private float startDelay = 1;
    private float repeat = 1;

    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("spawnObs", startDelay, repeat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnObs()
    {
        int index = Random.Range(0, 3);
        int[] possibleV = new int[] { -3, 0, 3 };
        int randPosx = possibleV[index];

        Vector3 spawnPosition = new Vector3(randPosx, 1, 50);
        Vector3 spawnPositionFire = new Vector3(randPosx, 4, 50);

        if (index == 1)
        {
            Instantiate(obsticlePrefab[1], spawnPositionFire, obsticlePrefab[1].transform.rotation);
        }
        else
        {
            Instantiate(obsticlePrefab[index], spawnPosition, obsticlePrefab[index].transform.rotation);
        }
    }
}
