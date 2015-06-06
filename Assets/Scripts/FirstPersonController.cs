using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float mouseSensivity = 2.0f;
    
    public float UpAndDownRange = 60.0f;
    private float verticalRotation = 0f;

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
        //Rotation
        float rotLeftandRight = Input.GetAxis("Mouse X") * mouseSensivity;
        transform.Rotate(0, rotLeftandRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -UpAndDownRange, UpAndDownRange);
        
        Camera.main.transform.rotation = Quaternion.Euler(verticalRotation, 0, 0);
        
        //Movement
        float horizontalSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        float verticalSpeed = Input.GetAxis("Vertical") * movementSpeed;
        Vector3 speed = new Vector3(horizontalSpeed, 0, verticalSpeed);

        speed = transform.rotation * speed;

        CharacterController cc = GetComponent<CharacterController>();
        cc.SimpleMove(speed);
	}
}
