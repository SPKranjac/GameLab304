using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    public Transform onHand;

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

}
