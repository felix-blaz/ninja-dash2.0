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
        int prefabIndex = Random.Range(0, 4);
        int index = Random.Range(0, 8);

        int result;
        if (index <3)
        {
            result = -4;    // 1 of 3 chance
        }
        else if(index <6) 
        {
            result = 4;     // 1 of 3 chance
        }
        else
        {
            result = 0;     // 1 of 3 chance
        }



       // int[] possibleV = new int[] { -4, 0, 4 };
       // int randPosx = possibleV[index];

        Vector3 spawnPosition = new Vector3(result, 1, 50);
        Vector3 spawnPositionFire = new Vector3(result, 3, 50);
        Vector3 spawnPositionKuni = new Vector3(result, 1, 50);
        Vector3 spawnPositionTree = new Vector3(result, -1, 50);

        if (prefabIndex == 1)
        {
            Instantiate(obsticlePrefab[1], spawnPositionFire, obsticlePrefab[1].transform.rotation);
        }
        else if(prefabIndex == 0)
        {
            Instantiate(obsticlePrefab[0], spawnPositionTree, obsticlePrefab[0].transform.rotation);

        }
        else if (prefabIndex == 3)
        {
            Instantiate(obsticlePrefab[3], spawnPositionKuni, obsticlePrefab[3].transform.rotation);

        }

        else
        {
            Instantiate(obsticlePrefab[prefabIndex], spawnPosition, obsticlePrefab[prefabIndex].transform.rotation);
        }
    }
}
