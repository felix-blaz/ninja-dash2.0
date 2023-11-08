using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSkills : MonoBehaviour
{
    private float tapT;
    private float doubleT = 0.4f;
    public bool powerupOn = false;
    public GameObject kuniPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootKuni();
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup1")){
            powerupOn = true;
            Destroy(other.gameObject);
            StartCoroutine(kuniCountDown());
        }

      

    }
    IEnumerator kuniCountDown()
    {
        yield return new WaitForSeconds(4);
        powerupOn = false;
    }
   
    private void OnCollisionEnter(Collision collision)
    {
       

    }
}
