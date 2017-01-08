using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Transform playerTransform;
    Animator animation;
    public float jumpSpeed;
    public float speed;
    public float gravity;
    public float rotationSpeed;
    public float runSpeed;
    bool isMoving;
    bool isRunning;
    bool isAttacking;
    Vector3 rotate;


    void Start ()
    {
        animation = GetComponent<Animator>();

        playerRigidBody = GetComponent<Rigidbody>();
        playerTransform = transform;

        isMoving = false;
        isRunning = false;
        isAttacking = false;

        rotate = Vector3.zero;
	}
	
    void MovePlayer()
    {
        float moveHorizontal, moveVertical, jump;
        Vector3 movement = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            playerTransform.Translate(Vector3.forward * speed * Time.deltaTime);
            isMoving = true;
        }

        if(Input.GetKey(KeyCode.S))
        {
            playerTransform.Translate(Vector3.back * speed * Time.deltaTime);
            isMoving = true;
        }

        if(Input.GetKey(KeyCode.A))
        {
            playerTransform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            playerTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        /*moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
        speed = 0.3f;

        //Player Rotation
        rotate = new Vector3(0.0f, moveHorizontal, 0.0f);
        playerTransform.Rotate(rotate * rotationSpeed * Time.deltaTime);

        rotate = new Vector3(0.0f, 0.0f, moveVertical);
        playerTransform.Translate(rotate * speed * Time.deltaTime);


        movement = new Vector3(moveHorizontal, jump * jumpSpeed, moveVertical);
        playerTransform.position += movement * Time.deltaTime * speed;*/

        if(Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = false;
            isRunning = false;
            isAttacking = true;
            Attack();
        }
    }

    void Run()
    {
        isMoving = false;

        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            isRunning = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.Translate(Vector3.back * runSpeed * Time.deltaTime);
            isRunning = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        /*float moveHorizontal, moveVertical, jump, runSpeed = 1f;
        Vector3 movement;

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");

        movement = new Vector3(moveHorizontal, jump * jumpSpeed, moveVertical);
        playerTransform.position += movement * runSpeed * Time.deltaTime;

        if(movement != Vector3.zero)
        {
            isRunning = true;
        }

        else
        {
            isRunning = false;
        }*/
    }

    void animationControl()
    {

        if (isMoving == true)
        {
            animation.SetBool("andar", true);
        }

        else
        {
            animation.SetBool("andar", false);
        }

        if(isRunning == true)
        {
            animation.SetBool("correr", true);
            isRunning = false;
        }

        else
        {
            animation.SetBool("correr", false);
        }

        if(isAttacking == true)
        {
            animation.SetBool("atacar", true);
            isAttacking = false;
        }

        else
        {
            animation.SetBool("atacar", false);
        }
        /*
        animation.ResetTrigger("Idle");
        animation.ResetTrigger("Walk");
        animation.ResetTrigger("Run");
        if (isMoving == false && isRunning == false)
        {
            animation.SetTrigger("Idle");
            //animation.Play("Idle");
        }

        else if(isMoving == true)
        {
            animation.SetTrigger("Walk");
            //animation.Play("Walk");
        }

        else if(isRunning == true)
        {
            animation.SetTrigger("Run");
            //animation.Play("Run");
        }
        */
    }

    void Attack()
    {
        
    }

	void Update ()
    {
        MovePlayer();
        animationControl();
	}
}
