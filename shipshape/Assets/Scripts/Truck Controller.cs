using UnityEngine;

public class TruckController : MonoBehaviour
{
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
        if(transform.position.x <= 25)
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
        if(transform.position.x < 70)
        {
            MoveTruck();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
