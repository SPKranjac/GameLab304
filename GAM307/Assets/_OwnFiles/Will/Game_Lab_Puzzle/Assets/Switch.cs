using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject Interact_Prompt;

    public bool IsSwitchFlipped = false;
    public bool IsDoorActivated = false;

    public Animator SwitchFlip;
    public Animator DoorOpen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Interact_Prompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Interact_Prompt.SetActive(false);
                SwitchOn();
                DoorActivated();
            }
        }
    }

    public void SwitchOn()
    {
        if(IsSwitchFlipped == false)
        {
            IsSwitchFlipped = true;
            SwitchFlip.SetBool("IsSwitchFlipped", true);
        }
        else
        {
            IsSwitchFlipped = false;
            SwitchFlip.SetBool("IsSwitchFlipped", false);
        }
        Debug.Log("Switch");
    }

    public void DoorActivated()
    {
        if (IsDoorActivated == false)
        {
            IsDoorActivated = true;
            DoorOpen.SetBool("IsDoorActivated", true);
        }
        else
        {
            IsDoorActivated = false;
            DoorOpen.SetBool("IsDoorActivated", false);
        }
        Debug.Log("Door");
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Interact_Prompt.SetActive(false);
        }
    }
}
