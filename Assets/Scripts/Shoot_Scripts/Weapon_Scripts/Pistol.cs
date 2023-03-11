using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    public Transform shotPoint;
    public GameObject bullet;
    public float startTimeBtwShots;
    public Text ammoText;
    public int maxAmmo;

    float timeBtwShots;
    int ammo;
    const int clipSize = 5;
    bool isReloading;

    private void Start()
    {
        ammo = maxAmmo;
    }

    void Update()
    {
        ammoText.text = ammo + "/30";
        if (Time.timeScale == 1)
        {
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0) && isReloading == false && ammo > 0)
                {
                    Instantiate(bullet, shotPoint.transform.position, transform.rotation);                   
                    ammo--;
                    timeBtwShots = startTimeBtwShots;
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                isReloading = true;
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        FindObjectOfType<Weapon_Change>().enabled = false;
        yield return new WaitForSeconds(clipSize);
        ammo = maxAmmo;
        isReloading = false;
        FindObjectOfType<Weapon_Change>().enabled = true;
    }
}
