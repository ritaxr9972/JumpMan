using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] ChooseType type;

    int direction = -1;
    [SerializeField] GameObject rightEnd;
    [SerializeField] GameObject leftEnd;

    [SerializeField] GameObject topEnd;
    [SerializeField] GameObject botEnd;

    [SerializeField] float enemySpeed;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    enum ChooseType
    {
        TypeHorizontal,
        TypeVertical
    };

    // Update is called once per frame
    void Update()
    {
        if (type == ChooseType.TypeHorizontal)
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
        else if (type == ChooseType.TypeVertical)
        {
            if (transform.position.y >= topEnd.transform.position.y)
            {
                direction = -1;
            }
            if (transform.position.y <= botEnd.transform.position.y)
            {
                direction = 1;
            }
            rb.velocity = new Vector2(0, direction * enemySpeed);
        }

    }
}
