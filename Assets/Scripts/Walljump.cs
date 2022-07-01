using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walljump : MonoBehaviour
{
    [SerializeField] float gravityScaleChange;
    float gravityScaleOriginal = 2f;
    bool canJump = false;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                canJump = false;
                //Debug.Log("Jumped");
                 player.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityScaleOriginal;
                 player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                 player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.gameObject.GetComponent<Rigidbody2D>().velocity.x, player.gameObject.GetComponent<Movement>().jumpSpeed));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D pos in collision.contacts)
        {
            if((pos.normal.x > 0) || (pos.normal.x < 0))
            {
                if(collision.gameObject.tag == "Player")
                {
                    player = collision.gameObject;
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityScaleChange;

                    canJump = true;
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canJump = false;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityScaleOriginal;
        }
    }

}
