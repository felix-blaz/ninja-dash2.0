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
    private bool resettingSpawnRate = false;
    int num = 1;
    public GameObject kuniIndecator;
    public AudioClip kuniupAudioClip;
    public AudioClip kuniAudioClip;
    public AudioClip coinAudioclip;
    public AudioClip izanagiAudioClip;

    public AudioSource playerAudio;
    private Vector3 izaPos = new Vector3(0.3f, 1.3f, 0);
    private Vector3 kuniPos = new Vector3(0, 0, 0);
    private Vector3 fly = new Vector3(0, 1, 1);
    public GameObject izanagibg;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        shootKuni();
        izanagi();
     
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
                        playerAudio.PlayOneShot(kuniAudioClip, 1.0f);
                    }

                    tapT = Time.time;
                }
            }
        }
    }

    //  Slowing down the spawn rate of obstacles for powerup
    public void izanagi()
    {

        spawnManager manager = FindObjectOfType<spawnManager>();

        if (powerupIzanagi && num == 1)
        {
            manager.slowDownTime();
            num = 0;
            resettingSpawnRate = false; // Reset 
        }
        else if (!powerupIzanagi && num == 0 && !resettingSpawnRate)
        {
            manager.ResetSpawnRate();
            num = 1;
            resettingSpawnRate = true; // Set to true after 
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
            playerAudio.PlayOneShot(coinAudioclip, 1.0f);
            StartCoroutine(ResetGotCoin());

        }
       

        if (other.CompareTag("powerup1")){
            powerupOn = true;
            kuniIndecator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(kuniupAudioClip, 1.0f);
            StartCoroutine(kuniCountDown());

        }

        if (other.CompareTag("izanagiPowerUp"))
        {
            powerupIzanagi = true;
          
            Destroy(other.gameObject);
            StartCoroutine(izanagiCountDown());
            playerAudio.PlayOneShot(izanagiAudioClip, 1.0f);
            
            izanagibg.gameObject.SetActive(true);
            
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
       
        izanagibg.gameObject.SetActive(false);
        powerupIzanagi = false;
  
    }

  
   
}
