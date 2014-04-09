using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;

	// Update is called once per frame
	void Update () {
	
	}

    // FixedUpdate is called before physics updates
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce(movement * speed * Time.deltaTime);
    }
}
