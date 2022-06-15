using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemyRange : MonoBehaviour
{
    [SerializeField] GameObject parent;
    Color color;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            player = collision.gameObject;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            parent.GetComponent<HomingEnemy>().rb.velocity = Vector2.zero;
            parent.GetComponent<HomingEnemy>().isMove = false;
            
            StartCoroutine(PauseAttack());

            
        }
    }

    IEnumerator PauseAttack()
    {
        parent.GetComponent<HomingEnemy>().directionAttack = player.transform.position - parent.gameObject.transform.position;
        color = parent.GetComponent<SpriteRenderer>().color;
        parent.GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(parent.GetComponent<HomingEnemy>().homingWaitTime);
        parent.GetComponent<SpriteRenderer>().color = color;
        
        parent.GetComponent<HomingEnemy>().rb.velocity = parent.GetComponent<HomingEnemy>().directionAttack * parent.GetComponent<HomingEnemy>().homingSpeed;

    }
}
