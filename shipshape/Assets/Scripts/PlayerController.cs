using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.Callbacks;
public class NewBehaviourScript : MonoBehaviour
{
    // public PLayerClass player_cass; add this once player class added

    // public Unit unit // not sure what this does 

    // movement controls
    public float moveSpeed = 5f;
    public InputAction playerControls;
    public Rigidbody rb;

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

    public void StartLevel()
    {
        
    }
    public void NextWave()
    {

    }


    // Update is called once per frame
    void Update()
    {
        // reads user input and creates direction
        moveDirection = playerControls.ReadValue<Vector3>();
        rb.velocity = new Vector3(x: moveDirection.x * moveSpeed, y: moveDirection.y * moveSpeed, z: moveDirection.z * moveSpeed);
        
        
    }
}
