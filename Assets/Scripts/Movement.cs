using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] GameObject mainCamera;

    float movePlayer;

    [SerializeField] Rigidbody2D rb;

    public bool isJumping;

    [SerializeField] float dashSpeed = 14f;
    [SerializeField] float dashTime = 0.4f;
    Vector2 dashDirection;
    bool isDashing;
    bool canDash;
    

    // Start is called before the first frame update
    void Start()
    {
        
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
        }

        // camera follow player
        Vector3 pos = mainCamera.transform.position;
        pos.x = rb.transform.position.x;
        pos.y = rb.transform.position.y;
        mainCamera.transform.position = pos;
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
}
