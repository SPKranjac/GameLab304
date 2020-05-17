﻿using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{

    public Transform Destination;
    public string TagList = "|Player|Enemy|Key|";

    // Use this for initialization
    void Start()
    {

    }


    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {

        if (TagList.Contains(string.Format("|{0}|", other.tag)))
        {

            other.transform.position = Destination.transform.position;
            other.transform.rotation = Destination.transform.rotation;
        }
    }
}
