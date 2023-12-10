using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
   
    public GameObject[] obsticlePrefab;
   
    private float startDelay = 1;
    private float repeat = 1;
    private int lastResult;
    private bool spawnRateChanged = false;

    // Start is called before the first frame update


    void Start()
    {
        
        InvokeRepeating("spawnObs", startDelay, repeat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to be called when you want to apply slowdown
    public void slowDownTime()
    {
        if (spawnRateChanged == false)
        {
            CancelInvoke("spawnObs");
            spawnRateChanged = true;
            InvokeRepeating("spawnObs", startDelay, 3); // Start repeating with the new rate
        }
    }

    // Function to be called when you want to reset the spawn rate
    public void ResetSpawnRate()
    {
        if (spawnRateChanged ==true )
        {
           CancelInvoke("spawnObs");
            InvokeRepeating("spawnObs", startDelay, repeat);
            spawnRateChanged = false;
        }
       
    }



    public void spawnObs()
    {
        int prefabIndex = Random.Range(0, 100);
        int index = Random.Range(0, 3);

        // spawn location on the x axixs
        int result;
        while (true)
        {
            index = Random.Range(0, 3);

            if (index == 0)
            {
                result = -4;
            }
            else if (index == 1)
            {
                result = 4;
            }
            else
            {
                result = 0;
            }

            if (result != lastResult)
                break;
        }

        lastResult = result;


        // int[] possibleV = new int[] { -4, 0, 4 };
        // int randPosx = possibleV[index];

        Vector3 spawnPositionLog = new Vector3(result, 1, 50);
        Vector3 spawnPositionFire = new Vector3(result, 3, 50);
        Vector3 spawnPositionKuni = new Vector3(result, 1, 50);
        Vector3 spawnPositionTree = new Vector3(result, -1, 50);
        Vector3 spawnPositionIzanagi = new Vector3(result, -1, 50);

        if (prefabIndex <= 29)
        {
            Instantiate(obsticlePrefab[1], spawnPositionFire, obsticlePrefab[1].transform.rotation);
        }
        else if(prefabIndex >= 30 && prefabIndex <60)
        {
            Instantiate(obsticlePrefab[0], spawnPositionTree, obsticlePrefab[0].transform.rotation);

        }
        else if (prefabIndex >= 60 && prefabIndex < 90)
        {
            Instantiate(obsticlePrefab[2], spawnPositionLog, obsticlePrefab[2].transform.rotation);

        }

        //10% chance for power up to spa
        else if(prefabIndex >= 90 && prefabIndex <95)
           
        {
            Instantiate(obsticlePrefab[3], spawnPositionKuni, obsticlePrefab[3].transform.rotation);
            // Instantiate(obsticlePrefab[prefabIndex], spawnPositionLog, obsticlePrefab[prefabIndex].transform.rotation);
        }
        else if (prefabIndex >= 95)
        {
            Instantiate(obsticlePrefab[4], spawnPositionKuni, obsticlePrefab[4].transform.rotation);
        }
    }




}
