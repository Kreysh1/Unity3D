using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    public Vector3 camUp;


    public float horizontalMove;
    public float verticalMove;
    public float flyMove;

    private Vector3 playerInput;
    private Vector3 movePlayer;

    private float speed;
    [Range(10,15)] public float minSpeed;
    [Range(16, 25)] public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walk/Run Inputs
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        flyMove = Input.GetAxis("Fly");


        // Magic
        playerInput = new Vector3(horizontalMove, flyMove, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward + playerInput.y * transform.up;

        controller.Move(movePlayer * speed * Time.deltaTime);

        if (Input.GetButton("Run"))
        {
            speed = maxSpeed;
        }
        else
        {
            speed = minSpeed;
        }

    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;
        camUp = mainCamera.transform.up;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
        camUp = camUp.normalized;
    }
}
