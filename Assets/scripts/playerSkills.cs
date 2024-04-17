using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playerSkills : MonoBehaviour
{
    private float tapT;
    private float doubleT = 0.4f;
    public bool powerupOn = false;
    public bool powerupIzanagi = false;
    public bool gotCoin = false;
    public GameObject kuniPrefab;
    private bool hasResetSpawnRate = false;
    int num = 1;
    public GameObject kuniIndecator;
    public GameObject izanagiIndecator;
    private Vector3 izaPos = new Vector3(0.3f, 1.3f, 0);
    private Vector3 kuniPos = new Vector3(0, 0, 0);
    private Vector3 fly = new Vector3(0, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootKuni();
        izanagi();
       izanagiIndecator.transform.position = transform.position + izaPos;
        kuniIndecator.transform.position = transform.position + kuniPos;
    }

    // shooting kuni of a double tap
    public void shootKuni()
    {
        
        if (powerupOn == true)
        {
            if (Input.touchCount > 0)
            {

                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    float tapS = Time.time - tapT;
                    if (tapS <= doubleT)
                    {
                        Instantiate(kuniPrefab, transform.position + fly, kuniPrefab.transform.rotation);
                    }

                    tapT = Time.time;
                }
            }
        }
    }

    //delaying the repeate rate of obsticles
    public void izanagi()
    {

        spawnManager manager = FindObjectOfType<spawnManager>();

        if (powerupIzanagi && num == 1)
        {
            manager.slowDownTime();
            num = 0;
            hasResetSpawnRate = false; // Reset the flag when Izanagi is activated
        }
        else if (!powerupIzanagi && num == 0 && !hasResetSpawnRate)
        {
            manager.ResetSpawnRate();
            num = 1;
            hasResetSpawnRate = true; // Set the flag after resetting spawn rate
        }
    

}

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("coin"))
        {
            gotCoin = true;
            Destroy(other.gameObject);
            spawnManager manager = FindObjectOfType<spawnManager>();
            manager.UpdateScore(1);
          
           StartCoroutine(ResetGotCoin());

        }
       

        if (other.CompareTag("powerup1")){
            powerupOn = true;
            kuniIndecator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(kuniCountDown());

        }

        if (other.CompareTag("izanagiPowerUp"))
        {
            powerupIzanagi = true;
            izanagiIndecator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(izanagiCountDown());

        }





    }
    IEnumerator ResetGotCoin()
    {
       
        yield return new WaitForSeconds(0.51f);

        gotCoin = false;
    }
    IEnumerator kuniCountDown()
    {
        yield return new WaitForSeconds(5);
        kuniIndecator.gameObject.SetActive(false);
        powerupOn = false;
        
    }

    IEnumerator izanagiCountDown()
    {

        yield return new WaitForSeconds(10);
        izanagiIndecator.gameObject.SetActive(false);

        powerupIzanagi = false;
  
    }

  //  private void OnCollisionEnter(Collision collision)
   
}
