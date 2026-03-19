using UnityEngine;

public class Truck_Spawner : MonoBehaviour
{
 [SerializeField] private GameObject[] truckPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) || GetComponentInChildren<Truck_Controller>() == null)
        {
           SpawnNewTruck(); 
        }
        
    }
    void SpawnNewTruck()
    {
        System.Random random = new System.Random();
        int index = random.Next(truckPrefabs.Length);
        var newTruck =  Instantiate(truckPrefabs[index],transform.position, Quaternion.Euler(0, 90, 0));
        newTruck.transform.parent = gameObject.transform;
    }
}
