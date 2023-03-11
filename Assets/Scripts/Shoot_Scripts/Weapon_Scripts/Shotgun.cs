using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] shotPoints;
    public Text ammoText;
    public float startTimeBtwShots;
    public int maxAmmo;

    int ammo;
    float timeBtwShots;
    const int clipSize = 5;
    bool isReloading;

    private void Start()
    {
        ammo = maxAmmo;
    }

    private void Update()
    {
        ammoText.text = ammo + "/27";

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0) && isReloading == false && ammo > 0)
            {
                Fire();
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

    void Fire()
    {
        for (int i = 0; i < shotPoints.Length; i++)
        {
            Instantiate(bullet, shotPoints[i].transform.position, shotPoints[i].transform.rotation);            
            ammo--;
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
