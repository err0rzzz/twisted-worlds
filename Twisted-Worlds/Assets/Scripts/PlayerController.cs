using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	CharacterController characterController;

	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	private Vector2 moveDirection = Vector3.zero;

	void Start() {
		characterController = GetComponent<CharacterController>();
	}

	void Update() {
		if (characterController.isGrounded) {
			moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0.0f) * speed;

			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		} else {
			//This means the player is in the air, so only worry about the x axis and let the y axis do its thang
			moveDirection.x = Input.GetAxis("Horizontal") * speed;
		}

		//Apply gravity to the movement
		moveDirection.y -= gravity * Time.deltaTime;
		//Apply the movement itself
		characterController.Move(moveDirection * Time.deltaTime);
	}
}
