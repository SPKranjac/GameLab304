using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingKeyu : MonoBehaviour
{
    public GameObject shelf;

    // Start is called before the first frame update
    void Start()
    {

    }

    //void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.gameobject.tag == "Ball")
    //    {

    //        Destroy(shelf);
    //    }
    //}


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Debug.Log(" ball in ");
            Destroy(shelf);
        }
    }
}
