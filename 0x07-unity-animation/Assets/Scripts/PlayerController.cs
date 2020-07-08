using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController player;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    //Transform CameraT;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        //CameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");


        if (player.isGrounded)
        {
            moveDirection = new Vector3(MoveX, 0f, MoveY);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                animator.SetTrigger("Jump");
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        // Move the controller
        player.Move(moveDirection * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(0f, 20f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
        */

    }
}
