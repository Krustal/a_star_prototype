using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

    public float speed;
    public CharacterController controller;

    public AnimationClip run;
    public AnimationClip idle;

    private Vector3 position;

	// Use this for initialization
	void Start () {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButton(0)) // left mouse button
        {
            // locate where the player clicked on the terrain
            locatePosition();
     
        }

        // Move player to position
        moveToPosition();
	}

    void locatePosition()
    {
        RaycastHit hit;
        // cast ray from camera to mouse position.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Debug.Log(position);
        }
    }

    void moveToPosition()
    {
        if (Vector3.Distance(transform.position, position) > 1)
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);

            newRotation.x = 0f;
            newRotation.z = 0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward * speed);

            animation.CrossFade(run.name);
        } else
        {
            animation.CrossFade(idle.name);
        }
    }
}
