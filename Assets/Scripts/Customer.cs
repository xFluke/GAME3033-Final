using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField]
    ItemInHand wantedFood;

    // Start is called before the first frame update
    void Start()
    {
        wantedFood = ItemInHandDatabase.GetRandomFood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
