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
    public Text ammoText;
    bool isStaying;
    bool onCollision;
    int currentWeapon = 0;
    float timeBtwScroll;
    public float startTimeBtwScroll;

    private void Update()
    {
        if (timeBtwScroll <= 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && unlockedWeapons.Count > 1)
            {
                if (currentWeapon == unlockedWeapons.Count - 1)
                {
                    currentWeapon = 0;
                }
                else
                {
                    currentWeapon++;
                }
                Change(currentWeapon);

                timeBtwScroll = startTimeBtwScroll;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0 && unlockedWeapons.Count > 1)
            {
                if (currentWeapon == 0)
                {
                    currentWeapon = unlockedWeapons.Count - 1;
                }
                else
                {
                    currentWeapon--;
                }
                Change(currentWeapon);

                timeBtwScroll = startTimeBtwScroll;
            }           
        }
        else
        {
            timeBtwScroll -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && unlockedWeapons.Count > 1)
        {
            Change(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && unlockedWeapons.Count > 1)
        {
            Change(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && unlockedWeapons.Count > 2)
        {
            Change(2);
        }

        if (Input.GetKeyDown(KeyCode.F) && onCollision == true)
        {
            isStaying = true;
        }

        if (Input.GetKeyDown(KeyCode.G) && unlockedWeapons.Count > 1)
        {
            for (int i = 0; i < unlockedWeapons.Count; i++)
            {
                if (unlockedWeapons[i].activeInHierarchy)
                {
                    for (int j = 0; j < droppedWeapons.Length; j++)
                    {
                        if (unlockedWeapons[i].name == droppedWeapons[j].name)
                        {
                            GameObject newWeapon = Instantiate(droppedWeapons[j], transform.position, droppedWeapons[j].transform.rotation);
                            newWeapon.name = unlockedWeapons[i].name;
                        }
                    }

                    Change(i - 1);

                    unlockedWeapons.RemoveAt(i);

                    break;
                }
            }
        }

        if (unlockedWeapons[0].activeInHierarchy && unlockedWeapons[0].name == "Kick")
        {
            currentIcon.enabled = false;
            ammoText.enabled = false;
        }
        else
        {
            currentIcon.enabled = true;
            ammoText.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        onCollision = true;

        if (isStaying == true)
        {           
            if (collision.CompareTag("Weapon") && unlockedWeapons.Count != 3)
            {
                for (int i = 0; i < Weapons.Length; i++)
                {
                    if (collision.name == Weapons[i].name)
                    {
                        unlockedWeapons.Add(Weapons[i]);

                        Change(unlockedWeapons.Count - 1);

                        break;
                    }
                }               
                Destroy(collision.gameObject);
            }

            isStaying = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onCollision = false;
    }

    public void Change(int numberOfWeapon)
    {
        for (int i = 0; i < unlockedWeapons.Count; i++)
        {
            if (unlockedWeapons[i].activeInHierarchy)
            {
                unlockedWeapons[i].SetActive(false);
                unlockedWeapons[numberOfWeapon].SetActive(true);
                for (int j = 0; j < weaponIcons.Length; j++)
                {
                    if (unlockedWeapons[numberOfWeapon].name == weaponIcons[j].name)
                    {
                        currentIcon.sprite = weaponIcons[j].GetComponent<SpriteRenderer>().sprite;
                    }
                }

                currentIcon.SetNativeSize();
                break;
            }
        }              
    }
}
