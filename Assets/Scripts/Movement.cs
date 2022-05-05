using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpSpeed;
    //[SerializeField] GameObject mainCamera;

    float movePlayer;

    [SerializeField] Rigidbody2D rb;

    bool isJumping;

    [SerializeField] float dashSpeed = 20f;
    [SerializeField] float dashTime = 0.4f;
    Vector2 dashDirection;
    bool isDashing;
    bool canDash;

    [SerializeField] float smashSpeed;

    //Parameters for dash(test)
    
    //public float startDashTime;


    // Start is called before the first frame update
    void Start()
    {
        //dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        // player move
        movePlayer = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(playerSpeed * movePlayer, rb.velocity.y);

        //player jump
        if((Input.GetButtonDown("Jump")) && (isJumping == false))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
        }

        //dash test
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            dashTime -= Time.deltaTime;
            if (dashTime > 0)
            {
                rb.velocity = new Vector2(playerSpeed * movePlayer * dashSpeed, rb.velocity.y);
            }
                
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            dashTime = 0.4f;
        }

        /*
        // player dash
        if((Input.GetButtonDown("Dash")) && canDash)
        {
            isDashing = true;
            canDash = false;

            dashDirection = new Vector2(Input.GetAxis("Horizontal"), 0);

            StartCoroutine(StopDash());
        }

        if(isDashing)
        {
            rb.velocity = Vector2.zero;
            rb.velocity = dashDirection * dashSpeed;
            return;
        }*/

        if((Input.GetKey(KeyCode.LeftControl)) && (isJumping))
        {
            rb.AddForce(new Vector2(rb.velocity.x, -smashSpeed));
            StartCoroutine(SmashWait());
        }

        // camera follow player
       /* Vector3 pos = mainCamera.transform.position;
        pos.x = rb.transform.position.x;
        pos.y = rb.transform.position.y;
        mainCamera.transform.position = pos; */
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            canDash = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
           // canDash = false;
        }
    }

    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        canDash = true;
    }

    IEnumerator SmashWait()
    {
        yield return new WaitForSeconds(3f);
    }
}
