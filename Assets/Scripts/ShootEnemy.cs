using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float spawnTime;
    bool canSpawn = true;

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
        Instantiate(enemyProjectile, spawnPoint.transform.position, Quaternion.identity);
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
