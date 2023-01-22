using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float speed;
    public float fastSpeed;
    private float realSpeed;
    private Rigidbody2D rb;
    public float maxHealth = 10f;
    float currentHealth;
    public Animator legsAnim;
    public Animator bodyAnim;

    Vector2 movement;
    void Start()
    {
        Cursor.visible = false;
        //тут берет и присвоен компонент или перменная.
        rb = GetComponent<Rigidbody2D>();
        realSpeed = speed;
        currentHealth = maxHealth;
    }
    void Update()
    {
        //тут управление по х и у:
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 0 && movement.y == 0)
        {
            legsAnim.SetBool("isRunning", false);
            bodyAnim.SetBool("isRunning", false);
        }
        else
        {
            legsAnim.SetBool("isRunning", true);
            bodyAnim.SetBool("isRunning", true);
        }
    }

    void FixedUpdate()
    {
        //тут установлен реалспид который изначально просто(speed)
        rb.MovePosition(rb.position + movement * realSpeed * Time.fixedDeltaTime);
        shiftRun();
    }

    public void TakeHit(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth += _value;
        if (currentHealth >= 10)
        {
            currentHealth = 10;
        }
    }
    void shiftRun()
    {
        //вот тут и условие быстрый бег, котором реалспид присваивает значение (fastSpeed). 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            realSpeed = fastSpeed;
        }
        else
        {
            realSpeed = speed;
        }
    }  
}
