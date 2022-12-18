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
    public float currenHealth;
    public HealthBar healthBar;
    public Animator legsAnim;
    public Animator bodyAnim;

    Vector2 movement;
    void Start()
    {
        Cursor.visible = false;
        //тут берет и присвоен компонент или перменная.
        rb = GetComponent<Rigidbody2D>();
        realSpeed = speed;
        currenHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
        currenHealth -= damage;
        healthBar.Sethealth(currenHealth);
        if (currenHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void AddHealth(float _value)
    {
        currenHealth += _value;
        healthBar.Sethealth(currenHealth);
        if (currenHealth >= 10)
        {
            currenHealth = 10;
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
