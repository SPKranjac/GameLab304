using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animation hingehere;

   void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
            hingehere.Play();
    }


}
