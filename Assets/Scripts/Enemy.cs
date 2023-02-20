using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float lineOfsite;
    public float shootRange;
    public float fireRate;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;   
        direction.Normalize();
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        rb.rotation = angle;
        if (distanceFromPlayer < lineOfsite && distanceFromPlayer > shootRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);            
        }
        else if (distanceFromPlayer <= shootRange && nextFireTime < Time.time)
        {
            GameObject newBullet = Instantiate(bullet, bulletParent.transform.position, transform.rotation);
            newBullet.GetComponent<EnemyBullet>().damage = 7;
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfsite);
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }
}
