using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBack : MonoBehaviour
{
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerDamage manager = FindObjectOfType<playerDamage>();
        while (manager.isGameActive == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
