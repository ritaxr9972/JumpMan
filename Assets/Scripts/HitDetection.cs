using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{

    [SerializeField] float enemyJumpSpeed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(ContactPoint2D pos in collision.contacts)
        {
            //Debug.Log(pos.normal);
            if(pos.normal.y < 0)
            {
                
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, enemyJumpSpeed));
                
                if(collision.gameObject.name == "Player")
                {
                    collision.gameObject.GetComponent<Movement>().canDash = true;
                }

                gameObject.SetActive(false);
            }
            else
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
}
