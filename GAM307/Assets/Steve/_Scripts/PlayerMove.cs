using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed = 6;
    [SerializeField] private float sprintSpeed;

    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;

    private bool isJumping;

    public bool isCrouching = false;


    private bool isSprinting;

    private float originalHeight;

    [SerializeField] private float charHeightCrouch = 0.5f;

    

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        originalHeight = charController.height;
                 
    }


    private void Update()
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            StartCrouch();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            EndCrouch();
        }




        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartSprint();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopSprint();
        }
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

         do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

    private void StartCrouch()
    {
        if (isCrouching == true)
        {
            charController.height = charHeightCrouch;
            Debug.Log(" Crouching ");
        }
    }

    private void EndCrouch()
    {
        if (isCrouching == false)
        {
            charController.height = originalHeight;
            Debug.Log(" Standing ");
        }
    }          


    private void StartSprint()
    {
        Debug.Log(" Sprinting ");
        isSprinting = true;
        movementSpeed = sprintSpeed;
    }

    private void StopSprint()
    {
        Debug.Log(" Walking ");
        isSprinting = false;
        movementSpeed = 6;
    }
}
