using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public GameObject door;

    public float doorRotateSpeed;
    float doorRotation = 0;

    
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        door.transform.rotation = Quaternion.Lerp(door.transform.rotation, Quaternion.AngleAxis(doorRotation, Vector3.up), 0.1f);
	}

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            float openDoor = Input.GetAxis("Mouse ScrollWheel");
            
            if(openDoor != 0)
            {
                doorRotation += openDoor * doorRotateSpeed;
            }

        }
    }

}
