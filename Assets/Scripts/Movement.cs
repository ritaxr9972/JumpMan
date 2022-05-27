using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpSpeed;

    [SerializeField] float crouchHeightSize;
    [SerializeField] float crouchHeightOffset;
    Vector2 playerColliderSize;
    Vector2 playerColliderOffset;

    float movePlayer;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D bc;
    [SerializeField] LayerMask platformLayerMask;

    bool isJumping;

    //dash parameters
    [SerializeField] float dashSpeed = 20f;
    [SerializeField] float dashTime = 0.4f;
    Vector2 dashDirection;
    bool isDashing;
    public bool canDash;

    bool canMove = true;

    [SerializeField] float smashSpeed;
    [SerializeField] float smashTime;

    //dash cooldown parameters
   /* [SerializeField] float coolDownPeriodInSeconds = 5f;
    float timeStamp; */

    bool isCrouch;

    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerColliderSize = bc.size;
        playerColliderOffset = bc.offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            //check for if player is in the air
            if(!isGrounded())
            {
                anim.SetBool("isJumping", true);
            }

            //check for if player is on the ground
            if (isGrounded())
            {
                anim.SetBool("isJumping", false);
                canDash = true;
                anim.SetFloat("Speed", Mathf.Abs(playerSpeed * movePlayer));
            }

            // player move
            movePlayer = Input.GetAxis("Horizontal");
            RotateSprite();
            rb.velocity = new Vector2(playerSpeed * movePlayer, rb.velocity.y);

            //player jump
            if ((Input.GetButtonDown("Jump")) && (isGrounded()) && (!isCrouch))
            {
                
                rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
                
            }

            //player dash
            
            if (Input.GetKeyDown(KeyCode.LeftShift) && (canDash) && (!isCrouch))
            {
                canDash = false;
                isDashing = true;     
            }

            if(isDashing)
            {
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(movePlayer * dashSpeed, 0);
                StartCoroutine(StopDash());
            }   

            //player smash

            if ((Input.GetKey(KeyCode.LeftControl)) && (!isGrounded()))
            {
                rb.velocity = Vector2.zero;
                canMove = false;
                rb.AddForce(new Vector2(rb.velocity.x, -smashSpeed));
                StartCoroutine(SmashWait());
            }

            //player crouch

            if ((Input.GetKey(KeyCode.LeftControl)) && (isGrounded()))
            {
                bc.size = new Vector2(playerColliderSize.x, playerColliderSize.y * crouchHeightSize);
                bc.offset = new Vector2(playerColliderOffset.x, playerColliderOffset.y * crouchHeightOffset);
                rb.velocity = new Vector2(playerSpeed * movePlayer * 0.3f, rb.velocity.y);
                isCrouch = true;
                anim.SetBool("isCrouching", true);
 
            }
            if ((Input.GetKeyUp(KeyCode.LeftControl)) && (isGrounded()))
            {
                bc.size = playerColliderSize;
                bc.offset = playerColliderOffset;
                isCrouch = false;
                anim.SetBool("isCrouching", false);
            }
        }

    }

    //function to check if player is on the ground by drawing a boxcast
    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.5f, platformLayerMask);

        return hit.collider != null;
    }

  /*  private void OnCollisionEnter2D(Collision2D other)
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
    */

    //enumerator to stop the dash
    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
    } 

    //enumerator to wait after the slam
    IEnumerator SmashWait()
    {
        yield return new WaitForSeconds(smashTime);
        canMove = true;
    }

    //function to rotate the player sprite based on which direction they have inputted
    private void RotateSprite()
    {
        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetAxis("Horizontal") < -0.01f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
