using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class spawnManager : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI startGameText;
    public GameObject[] obsticlePrefab;
    public GameObject collectablePrefab;

    float waitTime = 2;
    private float repeat = 1;
    private int lastResult;

    private int score = 0;
    public TextMeshProUGUI scoreText;
    IEnumerator ss;


    // Start is called before the first frame update


    void Start()
    {

      


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to be called when you want to apply slowdown
  public void slowDownTime() { 
            StopCoroutine(ss);
       
    }

    public void ResetSpawnRate()
    {
        ss = SpawnObstaclesroutine();
        StartCoroutine(ss);

    }

    // Function to be called when you want to reset the spawn rate




    private IEnumerator SpawnObstaclesroutine(){
        playerDamage manager = FindObjectOfType<playerDamage>();
        while (manager.isGameActive == true)
        {
            //while the power mup is on spawn obsticles
            playerSkills ps = FindObjectOfType<playerSkills>();
            if (ps.powerupIzanagi == false)
            {
                spawnObs();
            }
            yield return new WaitForSeconds(repeat);
        }
    }



    // to spawn in obsticles and power ups
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
            else if (prefabIndex >= 30 && prefabIndex < 60)
            {
                Instantiate(obsticlePrefab[0], spawnPositionTree, obsticlePrefab[0].transform.rotation);

            }
            else if (prefabIndex >= 60 && prefabIndex < 90)
            {
                Instantiate(obsticlePrefab[2], spawnPositionLog, obsticlePrefab[2].transform.rotation);

            }

            //10% chance for power up to spa
            else if (prefabIndex >= 90 && prefabIndex < 95)

            {
                Instantiate(obsticlePrefab[3], spawnPositionKuni, obsticlePrefab[3].transform.rotation);
                // Instantiate(obsticlePrefab[prefabIndex], spawnPositionLog, obsticlePrefab[prefabIndex].transform.rotation);
            }
            else if (prefabIndex >= 95)
            {
                Instantiate(obsticlePrefab[4], spawnPositionKuni, obsticlePrefab[4].transform.rotation);
            }

        }
    



    // to spawn in collactables
 

    IEnumerator SpawnColRoutine()
    {
        playerDamage manager = FindObjectOfType<playerDamage>();
        while (manager.isGameActive == true)
        {
            int result;
            int index = Random.Range(0, 3);
             
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

            for (int i = 0; i < 3; i++)
            {
                // Increment the Z-axis position for each coin
                float spawnZ = 50 + i * 2; // Adjust the value as needed

                Vector3 spawnPositionCoin = new Vector3(result, 1, spawnZ);
                Instantiate(collectablePrefab, spawnPositionCoin, collectablePrefab.transform.rotation);
            }

            // Wait for 2 seconds before spawning the next set
            yield return new WaitForSeconds(2f);
        }
    }

    // keeping track of socre for collectables 

    public void UpdateScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        scoreText.text = "Score: " + score;
       playerSkills ps = FindObjectOfType<playerSkills>();

        if (score % 20 == 0 && score > 0 && ps.powerupIzanagi == false)
        {
            IncreaseDifficulty();
        }


    }

    private void IncreaseDifficulty()
    {
        waitTime -= 0.1f; 
                        

        // Restart the obstacle spawning routine with the updated difficulty
        ResetSpawnRate();
    }

    public void StartGame()
    {
      //  NewBehaviourScript PM = FindObjectOfType<NewBehaviourScript>();
        playerDamage pd = FindObjectOfType<playerDamage>();
        pd.isGameActive = true;
        startGameText.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
       // PM.playerRb = GetComponent<Rigidbody>();
        StartCoroutine(SpawnColRoutine());
        ss = SpawnObstaclesroutine();
        StartCoroutine(ss);
        UpdateScore(score);
    }

}
