using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
}
