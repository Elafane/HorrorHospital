using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float mouseSensivity = 2.0f;
    public float jumpSpeed = 8.0f;
    
    public float UpAndDownRange = 60.0f;
    private float verticalRotation = 0f;

    private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();

        //Rotation
        float rotLeftandRight = Input.GetAxis("Mouse X") * mouseSensivity;
        transform.Rotate(0, rotLeftandRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -UpAndDownRange, UpAndDownRange);
        
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        
        //Movement
        if(controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= movementSpeed;
        }
        //Jump
        if (Input.GetButtonDown("Jump"))
            moveDirection.y = jumpSpeed; 

        // Apply gravity
        moveDirection.y -= 20f * Time.deltaTime;
        
        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);

        
	}
}
