using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    private Vector3 beginP;
    // Start is called before the first frame update
    void Start()
    {
        beginP = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.z < beginP.z - 50)
         {
         transform.position = beginP;

             }
    }
}
