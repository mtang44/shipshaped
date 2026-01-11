using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.Callbacks;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
public class GroundPlayerController : MonoBehaviour
{
    // public PlayerClass player_class;

    // public Unit unit // not sure what this does 

    // movement controls
    public float moveSpeed = 5f;
    public InputAction playerControls;
    public Rigidbody rb;
    [SerializeField] LayerMask layermask;
    Vector3 moveDirection = Vector3.zero;
    
    


    private void OnEnable()
    {
        playerControls.Enable();
    
       
    }
    private void OnDisable()
    {
        playerControls.Disable();
      
    }
    // Start is called before the first frame update
    void Start()
    {
 
        GameManager.Instance.player = gameObject;
   
        
    }
    // Update is called once per frame
    void Update()
    {
        // reads user input and creates direction
        checkPlayerInput();
    }
    private void checkPlayerInput()
    {
        updateMoveDirection();
        
    }

    private void updateMoveDirection()
    {
         moveDirection = playerControls.ReadValue<Vector3>();
        rb.velocity = moveDirection * moveSpeed; 
    }
}