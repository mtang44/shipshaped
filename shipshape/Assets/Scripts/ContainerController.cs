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
            rb.linearVelocity = Vector3.zero;
           // rb.isKinematic = true;
            Debug.Log("container detected ship");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("LAYER = " + collision.gameObject.layer);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("HIT PLAYER");

            if (onShip == false)
            {
                Destroy(collision.gameObject);
            }
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
    public void checkStillOnShip()
    {
        Debug.DrawRay(transform.position,Vector3.down,Color.green, .1f);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, .1f) && (hit.collider.CompareTag("Ship") || hit.collider.CompareTag("inventory")))
        {
            //Debug.Log("Container still on the ship");
            setOnShip(true);
        }
        else
        {
            //Debug.Log("Container removed from ship");
            //setOnShip(false);
            
            rb.isKinematic = false;
        }
    }
}