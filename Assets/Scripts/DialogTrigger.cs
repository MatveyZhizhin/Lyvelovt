using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public GameObject dialogWindow;

    private void Start()
    {
        dialogWindow.SetActive(false);
    }       

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DialogZone"))
        {
            dialogWindow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DialogZone"))
        {
            dialogWindow.SetActive(false);
        }
    }
}
