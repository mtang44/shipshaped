using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public List<GameObject> inventory;
    public int containerCount;
    // Start is called before the first frame update
    void Start()
    {
        containerCount = 0;
        inventory = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            
            ContainerController triggerContainer = other.GetComponent<ContainerController>();
            if (!triggerContainer.getOnShip())
            {
                inventory.Add(other.gameObject);
                 Debug.Log("container added to ship ");
                containerCount += 1;
                Debug.Log("# of container = " + containerCount);
                Debug.Log("onShip set to true");
                triggerContainer.setOnShip(true);
            }
            else Debug.Log("container already on ship");
        }
    }
    // void OnTriggerExit(Collider other)
    // {
    //     Debug.Log("ship detected exit collision");

    //     if (other.gameObject.layer == 3)
    //     {
    //         ContainerController currentContainerScript = other.GetComponentInParent<ContainerController>();
    //         if (currentContainerScript.getOnShip())
    //         {
    //             currentContainerScript.setOnShip(false);
    //             inventory.Remove(other.gameObject);

    //             Debug.Log("container was removed");
    //             Debug.Log("onShip set to false");
    //             containerCount -= 1;
    //             Debug.Log("# of containers = " + containerCount);
    //         }
    //     }
   // }

public void checkShipBalance()
    {

    }
}
