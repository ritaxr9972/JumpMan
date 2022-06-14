using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] GameObject spawnPointUp;
    [SerializeField] GameObject spawnPointLeft;
    [SerializeField] GameObject spawnPointRight;
    [SerializeField] GameObject spawnPointDown;
    [SerializeField] float spawnTime;
    [SerializeField] ChooseSpawn spawnChoose;
    [SerializeField] float projectileSpeed;
    GameObject proj;
    bool canSpawn = true;

    enum ChooseSpawn
    {
        SpawnUp,
        SpawnLeft,
        SpawnRight,
        SpawnDown
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnProjectile());
        }
    }

    IEnumerator SpawnProjectile()
    {
        canSpawn = false;
        if (spawnChoose == ChooseSpawn.SpawnUp)
        {
            proj = Instantiate(enemyProjectile, spawnPoint1.transform.position, Quaternion.identity);
            proj.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
        }
        else if (spawnChoose == ChooseSpawn.SpawnLeft)
        {
            proj = Instantiate(enemyProjectile, spawnPoint2.transform.position, Quaternion.identity);
            proj.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0f);
        }
        else if (spawnChoose == ChooseSpawn.SpawnRight)
        {
            proj = Instantiate(enemyProjectile, spawnPoint3.transform.position, Quaternion.identity);
            proj.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0f);
        }
        else if (spawnChoose == ChooseSpawn.SpawnUp)
        {
            proj = Instantiate(enemyProjectile, spawnPoint1.transform.position, Quaternion.identity);
            proj.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
        }
        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(ContactPoint2D pos in collision.contacts)
        {
            if(pos.normal.x > 0)
            {
                if(collision.gameObject.name == "Player")
                {
                    if(collision.gameObject.GetComponent<Movement>().isSliding)
                    {
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        UnityEditor.EditorApplication.isPlaying = false;
                    }
                }

            }
            else
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
}
