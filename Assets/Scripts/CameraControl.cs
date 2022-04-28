using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject player;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = mainCamera.transform.position;
        pos.x = rb.transform.position.x;
        pos.y = rb.transform.position.y;
        mainCamera.transform.position = pos;
    }
}
