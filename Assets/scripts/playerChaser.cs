using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerChaser : MonoBehaviour
{
    public GameObject Player;
    private Vector3 chasePos = new Vector3 (0, 0, -4);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + chasePos;
    }
}
