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
    Transform CameraT;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        CameraT = Camera.main.transform;
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
    }
}
