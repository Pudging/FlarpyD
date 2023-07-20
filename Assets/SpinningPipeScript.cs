using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SpinningPipeScript : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;
    private float moveSpeed = 10;
    private float deadZone = -90;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()


    {
        if (Time.time - timer > 2)
        {
            
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
            if (Time.time - timer > 5)
            {
                timer = Time.time;
            }
        }

        else
        {
            transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -1) * Time.deltaTime * 60;
        }

        if (transform.position.x < deadZone || transform.position.x > -deadZone)
        {
            Destroy(gameObject);
        }
    }
    public void takeDamage (int damage)
    {

        currentHealth -= damage;
        if (currentHealth <=0)
        {
            GetComponent<Rigidbody2D>().simulated = true;

            //Destroy(gameObject);
            GetComponent<BoxCollider2D>().enabled = false;

            GetComponent<Rigidbody2D>().gravityScale = 200;
        }
    }
}