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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootKuni();
        slowDownTime();
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
                        Instantiate(kuniPrefab, transform.position, kuniPrefab.transform.rotation);
                    }

                    tapT = Time.time;
                }
            }
        }
    }

    //delaying the repeate rate of obsticles
    public void slowDownTime()
    {
       
        if (powerupIzanagi == true)
        {
            spawnManager manager = FindObjectOfType<spawnManager>();
            manager.slowDownTime();

        }
        else if (powerupIzanagi == false)
        {
            spawnManager manager = FindObjectOfType<spawnManager>();
            manager.ResetSpawnRate();
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
            Destroy(other.gameObject);
            StartCoroutine(kuniCountDown());

        }

        if (other.CompareTag("izanagiPowerUp"))
        {
            powerupIzanagi = true;
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
        powerupOn = false;
        
    }

    IEnumerator izanagiCountDown()
    {

        yield return new WaitForSeconds(10);

        powerupIzanagi = false;
  
    }

  //  private void OnCollisionEnter(Collision collision)
   
}
