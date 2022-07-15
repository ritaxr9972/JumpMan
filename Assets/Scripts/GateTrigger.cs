using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject gateTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.SetActive(true);
        }
    }

    

}
