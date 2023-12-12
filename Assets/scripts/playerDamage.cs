using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public bool isGameActive = true;
    int damage = 0;
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
       
    }

    private void OnTriggerEnter(Collider other)
    {
       
       

            if (other.CompareTag("obsticles") )
            {
            damage++;
            Destroy(other.gameObject);

            if (damage >= 3)
            {
               // playerDamage manager = new playerDamage();
              //  gameUi Ui = FindObjectOfType<gameUi>();
              //   Destroy(gameObject);
               GameOver();
            }



            }
            
     }

    
}
