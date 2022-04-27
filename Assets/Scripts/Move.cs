using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject mainCamera;

    Vector3 playerVelocity;
    Vector3 playerJump;

    float playerSpeed = 2.0f;
    float jumpSpeed = 10.0f;
    float gravity = 5.5f;

    bool isGrounded = true;
    bool jump = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal move
        playerVelocity += transform.right * playerSpeed * Time.deltaTime;
        playerVelocity = Vector3.ClampMagnitude(playerVelocity, 10f);
        playerJump = jumpSpeed * transform.up * Time.deltaTime;
        if (Input.GetKey("d"))
        {
            player.transform.position += playerVelocity;
        }
        if (Input.GetKey("a"))
        {
            player.transform.position -= playerVelocity;
        }
        playerVelocity -= playerVelocity * 0.2f;

        //jump and fall
        if (player.transform.position.y > 1)

            isGrounded = false;
        else
            isGrounded = true;

        if (Input.GetKeyDown("w"))
        {
            if (isGrounded == true)
            {
                jump = true;
                isGrounded = false;
            }
        }

        if (jump == true)
        {
            player.transform.position += playerJump;
            if (player.transform.position.y > 5)
            {
                jump = false;
            }
        }
        if (isGrounded == false)
        {
            if (jump == false)
                player.transform.position += gravity * Time.deltaTime * -transform.up;
        }

        //dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            player.transform.position += new Vector3(2, 0, 0);
        }

        //camera position
        Vector3 pos = mainCamera.transform.position;
        pos.x = player.transform.position.x;
        mainCamera.transform.position = pos;

        //correct player y position
        if (player.transform.position.y < 1)
        {
            player.transform.position = new Vector3(player.transform.position.x, 1, player.transform.position.z);
        }
    }
}
