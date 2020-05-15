using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp2 : MonoBehaviour
{
    public Transform destination;
    // Use this for initialization
    void Start()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.transform.position = destination.position;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}