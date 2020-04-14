using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    public Transform onHand;

    public Flashlight flashlight;
    public GameObject Pickup_Prompt;

    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position =
            onHand.transform.position;
        this.transform.parent =
            GameObject.Find("FirstPersonPlayer").transform;
        
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }



    public void Pickup()
    {
        Destroy(gameObject);
        flashlight.PickUp();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "FirstPersonPlayer")
        {
            Pickup_Prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pickup();
                Pickup_Prompt.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "FirstPersonPlayer")
        {
            Pickup_Prompt.SetActive(false);
        }
    }
}
