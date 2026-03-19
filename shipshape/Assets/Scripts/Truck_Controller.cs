using UnityEngine;

public class Truck_Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
public float moveSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponentInChildren<ContainerController>() == null)
        {
            DespawnTruck();
        }
        if(transform.position.x <= 20)
        {
            MoveTruck();
        }
       
       
    }
    public void MoveTruck()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
       
    }
    public void DespawnTruck()
    {
        if(transform.position.x < 65)
        {
            MoveTruck();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
