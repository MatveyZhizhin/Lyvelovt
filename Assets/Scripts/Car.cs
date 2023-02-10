using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float move;
    float rotation;

    public float moveSpeed;
    public float rotationSpeed;   


    private void Update()
    {
        move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * -rotationSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.Translate(0f, move, 0f);

        if (move > 0f || move < 0f)
        {
            transform.Rotate(0f, 0f, rotation);
        }       
    }
}
