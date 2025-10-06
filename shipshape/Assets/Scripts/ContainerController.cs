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
    // void OnTriggerEnter(Collider other )
    // {
    //     if (other.gameObject.tag == "inventory" && !onShip)
    //     {
    //         rb.isKinematic = true;
    //         setOnShip(true);
    //         Debug.Log("container on ship");
    //     }
    // }
    public void setOnShip(bool state)
    {
        this.onShip = state;
    }
    public bool getOnShip()
    {
        return onShip;
    }
    private void checkStillOnShip()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 1f) && hit.collider.CompareTag("inventory"))
        {

            Debug.Log("Container still on the ship");

        }
        else
        {
            Debug.Log("Container removed from on the ship");
        }
    }
}