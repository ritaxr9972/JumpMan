using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpSpeed;


    float movePlayer;

    [SerializeField] Rigidbody2D rb;

    bool isJumping;

    //dash parameters
    [SerializeField] float dashSpeed = 20f;
    [SerializeField] float dashTime = 0.4f;
    Vector2 dashDirection;
    bool isDashing;
    bool canDash;

    bool canMove = true;

    [SerializeField] float smashSpeed;
    [SerializeField] float smashTime;

    //dash cooldown parameters
    [SerializeField] float coolDownPeriodInSeconds = 5f;
    float timeStamp; 



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            // player move
            movePlayer = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(playerSpeed * movePlayer, rb.velocity.y);

            //player jump
            if ((Input.GetButtonDown("Jump")) && (isJumping == false))
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
            }

            //dash with cooldown
            if (timeStamp <= Time.time)
            {
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
                    timeStamp = Time.time + coolDownPeriodInSeconds;
                }

            }

            if ((Input.GetKey(KeyCode.LeftControl)) && (isJumping))
            {
                rb.velocity = Vector2.zero;
                canMove = false;
                rb.AddForce(new Vector2(rb.velocity.x, -smashSpeed));
                StartCoroutine(SmashWait());
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            canDash = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
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
        yield return new WaitForSeconds(smashTime);
        canMove = true;
    }

}
