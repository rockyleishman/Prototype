using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Package : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject PackagePart1 = GameObject.Find("Package Carry");
        PackagePart1.GetComponent<Renderer>().enabled = false;


        GameObject PackagePart2 = GameObject.Find("Top Tape Carry");
        PackagePart2.GetComponent<Renderer>().enabled = false;



        GameObject PackagePart3 = GameObject.Find("Right Tape Carry");
        PackagePart3.GetComponent<Renderer>().enabled = false;


        GameObject PackagePart4 = GameObject.Find("Left Tape Carry");
        PackagePart4.GetComponent<Renderer>().enabled = false;

    }

    

    public void OnTriggerEnter(Collider c)
    {
        
      
            if (c.gameObject.name == "Player")
            {
                Destroy(gameObject);



                GameObject PackagePart1 = GameObject.Find("Package Carry");
                PackagePart1.GetComponent<Renderer>().enabled = true;



                GameObject PackagePart2 = GameObject.Find("Top Tape Carry");
                PackagePart2.GetComponent<Renderer>().enabled = true;



                GameObject PackagePart3 = GameObject.Find("Right Tape Carry");
                PackagePart3.GetComponent<Renderer>().enabled = true;


                GameObject PackagePart4 = GameObject.Find("Left Tape Carry");
                PackagePart4.GetComponent<Renderer>().enabled = true;

            }
       

                
    }


}
