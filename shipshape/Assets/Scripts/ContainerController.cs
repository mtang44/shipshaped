using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour
{
    public bool onShip;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        onShip = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onShip)
        {
            checkStillOnShip();
        }
    }
    void OnTriggerEnter(Collider other )
    {
        if (other.gameObject.tag == "inventory" && !onShip)
        {
            rb.velocity = Vector3.zero;
           // rb.isKinematic = true;
            Debug.Log("container detected ship");
        }
    }
    public void setOnShip(bool state)
    {
        this.onShip = state;
    }
    public bool getOnShip()
    {
        return this.onShip;
    }
    private void checkStillOnShip()
    {
        Debug.DrawRay(transform.position,Vector3.down,Color.green, .1f);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, .1f) && (hit.collider.CompareTag("Ship") || hit.collider.CompareTag("inventory")))
        {
            Debug.Log("Container still on the ship");
            setOnShip(true);
        }
        else
        {
            Debug.Log("Container removed from ship");
            //setOnShip(false);
            
            rb.isKinematic = false;
        }
    }
}