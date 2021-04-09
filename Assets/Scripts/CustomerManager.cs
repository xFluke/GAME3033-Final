using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CustomerManager : MonoBehaviour
{
    public UnityEvent onFoodDeliverySuccess;

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
        SpawnCustomer();
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
        newCustomer.GetComponent<NavMeshAgent>().SetDestination(customerFinalDestination.position - new Vector3((listOfCustomers.IndexOf(newCustomer)) * 2, 0, 0));
    }

    public void DeliverFood(ItemInHand deliveringFood) {
        foreach (GameObject customer in listOfCustomers) {
            if (deliveringFood == customer.GetComponent<Customer>().WantedFood) {
                onFoodDeliverySuccess.Invoke();
                customer.GetComponent<NavMeshAgent>().SetDestination(customer.transform.position + new Vector3(0, 0, 20));
                listOfCustomers.Remove(customer);
                StartCoroutine(ShiftCustomerPositions());
                return;
            }
        }
    }

    IEnumerator ShiftCustomerPositions() {
        yield return new WaitForSeconds(2f);
        foreach (GameObject customer in listOfCustomers) {
            customer.GetComponent<NavMeshAgent>().SetDestination(customerFinalDestination.position - new Vector3((listOfCustomers.IndexOf(customer)) * 2, 0, 0));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
