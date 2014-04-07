using UnityEngine;
using System.Collections;
using Prototype;

public class UserInput : MonoBehaviour 
{

	private Player player;

	// Use this for initialization
	void Start () 
	{
		// gets the Player parent object from the scene
		player = transform.root.GetComponent< Player > ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.human) {
			MoveCamera ();
			RotateCamera ();
		}
	}

	private void MoveCamera()
	{
		float xpos = Input.mousePosition.x;
		float ypos = Input.mousePosition.y;
		Vector3 movement = new Vector3 (0, 0, 0);

		// horizontal camera movement
		if (xpos >= 0 && xpos < ResourceManager.ScrollWidth) 
		{
			// move left
			movement.x -= ResourceManager.ScrollSpeed;
		} else if (xpos <= Screen.width && xpos > Screen.width - ResourceManager.ScrollWidth) 
		{
			// move right
			movement.x += ResourceManager.ScrollSpeed;
		}

		// vertical camera movement
		if (ypos >= 0 && ypos < ResourceManager.ScrollWidth) {
			// move up
			movement.y -= ResourceManager.ScrollSpeed;
		} else if (ypos <= Screen.height && ypos > Screen.height - ResourceManager.ScrollWidth) {
			// move down
			movement.y += ResourceManager.ScrollSpeed;
		}

		// make sure movement is in the direction the camera is pointing
		// but ignore the vertical tilt of the camera to get sensible scrolling.
		movement = Camera.mainCamera.transform.TransformDirection (movement); // treats x and y as the axis from camera perspective
		movement.y = 0;

		// away from the movement ground
		movement.y -= ResourceManager.ScrollSpeed * Input.GetAxis ("Mouse ScrollWheel");

        // calculate desired camera position based on received input
        Vector3 origin = Camera.mainCamera.transform.position;
        Vector3 destination = origin;
        destination.x += movement.x;
        destination.y += movement.y;
        destination.z += movement.z;

        // limit away from ground movement to be between a minimum and a maximum
		if (destination.y > ResourceManager.MaxCameraHeight) {
			destination.y = ResourceManager.MaxCameraHeight;
		} else if (destination.y < ResourceManager.MinCameraHeight) {
			destination.y = ResourceManager.MinCameraHeight;
		}

        // if a change in position is detected perform the nessecary update
        if (destination != origin)
        {
            Camera.mainCamera.transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.ScrollSpeed);
        }
	}

	private void RotateCamera() 
	{

	}
}
