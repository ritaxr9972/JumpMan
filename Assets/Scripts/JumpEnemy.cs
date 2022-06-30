using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpSpeed;
    [SerializeField] float moveSpeed;

    [SerializeField] BoxCollider2D bc;
    [SerializeField] LayerMask platformLayerMask;

    [SerializeField] GameObject leftEnd;
    [SerializeField] GameObject rightEnd;
    int direction = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= rightEnd.transform.position.x)
        {
            direction = -1;
        }
        if (transform.position.x <= leftEnd.transform.position.x)
        {
            direction = 1;
        }
        if (isGrounded())
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(moveSpeed * direction, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Floor")
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Floor")
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = false;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, platformLayerMask);

        return hit.collider != null;
    }

}
