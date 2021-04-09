using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerManager : MonoBehaviour
{
    [SerializeField]
    GameObject customerPrefab;
    [SerializeField]
    Transform customerSpawnPoint;
    [SerializeField]
    Transform customerFinalDestination;


    List<GameObject> listOfCustomers;



    // Start is called before the first frame update
    void Start()
    {
        listOfCustomers = new List<GameObject>();
        SpawnCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCustomer() {
        GameObject newCustomer = Instantiate(customerPrefab, customerSpawnPoint);
        listOfCustomers.Add(newCustomer);
        newCustomer.name = "Customer" + listOfCustomers.Count;
        newCustomer.GetComponent<NavMeshAgent>().SetDestination(customerFinalDestination.position - new Vector3((listOfCustomers.Count - 1) * 2, 0, 0));
    }
}
