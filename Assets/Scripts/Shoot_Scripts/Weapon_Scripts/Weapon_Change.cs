using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_Change : MonoBehaviour
{
    public List<GameObject> unlockedWeapons;
    public GameObject[] Weapons;
    public GameObject[] weaponIcons;
    public GameObject[] droppedWeapons;
    public Image currentIcon;
    public Text ammo;
    bool isStaying;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && unlockedWeapons.Count > 1)
        {
            Change();
        } 
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            isStaying = true;
        }

        if (unlockedWeapons[0].activeInHierarchy && unlockedWeapons[0].name == "Kick")
        {
            currentIcon.enabled = false;
            ammo.enabled = false;
        }
        else
        {
            currentIcon.enabled = true;
            ammo.enabled = true;
        }

        if (unlockedWeapons.Count == 3)
        {
            Change();
            unlockedWeapons.RemoveAt(0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {                                   
        if (isStaying == true)
        {
            if (unlockedWeapons[0].activeInHierarchy == false && unlockedWeapons.Count == 3)
            {
                for (int i = 0; i < droppedWeapons.Length; i++)
                {
                    if (unlockedWeapons[i].name == droppedWeapons[i].name)
                    {
                        if (unlockedWeapons[i].activeInHierarchy)
                        {
                            GameObject weapon = Instantiate(droppedWeapons[i], transform.position, droppedWeapons[i].transform.rotation);
                            weapon.name = unlockedWeapons[1].name;
                        }                      
                    }
                }
                Change();
                unlockedWeapons.RemoveAt(1);
            }

            if (collision.CompareTag("Weapon") && unlockedWeapons.Count != 3)
            {
                for (int i = 0; i < Weapons.Length; i++)
                {
                    if (collision.name == Weapons[i].name)
                    {
                        unlockedWeapons.Add(Weapons[i]);
                    }
                }
                Change();
                Destroy(collision.gameObject);
            }

            isStaying = false;
        }
    }

    public void Change()
    {
        for (int i = 0; i < unlockedWeapons.Count; i++)
        {
           
            if (unlockedWeapons[i].activeInHierarchy)
            {
                   unlockedWeapons[i].SetActive(false);
                 if (i != 0)
                 {
                     unlockedWeapons[i - 1].SetActive(true);
                     for (int j = 0; j < weaponIcons.Length; j++)
                     {
                         if (unlockedWeapons[i - 1].name == weaponIcons[j].name)
                         {
                            currentIcon.sprite = weaponIcons[j].GetComponent<SpriteRenderer>().sprite;
                         }
                     }
                 }
                 else
                 {
                     unlockedWeapons[unlockedWeapons.Count - 1].SetActive(true);
                     for (int j = 0; j < weaponIcons.Length; j++)
                     {
                         if (unlockedWeapons[unlockedWeapons.Count - 1].name == weaponIcons[j].name)
                         {
                            currentIcon.sprite = weaponIcons[j].GetComponent<SpriteRenderer>().sprite;
                         }
                     }
                 }

                currentIcon.SetNativeSize();
                break;
            }            
        }
    }
}
