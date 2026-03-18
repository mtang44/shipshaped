using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
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

    }
    // Update is called once per frame
    void Update()
    {
        // reads user input and creates direction
        if (!IsOwner) return;
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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("LAYER = " + collision.gameObject.layer);
    //    if (collision.gameObject.layer == 3)
    //    {
    //        Debug.Log("HIT PLAYER");
    //        collision.gameObject.GetComponent<ContainerController>().checkStillOnShip();
    //        bool isActive = collision.gameObject.GetComponent<ContainerController>().onShip;

    //        if (isActive)
    //        {
    //            Destroy(this);
    //        }
    //    }
    //}
    // old movement system
    // private void updateMoveDirection()
    // {

    //     moveDirection = playerControls.ReadValue<Vector3>();
    //     rb.velocity = moveDirection * moveSpeed; 
    // }

}