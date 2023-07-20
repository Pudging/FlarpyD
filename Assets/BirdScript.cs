using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Principal;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Rigidbody2D myRigidBody;
    public float FlapStrength;
    public LogicScript logic;
    public bool alive = true;
    public Camera mCamera;
    private int health;
    public Animator animator;
    public double newDouble;
    float attackTimer = 0;
    float trackTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        health = 3;
        FlapStrength = 5.0f;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if (MainMenuScript.difficulty > 0)
        {
            myRigidBody.gravityScale = 0;
        }
        else {
            
            myRigidBody.gravityScale = 8;

        }
        logic.setHealth(health);
        attackTimer = Time.time;
        trackTimer = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y<=-30)
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.W) == true && alive)
        {
           // myRigidBody.velocity = (Vector2.up * FlapStrength);
            myRigidBody.velocity = new Vector2(0, 5) * FlapStrength;


        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - attackTimer > 1)
            {
                Attack();
                attackTimer = Time.time;
            }
           

        }
        if (MainMenuScript.difficulty > 0)
        {
            if (Input.GetKey(KeyCode.D) == true && alive)
            {
                gameObject.transform.eulerAngles = new Vector3 (0,0,0);
                myRigidBody.velocity = new Vector2(5, 0) * FlapStrength;
                //gameObject.transform.rotation = Quaternion.FromToRotation(transform.position, new Vector3(0,0,0));  
            }
            if (Input.GetKey(KeyCode.A) == true && alive)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 170, 0);


                //gameObject.transform.rotation = Quaternion.FromToRotation(transform.position, new Vector3(300,300,0));

                myRigidBody.velocity = new Vector2(-5, 0) * FlapStrength;
            }
            if (Input.GetKey(KeyCode.S) == true && alive)
            {
                myRigidBody.velocity = new Vector2(0, -5) * FlapStrength;
            }
        }
        if (health ==0 )
        {
            Death();
        }
        //timer updates
        
        logic.setTimer(Time.time - trackTimer);

        if(logic.getScore() >= 1)
        {
            logic.gameWon();
        }
    }
    private void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {

            if (enemy.gameObject.name == "SpinningPipe(Clone)") 
            {
                
                enemy.GetComponent<SpinningPipeScript>().takeDamage(1);
            }
            if (enemy.gameObject.name == "BasicFlyingPipe(Clone)")
            {
                enemy.GetComponent<FlyingMoveLeft>().takeDamage(1);

            }
            if (enemy.gameObject.name == "BossPrefab(Clone)")
            {
                enemy.GetComponent<BossPipeScript>().takeDamage(1);

            }
        }
        
    }


    IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        health--;
        logic.setHealth(health);
        StartCoroutine(WaitTime(1.0f));
    }
    void Death()
    {
        logic.gameOver();
        alive = false;
        mCamera.orthographicSize = 121;
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
