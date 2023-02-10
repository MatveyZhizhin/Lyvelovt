using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class OptionalDialog : MonoBehaviour
{
    public GameObject dialogWindow;


    private void Start()
    {        
        dialogWindow.SetActive(false);
    }       

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogWindow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogWindow.SetActive(false);
        }
    }
}
