using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    int damage = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
       
       

            if (other.CompareTag("obsticles") )
            {
            damage++;
            Destroy(other.gameObject);

            if (damage >= 3)
            {
                gameUi Ui = FindObjectOfType<gameUi>();
                Destroy(gameObject);
                Ui.GameOver();
            }



            }
            
     }

    
}
