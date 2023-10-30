using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerCamera : MonoBehaviour
{
    private Vector3 camPos = new Vector3(0, 5,-10);
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //follow in the player when he changes lanes 
       transform.position = Player.transform.position + camPos;
}
}
