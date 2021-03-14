using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemInHandUpdater : MonoBehaviour
{
    [SerializeField] Transform itemSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerInteractions>().onItemInHandChange.AddListener(UpdateItemInHandGameObject);
    }

    void UpdateItemInHandGameObject(ItemInHand newItemInHand) {
        // Hand not empty
        if (itemSpawnPoint.childCount > 0) {
            Destroy(itemSpawnPoint.GetChild(0).gameObject);
        }

        if (!(newItemInHand == ItemInHand.EMPTY)) {
            // Hand empty
            

            GameObject food = Instantiate(ItemInHandDatabase.itemInHandToGameObjectDictionary[newItemInHand], itemSpawnPoint);
            food.transform.localScale = new Vector3(10f, 10f, 10f);
        }
    }
}
