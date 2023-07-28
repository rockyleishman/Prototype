using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffTable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject PackagePart1 = GameObject.Find("Package");
        PackagePart1.GetComponent<Renderer>().enabled = false;


        GameObject PackagePart2 = GameObject.Find("Top Tape");
        PackagePart2.GetComponent<Renderer>().enabled = false;



        GameObject PackagePart3 = GameObject.Find("Right Tape");
        PackagePart3.GetComponent<Renderer>().enabled = false;


        GameObject PackagePart4 = GameObject.Find("Left Tape");
        PackagePart4.GetComponent<Renderer>().enabled = false;

        
    }

    public void OnTriggerEnter(Collider c)
    {

        GameObject Package = GameObject.Find("Package Pickup");

        if (Package == null)
        {
            if (c.gameObject.name == "Player")
            {


                GameObject PackagePart1 = GameObject.Find("Package");
                PackagePart1.GetComponent<Renderer>().enabled = true;



                GameObject PackagePart2 = GameObject.Find("Top Tape");
                PackagePart2.GetComponent<Renderer>().enabled = true;



                GameObject PackagePart3 = GameObject.Find("Right Tape");
                PackagePart3.GetComponent<Renderer>().enabled = true;


                GameObject PackagePart4 = GameObject.Find("Left Tape");
                PackagePart4.GetComponent<Renderer>().enabled = true;






                GameObject PackagePart5 = GameObject.Find("Package Carry");
                PackagePart5.GetComponent<Renderer>().enabled = false;


                GameObject PackagePart6 = GameObject.Find("Top Tape Carry");
                PackagePart6.GetComponent<Renderer>().enabled = false;



                GameObject PackagePart7 = GameObject.Find("Right Tape Carry");
                PackagePart7.GetComponent<Renderer>().enabled = false;


                GameObject PackagePart8 = GameObject.Find("Left Tape Carry");
                PackagePart8.GetComponent<Renderer>().enabled = false;



                GameObject GateCover = GameObject.Find("Gate Cover");
                Destroy(GateCover);


            }
        }


            
    }
}
