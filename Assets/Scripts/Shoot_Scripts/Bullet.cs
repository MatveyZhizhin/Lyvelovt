using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask solid;

    

    private void Update()
    {      
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, solid);
        if (hitInfo.collider != null && hitInfo.collider.tag != "DialogZone")
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
