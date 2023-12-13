using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class playerDamage : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI playerHealth;
    public bool isGameActive = false;
    public Button restartButtion;
    
    private int health = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
     public void GameOver()
    {
        
      isGameActive = false;
      gameOverText.gameObject.SetActive(true);
       restartButtion.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
       
       

        //when an obsticle colides with the player 3 times the game ends 
            if (other.CompareTag("obsticles") )
            {
          // health does down after every collision
            health--;
            playerHealth.text = "Health : " + health;
            Destroy(other.gameObject);
            //when health reaches 0 game is over
            if ( health == 0)
            {
              
               //  Destroy(gameObject);
               GameOver();
            }



            }
            
     }

    
}
