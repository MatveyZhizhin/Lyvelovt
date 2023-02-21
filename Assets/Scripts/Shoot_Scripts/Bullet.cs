using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask solid;
    public int damage;
    

    private void Update()
    {      
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, solid);
        if (hitInfo.collider != null && hitInfo.collider.isTrigger == false)
        {            
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeHit(damage);                
            }           
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
