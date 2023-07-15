using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    public Transform player, destination;

    public GameObject playerG;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider c)
    {

        if (c.gameObject.name == "Player")  
        {
            playerG.SetActive(false);

            player.position = destination.position;

            playerG.SetActive(true);

            Debug.Log("Player Detected");
        }
    }
}
