using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    bool isOpened;
    float timer;
    //public Animator playerAnim;
    bool isCollision;
    public GameObject door;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isCollision == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && isOpened == false)
            {
                anim.SetTrigger("Open");
                isOpened = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && isOpened == true)
            {
                anim.SetTrigger("Close");
                isOpened = false;
            }
            
            

         
            if (isOpened == false)
            {
                if (timer >= 1)
                {
                    
                    //playerAnim.SetTrigger("Leg");
                    anim.SetTrigger("FastOpen");                    
                    timer = 0;
                    isOpened = true;
                    this.enabled = false;
                }
                /*
                else if (timer >= 3)
                {
                     playerAnim.SetTrigger("Leg");
                     playerAnim.SetTrigger("disableDoor");
                     door.GetComponent<Collider2D>().enabled = false;
                     timer = 0;
                     this.enabled = false;
                }
               */
            }
           
        }            
      
       
        if (timer > 3)
        {
            timer = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            timer += Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            timer = 0;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollision = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        timer = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollision = false;
    }
}
