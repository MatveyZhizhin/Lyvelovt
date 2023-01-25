using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    Cursor_Script cs;
    bool isStaying;
    bool isCollision;
    public Image dialogWindow;

    private void Start()
    {
        cs = FindObjectOfType<Cursor_Script>();
        dialogWindow.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollision == true)
        {
            isStaying = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && dialogWindow.enabled == true)
        {
            isStaying = false;
            dialogWindow.enabled = false;
            Time.timeScale = 1;
            cs.enabled = true;
            Cursor.visible = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isCollision = true;

        if (isStaying == true)
        {
            if (collision.CompareTag("Player"))
            {
                dialogWindow.enabled = true;
                Time.timeScale = 0;
                cs.enabled = false;
                Cursor.visible = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollision = false;
    }
}
