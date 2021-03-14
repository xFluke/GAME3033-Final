using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ApplianceType
{
    ItemSpawner,
    ItemCooker
}

public class Appliance : MonoBehaviour
{
    [SerializeField] ApplianceType applianceType;
    public ApplianceType ApplianceType { get { return applianceType; } }


    [SerializeField] ItemInHand requiredItem;
    public ItemInHand RequiredItem { get { return requiredItem; } }

    [SerializeField] ItemInHand itemToGive;

    public ItemInHand ItemToGive {  get { return itemToGive; } }

    [SerializeField] bool interactable;

    public bool Interactable {  get { return interactable; } }

    [SerializeField] Transform foodSpawnPoint;
    [SerializeField] GameObject smokeParticles;

    private bool justCooked = false;
    public bool JustCooked { get { return justCooked; } set { justCooked = value; } }

    public void Cook(ItemInHand foodToCook) {
        StartCoroutine(CookFood(foodToCook));
    }

    IEnumerator CookFood(ItemInHand foodToCook) {
        interactable = false;
        smokeParticles.SetActive(true);

        GameObject food = Instantiate(ItemInHandDatabase.itemInHandToGameObjectDictionary[foodToCook], foodSpawnPoint);
        food.transform.localScale = new Vector3(10f, 10f, 10f);

        yield return new WaitForSeconds(3f);

        interactable = true;
        smokeParticles.SetActive(false);
        requiredItem = ItemInHand.EMPTY;

        Destroy(food.gameObject);
        Debug.Log(foodToCook);
        GameObject cookedFood = Instantiate(ItemInHandDatabase.itemInHandToGameObjectDictionary[ItemInHandDatabase.GetCookedVersion(foodToCook)], foodSpawnPoint);
        cookedFood.transform.localScale = new Vector3(10f, 10f, 10f);
        justCooked = true;
    }

    public void Reset() {
        justCooked = false;
        Destroy(foodSpawnPoint.GetChild(0).gameObject);
    }
}
