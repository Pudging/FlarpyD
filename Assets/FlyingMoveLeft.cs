using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FlyingMoveLeft : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;
    public float moveSpeed = 20;
    private float deadZone = -110;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone || transform.position.x > -deadZone)
        {
            Destroy(gameObject);
        }
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {


            GetComponent<Rigidbody2D>().simulated = true;

            //Destroy(gameObject);
            GetComponent<BoxCollider2D>().enabled = false;

            GetComponent<Rigidbody2D>().gravityScale = 200;
        }
    }
}
