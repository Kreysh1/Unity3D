using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    public float horizontalMove;
    public float verticalMove;
    public float flyMove;
    private Vector3 playerInput;
    
    public float speed;
    private Vector3 movePlayer;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 camUp;

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

        movePlayer = playerInput.x * camRight + playerInput.z * camForward + playerInput.y * camUp;

        controller.Move(movePlayer * speed * Time.deltaTime);

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
