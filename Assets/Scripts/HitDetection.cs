using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(ContactPoint2D pos in collision.contacts)
        {
            //Debug.Log(pos.normal);
            if(pos.normal.y < 0)
            {
                Debug.Log("Enemy hit and defeated");
                
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 400f));

                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Player hit and lose life");
            }
        }
    }
}
