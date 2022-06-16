using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   // [SerializeField] float projectileSpeed;
   // [SerializeField] Rigidbody2D rb;
   // [SerializeField] GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyProjectile());
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (spawner.gameObject.GetComponent<ShootEnemy>().spawnChoose == 1)
        {
            rb.velocity = new Vector2(0f, projectileSpeed);
        }
        else if (spawner.gameObject.GetComponent<ShootEnemy>().spawnChoose == 2)
        {
            rb.velocity = new Vector2(-projectileSpeed, 0f);
        }
        else if (spawner.gameObject.GetComponent<ShootEnemy>().spawnChoose == 3)
        {
            rb.velocity = new Vector2(projectileSpeed, 0f);
        } */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Floor")
        {
            
            Destroy(gameObject);
        }
    }


    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
}
