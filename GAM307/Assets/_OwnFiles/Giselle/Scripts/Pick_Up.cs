using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    public Transform onHand;

    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = onHand.transform.position;
        transform.parent = GameObject.Find("Player").transform;

    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

}
