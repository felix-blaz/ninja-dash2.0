using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class treeMove : MonoBehaviour
{
    private float speed = 20f;
    private bool up = true;
    private float upper = 0;
    private float lower = -3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upDown();
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    public void upDown()
    {
        if (up)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 5f);
            if (transform.position.y >= -upper)
            {
                up = false;
            }
        }

        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * 5f);
            if (transform.position.y <= lower)
            {
                up = true;
            }
        }
    }
}
