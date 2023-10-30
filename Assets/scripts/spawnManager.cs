using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject obsticlePrefab;
    private Vector3 spawnPosition = new Vector3(0, 1, 50);
    private float startDelay = 1;
    private float repeat = 2;

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
        Instantiate(obsticlePrefab, spawnPosition, obsticlePrefab.transform.rotation);
    }
}
