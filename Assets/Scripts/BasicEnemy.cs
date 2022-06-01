using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    int direction = -1;
    [SerializeField] GameObject rightEnd;
    [SerializeField] GameObject leftEnd;

    [SerializeField] float enemySpeed;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= rightEnd.transform.position.x)
        {
            direction = -1;
        }
        if(transform.position.x <= leftEnd.transform.position.x)
        {
            direction = 1;
        }
        rb.velocity = new Vector2(direction * enemySpeed, 0);

    }
}
