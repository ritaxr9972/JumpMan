using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float cameraOffset;
    [SerializeField] float offsetSmoothing;
    Rigidbody2D rb;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(rb.transform.position.x, rb.transform.position.y, transform.position.z);

        if (!player.GetComponent<SpriteRenderer>().flipX)
        {
            pos = new Vector3(pos.x + cameraOffset, pos.y, pos.z);
        }
        else if (player.GetComponent<SpriteRenderer>().flipX)
        {
            pos = new Vector3(pos.x - cameraOffset, pos.y, pos.z);
        }

        transform.position = Vector3.Lerp(transform.position, pos, offsetSmoothing * Time.deltaTime);
    }

    
}
