using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private enum FireType {fire, burst}

    private FireType fireType;

    int ammo;
    public int maxAmmo;
    public Text ammoText;
    public int damage;

    public Transform shotPoint;
    public GameObject bullet;

    private float timeBtwShots;
    public float startTimeBtwShots;

    const float clipSize = 5;
    private int bullets = 3;
    private const float fireRate = 0.3f;
    private const float coolDown = 1f;
    bool fire;
    bool isReloading;

    private void Start()
    {
        fireType = FireType.fire;
        ammo = maxAmmo;
    }

    private void Update()
    {
        ammoText.text = ammo + "/60";
        if (Time.timeScale == 1)
        {
            if (fireType == FireType.burst)
            {
                if (Input.GetMouseButtonDown(0) && fire == false && isReloading == false && ammo > 0)
                {
                    fire = true;
                    StartCoroutine(Burst());
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (fireType == FireType.fire)
                {
                    fireType = FireType.burst;
                }
                else
                {
                    fireType = FireType.fire;
                }
            }

            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButton(0) && fireType == FireType.fire && isReloading == false && ammo > 0)
                {
                    GameObject newBullet = Instantiate(bullet, shotPoint.transform.position, transform.rotation);
                    newBullet.GetComponent<Bullet>().damage = 3;
                    ammo--;
                    timeBtwShots = startTimeBtwShots;
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.R) && ammo != maxAmmo)
            {
                isReloading = true;
                StartCoroutine(Reload());
            }
        }     
    }

    IEnumerator Burst()
    {       
       for (var i = 0; i < bullets; i++)
       {
            GameObject newBullet = Instantiate(bullet, shotPoint.transform.position, transform.rotation);
            newBullet.GetComponent<Bullet>().damage = 3;
            ammo--;
          yield return new WaitForSeconds(fireRate);
       }
       yield return new WaitForSeconds(coolDown);
       fire = false;
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
