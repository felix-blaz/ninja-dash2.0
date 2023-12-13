using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBack : MonoBehaviour
{
    public float speed = 20;
    playerDamage pd;
    // Start is called before the first frame update
    void Start()
    {
        pd = FindObjectOfType<playerDamage>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (pd.isGameActive == true)
        {
            //move back
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
