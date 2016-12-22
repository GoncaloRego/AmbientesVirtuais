using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Transform playerTransform;
    Animator animation;
    public float jumpSpeed;
    public float speed;
	// Use this for initialization
	void Start ()
    {
        animation = GetComponent<Animator>();

        playerRigidBody = GetComponent<Rigidbody>();
        playerTransform = transform;
	}
	
    void MovePlayer()
    {
        float moveHorizontal, moveVertical, jump;
        Vector3 movement;

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");

        movement = new Vector3(moveHorizontal, jump * jumpSpeed, moveVertical);
        playerTransform.position += movement * Time.deltaTime * speed;

        animation.Play("Basic_Walk_01_Root");
    }

	// Update is called once per frame
	void Update ()
    {
        MovePlayer();
	}
}
