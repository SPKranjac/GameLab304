using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    bool isOpened = false;



    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Key") 

        if (!isOpened)
        {
            isOpened = true;
            door.transform.position += new Vector3(0, 25, 0);
        }

        

    }
}
