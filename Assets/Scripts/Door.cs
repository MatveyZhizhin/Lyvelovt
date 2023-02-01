using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    bool isOpened;
    Player_Control pc;
    float timer;
    public Animator playerAnim;
    bool isCollision;
    public GameObject door;

    private void Start()
    {
        anim = GetComponent<Animator>();
        pc = FindObjectOfType<Player_Control>();
    }

    private void Update()
    {
        if (isCollision == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && isOpened == false)
            {
                anim.SetBool("isOpened", true);
                isOpened = true;
            }
            else
            {
                anim.SetBool("isOpened", false);
                isOpened = false;
            }

            if (pc.speed == 10 && isOpened == false)
            {
                if (timer >= 1)
                {
                    playerAnim.SetTrigger("Leg");
                    anim.SetTrigger("fastOpening");                    
                    timer = 0;
                    isOpened = true;
                }
                else if (timer >= 3)
                {
                    playerAnim.SetTrigger("Leg");
                    playerAnim.SetTrigger("disableDoor");
                    door.GetComponent<Collider2D>().enabled = false;
                    timer = 0;
                    this.enabled = false;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollision = false;
    }
}
