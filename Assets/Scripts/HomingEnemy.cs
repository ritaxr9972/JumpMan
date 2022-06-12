using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    int direction = -1;
    [SerializeField] GameObject rightEnd;
    [SerializeField] GameObject leftEnd;
    [SerializeField] float enemySpeed;
    [SerializeField] Rigidbody2D rb;
    bool isMove = true;
    Vector2 directionAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (transform.position.x >= rightEnd.transform.position.x)
            {
                direction = -1;
            }
            if (transform.position.x <= leftEnd.transform.position.x)
            {
                direction = 1;
            }
            rb.velocity = new Vector2(direction * enemySpeed, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            rb.velocity = Vector2.zero;
            isMove = false;
            directionAttack = collision.transform.position - gameObject.transform.position;
            StartCoroutine(PauseAttack());
            
        }
    }

    IEnumerator PauseAttack()
    {
        yield return new WaitForSeconds(1f);
        
        rb.velocity = directionAttack * 2.5f;
    }
}
