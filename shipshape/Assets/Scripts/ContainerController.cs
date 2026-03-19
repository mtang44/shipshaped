
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ContainerController : MonoBehaviour
{
    public bool onShip;
    public Rigidbody rb;
    
    public List<GameObject> shipEdges;
    private Collider ownCollider;
    // Start is called before the first frame update
    void Start()
    {
        ownCollider = GetComponent<Collider>();
        onShip = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (onShip)
        // {
        //     checkStillOnShip();
        // }
    }
    void OnTriggerEnter(Collider other )
    {
        if (other.gameObject.tag == "inventory" && !onShip)
        {
            rb.linearVelocity = Vector3.zero;
           // rb.isKinematic = true;
            UnityEngine.Debug.Log("container detected ship");
        }
        if(other.gameObject.tag == "Boundary")
        {
            Physics.IgnoreCollision(ownCollider,other.gameObject.GetComponent<Collider>(), true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("HIT TAG: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Debug.Log("HIT PLAYER");
            if (onShip == false)
            {
                collision.gameObject.SetActive(false);
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
    private void checkStillOnShip()
    {
        UnityEngine.Debug.DrawRay(transform.position,Vector3.down,Color.green, .1f);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, .1f) && (hit.collider.CompareTag("Ship") || hit.collider.CompareTag("inventory")))
        {
            
           if(!onShip)
            {
                setOnShip(true);
            } 
        }
        else
        {
            UnityEngine.Debug.Log("Container removed from ship");
            if(onShip)
            {
                setOnShip(false);
            }
           
        }
    }
}