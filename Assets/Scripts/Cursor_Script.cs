using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Script : MonoBehaviour
{
    public float offset;
    public GameObject crossHair;
    public GameObject player;
    private Vector3 target;
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crossHair.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
}
