using UnityEngine;
using System;
using Unity.Netcode;
public class GroundPlayerController : NetworkBehaviour
{
    // public PlayerClass player_class;

    // public Unit unit // not sure what this does 

    // movement controls
    
    public float turnInput;
    public float moveInput;
    public Rigidbody playerRB;
    [SerializeField] LayerMask layermask;
    
    
    [Header("References")]
    private CharacterController controller;
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float shipFrontX = 42.5f;
    [SerializeField] private float shipBackX = 9.7f;
    [SerializeField] private float shipLeftSideZ = 50f;
    [SerializeField] private float shipRightSideZ = 41.3f;
    [SerializeField] private GameObject player;

    public bool isAlive;


    private void OnEnable()
    {
     
    }
    private void OnDisable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.player = gameObject;
        controller = GetComponent<CharacterController>();
        isAlive = true;

    }
    // Update is called once per frame
    void Update()
    {
        // reads user input and creates direction
        // if (!IsOwner) return;
        checkPlayerInput();
        Movement();
    }
    private void checkPlayerInput()
    {
        if ((player.transform.position.x < shipFrontX) && (player.transform.position.x > shipBackX) && (player.transform.position.z < shipLeftSideZ) && (player.transform.position.z > shipRightSideZ))
        {
            moveInput = Input.GetAxis("Vertical");
            turnInput = Input.GetAxis("Horizontal");
        }
        else
        {
            moveInput = 0;
            turnInput = 0;
        }
    }
    private void GroundMovement()
    {
        
        Vector3 move = new Vector3(turnInput, 0, moveInput);
        
        move.y = 0;
        move *= moveSpeed;
        controller.Move(move * Time.deltaTime);
        //playerRB.angularVelocity = Vector3.zero;
    }
    private void Movement()
    {
        GroundMovement();
        Turn();
    }
    private void Turn()
    {
        if(MathF.Abs(turnInput) > 0 || Mathf.Abs(moveInput) > 0)
        {
            Vector3 currentLookDirection = controller.velocity.normalized;
            currentLookDirection.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        }
    }
 // old movement system
    // private void updateMoveDirection()
    // {
       
    //     moveDirection = playerControls.ReadValue<Vector3>();
    //     rb.velocity = moveDirection * moveSpeed; 
    // }
    
}