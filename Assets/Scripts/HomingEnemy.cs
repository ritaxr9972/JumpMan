using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    int direction = -1;
    [SerializeField] GameObject rightEnd;
    [SerializeField] GameObject leftEnd;
    [SerializeField] float enemySpeed;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public float homingSpeed;
    [SerializeField] public float homingWaitTime;
    public bool isMove = true;
    public Vector2 directionAttack;
   // [SerializeField] LayerMask platformLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (transform.position.x >= rightEnd.transform.position.x)
            {
                direction = -1;
            }
            if (transform.position.x <= leftEnd.transform.position.x)
            {
                direction = 1;
            }
            rb.velocity = new Vector2(direction * enemySpeed, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Platforms"))
        {
              gameObject.SetActive(false);
            //Destroy(gameObject);
           // Debug.Log("Hit a platform");
        }
        else if (collision.gameObject.name == "Player")
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    /*  private void OnTriggerEnter2D(Collider2D collision)
      {
          if(collision.gameObject.name == "Player")
          {
              rb.velocity = Vector2.zero;
              isMove = false;
              directionAttack = collision.transform.position - gameObject.transform.position;
              StartCoroutine(PauseAttack());

          }
      }

      IEnumerator PauseAttack()
      {

          yield return new WaitForSeconds(1f);

          rb.velocity = directionAttack * 2.5f;
      } */
}
