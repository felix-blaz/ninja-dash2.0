using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public GameObject Capsule;
    // Start is called before the first frame update
    void Start()
    {
        Capsule.transform.position = new Vector3(0,0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 &&  Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if(endTouchPosition.x < startTouchPosition.x)
            {
                right();
            }

            if(endTouchPosition.x > startTouchPosition.x)
            {
                left(); 
            }
        }


    }

    public void left()
    {
        //Capsule.transform.position = new Vector3(Capsule.transform.position.x + 2, Capsule.transform.position.y, Capsule.transform.position.z);
        Capsule.transform.position = new Vector3(Capsule.transform.position.x + 2, 0, 0);
    }

    public void right()
    {
        Capsule.transform.position = new Vector3(Capsule.transform.position.x - 2, 0, 0);
       // Capsule.transform.position = new Vector3(Capsule.transform.position.x - 2, Capsule.transform.position.y, Capsule.transform.position.z);
    }
}
