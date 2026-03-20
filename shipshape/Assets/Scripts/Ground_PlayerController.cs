using UnityEngine;
using System;
using Unity.Netcode;
using TMPro;
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
    public bool isAlive;
    [SerializeField] public Animator animator;
    

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
        animator = GetComponentInChildren<Animator>(true);
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
       
            moveInput = Input.GetAxis("Vertical");
            turnInput = Input.GetAxis("Horizontal");
    }
    private void GroundMovement()
    {
        
        Vector3 move = new Vector3(turnInput, 0, moveInput);
        move.y = 0;
        move *= moveSpeed;
        if(move == Vector3.zero)
        {
            animator.SetTrigger("Still");
        }
        else
        {
            
            animator.SetTrigger("Moving");
        }
        controller.Move(move * Time.deltaTime);

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
    
}