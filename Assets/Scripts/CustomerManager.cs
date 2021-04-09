using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour
{
    public UnityEvent onFoodDeliverySuccess;

    [SerializeField]
    GameObject customerPrefab;
    [SerializeField]
    Transform customerSpawnPoint;
    [SerializeField]
    Transform customerFinalDestination;

    [SerializeField]
    float customerSpawnRate;

    [SerializeField]
    int customerMaximumCount;

    [SerializeField]
    Sprite happyFace;

    [SerializeField]
    Sprite angryFace;

    List<GameObject> listOfCustomers;



    // Start is called before the first frame update
    void Start()
    {
        listOfCustomers = new List<GameObject>();
        StartCoroutine(SpawnCustomers());
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
                customer.GetComponent<Customer>().WantedFoodImage = happyFace;
                listOfCustomers.Remove(customer);
                StartCoroutine(ShiftCustomerPositions());
                return;
            }
        }
    }

    IEnumerator SpawnCustomers() {
        while (true) {
            yield return new WaitForSeconds(customerSpawnRate);
            if (listOfCustomers.Count < customerMaximumCount) {
                SpawnCustomer();
            }
            else {
                yield return new WaitUntil(() => listOfCustomers.Count < customerMaximumCount);
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
