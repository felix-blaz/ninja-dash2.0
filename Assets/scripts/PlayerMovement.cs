using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public GameObject Player;
    public float swipeSpeed;
    private Rigidbody playerRb;
    public float jumpForce;
    private float gravityModifier = 1;
    public bool onGround = true;
    public float xbounds = 4;
    playerDamage pd;


    // Start is called before the first frame update
    void Start()
    {
        
            playerRb = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
            pd = FindObjectOfType<playerDamage>();
            Player.transform.position = new Vector3(0, 1, 0);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (pd.isGameActive == true)
        {
            // keeping these player in bours  at -4 and 4
            if (transform.position.x < -xbounds)
            {

                transform.position = new Vector3(-xbounds, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > xbounds)
            {
                transform.position = new Vector3(xbounds, transform.position.y, transform.position.z);
            }
            playerControl();

        }
    }


    public void right()
    {
                         //code will move the payer 3 spaces on the X axis

        // Player.transform.position = new Vector3(Player.transform.position.x + 3, Player.transform.position.y, Player.transform.position.z);
        Player.transform.position = new Vector3(Player.transform.position.x + xbounds, 1, 0);

        // transform.Translate(Vector3.left*Time.deltaTime* swipeSpeed);
    }

    public void left()
    {
                         //code will move player 3 spaces on the X axis

        //transform.Translate(Vector3.right * Time.deltaTime * swipeSpeed);
        Player.transform.position = new Vector3(Player.transform.position.x - xbounds, 1, 0);
        //  Player.transform.position = new Vector3(Player.transform.position.x - 3, Player.transform.position.y, Player.transform.position.z);
    }

    public void jump()
    {
                        //code will allow player to jump
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    public void playerControl(){

        // code will get the finger swipes left right and up and give diffrent movemnts for each

        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // getting the position where finger first touced screen
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            //getting position when finger was tacken off
            endTouchPosition = Input.GetTouch(0).position;

            if (onGround)
            {
                //getting the value of the diffrence between start and end touch for the X axis and Y axis
                float X = endTouchPosition.x - startTouchPosition.x;
                float Y = endTouchPosition.y - startTouchPosition.y;

                if (Mathf.Abs(X) > Mathf.Abs(Y))
                {
                    // if the diffrence in  x is greater than Y this is to avoid diaginal cases 
                    // Horizontal Swipe
                    if (X < 0)
                    {
                        // Swipe Left
                        left();
                    }
                    else
                    {
                        // Swipe Right
                        right();
                    }
                }
                else
                {
                    // Vertical Swipe
                    if (Y > 0)
                    {
                        // Swipe Up (Jump)
                        jump();
                        onGround = false;
                    }
                }


            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround =  true; 
    }

   

}
