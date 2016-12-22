using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float jumpSpeed;
	// Use this for initialization
	void Start ()
    {
	
	}
	
    void MovePlayer()
    {
        float moveHorizontal, moveVertical, jump;
        Vector3 movement;

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");

        movement = new Vector3(moveHorizontal, jump * jumpSpeed, moveVertical);
    }

	// Update is called once per frame
	void Update ()
    {
	
	}
}
