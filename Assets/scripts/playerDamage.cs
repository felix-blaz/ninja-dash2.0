using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;




public class playerDamage : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI yourScore;
    public bool isGameActive = false;
    public GameObject gameOver;
    public AudioClip ramenAudioClip;
    public AudioClip damageAudioClip;
    public ParticleSystem lifeparticle;
    public ParticleSystem smokeparticle;
    public AudioClip deadAudioClip;
    public AudioSource playerAudio;
    private Animator animator;


    public bool tookDamage = false;
    public bool tookHealth = false;
    public bool dead = false;
    public int finalScore = 0;

    private int health = 3;
    // Start is called before the first frame update

   

    

   
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
     public void GameOver()
    {
        
      isGameActive = false;
        spawnManager manager = FindObjectOfType<spawnManager>();
        finalScore = manager.score;
        GameManager.Instance.StoreScore(finalScore);

        // Debug.Log(finalScore);
        yourScore.text = "Final score: " + finalScore;
       gameOver.gameObject.SetActive(true);
        
    }


   





    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("health"))
        {
            tookHealth = true;
            playerAudio.PlayOneShot(ramenAudioClip, 1.0f);
            lifeparticle.Play();
            Destroy(other.gameObject);
            if (health < 3)
            {
                health++;

                playerHealth.text = "Health : " + health;

            }
            StartCoroutine(ResettookHealth());
        }

        //when an obsticle colides with the player 3 times the game ends 
        if (other.CompareTag("obsticles") )
            {
            tookDamage = true;
          // health does down after every collision
            health--;
            playerAudio.PlayOneShot(damageAudioClip, 2.0f);
            playerHealth.text = "Health : " + health;
            Destroy(other.gameObject);
            StartCoroutine(ResettookDamage());
            //when health reaches 0 game is over
            if ( health == 0)
            {
                playerAudio.PlayOneShot(deadAudioClip, 1.0f);
                smokeparticle.Play();
                animator.SetBool("Death_b", true);
                animator.SetInteger("DeathType_int", 1);
                StartCoroutine(chill());
                
            }
            }

        IEnumerator ResettookDamage()
        {

            yield return new WaitForSeconds(0.51f);

            tookDamage = false;
        }
        IEnumerator ResettookHealth()
        {

            yield return new WaitForSeconds(0.1f);

            tookHealth = false;
        }

        IEnumerator chill()
        {

            yield return new WaitForSeconds(0.5f);
            GameOver();

        }

    }

    
}
