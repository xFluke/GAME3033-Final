using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [SerializeField]
    ItemInHand wantedFood;
    public ItemInHand WantedFood { get { return wantedFood; } }

    [SerializeField]
    Image wantedFoodImage;

    // Start is called before the first frame update
    void Start()
    {
        wantedFood = ItemInHandDatabase.GetRandomFood();
        wantedFoodImage.sprite = (Sprite)Resources.Load(wantedFood.ToString());
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
