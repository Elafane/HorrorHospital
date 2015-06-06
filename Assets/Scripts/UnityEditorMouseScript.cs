using UnityEngine;
using System.Collections;

public class UnityEditorMouseScript : MonoBehaviour {

    bool cursorLocked;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorLocked = true;
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (Input.GetButtonDown("Cancel"))
		{
            if (Application.isEditor)
            {
                if (cursorLocked)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    cursorLocked = false;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    cursorLocked = true;
                }
            }
		}
	}



}
