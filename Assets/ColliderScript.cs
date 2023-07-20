using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public LogicScript logic;
    public AudioSource mAudio;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
       

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerEnter2D(Collider2D collider2D) 
    {
        if (collider2D.gameObject.layer == 3)
        {
            logic.addScore(1);
            mAudio.Play();
            
        }
        
    }
}
