using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BossPipeScript : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth;
    private float moveSpeed = 30;
    private float deadZone = -90;
    float timer = 0;
    float deltaTime;
    int attackNumber;
    public GameObject FlyingPipe;
    public GameObject SpinningPipe;
    // Start is called before the first frame updateE
    void Start()
    {

        currentHealth = maxHealth;
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()


    {
        if (Time.time - timer < 2.5)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }
         else
        {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        }
        deltaTime = Time.time - timer;
        if (deltaTime > 5 )
        {
            attackNumber = Random.Range(0, 3);
            if (attackNumber == 0 )
            {
                for (int count = 0; count < 10; count++)
                {
                    Instantiate(FlyingPipe, new Vector3(transform.position.x, Random.Range(-16, 16), 0.0f), FlyingPipe.transform.rotation);
                }
            }
            if (attackNumber == 1)
            {
                for (int count = 0; count < 10; count++)
                {
                    Instantiate(SpinningPipe, new Vector3(transform.position.x, Random.Range(-16, 16), 0.0f), SpinningPipe.transform.rotation);
                }
            }
            if (attackNumber == 2)
            {
                transform.position = new Vector3(Random.Range(-50, 100), Random.Range(-16, 16), transform.position.z);
            }
            timer = Time.time;
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