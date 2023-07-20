using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PipeMoveScriptLeft : MonoBehaviour
{
    public float moveSpeed = 5;
    private float deadZone = -90;
    
    // Start is called before the first frame update
    void Start()
    {
       
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
}
