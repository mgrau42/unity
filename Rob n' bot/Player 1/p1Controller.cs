using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Controller : MonoBehaviour
{
	// speed at which the player will move.
	// [SerializeField] can be used to edit the initial value of a variable from the editor.
	// It can also be public, but that makes it accessible and modifiable by other classes.
	[SerializeField] float speed = 10;
	public bool playerBall = false;
	public int cdType;
	public SpriteRenderer playerRenderer;
	public Sprite BaseSprite;

	// Animator component of the player's sprite, responsible for handling animations
	// [SerializeField] Animator myAnimator = null;

	// Update is a function that Unity will call once per frame.
    void FixedUpdate()
    {
		Movement();
    }

	/* Here I handle the player's movement */
	void Movement()
	{
		// vector, by default set to zero, which we will modify based on input
		Vector3 direction = Vector3.zero;

		// Input.GetKey() returns true or false if the specified key is being pressed
		if (Input.GetKey(KeyCode.D))
			direction.x += 1;
		if (Input.GetKey(KeyCode.A))
			direction.x -= 1;
		transform.position += direction.normalized * speed * Time.deltaTime;
	}
}
