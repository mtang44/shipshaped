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
public class NewBehaviourScript : MonoBehaviour
{
    // public PLayerClass player_cass; add this once player class added

    // public Unit unit // not sure what this does 

    // movement controls
    public float moveSpeed = 5f;
    public InputAction playerControls;
    public InputAction grabContainer;
    public Rigidbody rb;
    public GameObject selectedContainer;
    public bool holdingContainer;
    public Camera BottomCamera;
    public Camera ThirdPOVCamera;
    [SerializeField] LayerMask layermask;
    Vector3 moveDirection = Vector3.zero;
    Vector3 thirdpov;
    Vector3 firstpov;


    private void OnEnable()
    {
        playerControls.Enable();
        grabContainer.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
        grabContainer.Disable();

    }
    // Start is called before the first frame update
    void Start()
    {
        holdingContainer = false;
        GameManager.Instance.player = gameObject;
        firstpov = new Vector3(x: 5, y: 5, z: 10);
        thirdpov = new Vector3(x: 0, y: 4, z: -7);
        showOverHeadView();
        


        // sideCamera.enabled = false;


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
        checkClawGrab();
    }
    // detects when player attempts to pick up container;
    private void checkClawGrab()
    {
        if (grabContainer.WasPressedThisFrame() && !holdingContainer)
        {
            // creates a raycast from the bottom of the player claw and checks for container
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hitinfo, 2f, layermask))
            {
                Debug.Log("Picked up a container");
                // code to pick up container
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down)* hitinfo.distance,Color.green, 10f);
                showSideView();
                holdingContainer = true;
                selectedContainer = hitinfo.rigidbody.gameObject;
               
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down)* 3,Color.red, 10f);
                Debug.Log("Not touching");
            }


        }
        else if (grabContainer.WasPressedThisFrame() && holdingContainer)
        {
            // drop container code 
            showOverHeadView();
            holdingContainer = false;
            
            //
        }

    }
    private void updateMoveDirection()
    {
        moveDirection = playerControls.ReadValue<Vector3>();
        rb.velocity = new Vector3(x: moveDirection.x * moveSpeed, y: moveDirection.y * moveSpeed, z: moveDirection.z * moveSpeed);
        if (holdingContainer)
        {
            selectedContainer.transform.position = new Vector3(x: transform.position.x, y: transform.position.y - 3, z: transform.position.z);
        }
    }
    public void showOverHeadView()
    {
        Debug.Log("switching cam to top");
        BottomCamera.enabled = true;
        ThirdPOVCamera.enabled = false;
       // MainCamera.transform.position = firstpov;
    }
    public void showSideView()
    {
        Debug.Log("switching cam to side");
        ThirdPOVCamera.enabled = true;
        BottomCamera.enabled = false;
       // MainCamera.transform.position = thirdpov;
    }
    
}
