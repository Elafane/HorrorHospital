using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour {


    private Camera camera;
    float distance;
    bool grabbed = false;
    Vector3 targetPosition;

    void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Camera>();
	}
	
	void Update () {
        
        Vector3 viewPos = camera.WorldToViewportPoint(transform.parent.position);

        if(viewPos.x < 0.5 && viewPos.x > 0.3 || grabbed)
        {
            if (Input.GetKey(KeyCode.E))
            {
                /*float MouseH = Input.GetAxis("Horizontal");
                float MouseV = Input.GetAxis("Vertical");
                */
                // Get Position
                distance = Vector3.Distance(transform.parent.position, camera.transform.position);

                //transform.parent.RotateAround(camera.transform.position, new Vector3(MouseH, 0, MouseV), 80 * Time.deltaTime);

                targetPosition = camera.transform.forward * distance;

                transform.parent.position = Vector3.Lerp(transform.parent.position, targetPosition, 0.1f);

                grabbed = true;
            }
            else
                grabbed = false;
        }
	}
}
