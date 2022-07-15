using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] GameObject player; 
    gameObject.SetActive(false);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x<gameObject.transform.position && player.transform.position.y > gameObject.transform.position.y)
        {
            gameObject.SetActive(true);
        }
           
    }

    

}
