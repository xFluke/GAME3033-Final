using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemInHand
{
    EMPTY,
    RAW_STEAK,
    COOKED_STEAK,
    RAW_SHRIMP,
    COOKED_SHRIMP,
    COUNT
}

public class ItemInHandDatabase : MonoBehaviour
{
    public static Dictionary<ItemInHand, GameObject> itemInHandToGameObjectDictionary;
    
    private static Dictionary<ItemInHand, ItemInHand> rawFoodToCookedFoodDictionary;

    [SerializeField] GameObject rawSteak;
    [SerializeField] GameObject cookedSteak;
    [SerializeField] GameObject rawShrimp;
    [SerializeField] GameObject cookedShrimp;

    // Start is called before the first frame update
    void Awake() {
        InitializeItemInHandToGameObjectDictionary();
        InitializeRawFoodToCookedFoodDictionary();
    }

    private static void InitializeRawFoodToCookedFoodDictionary() {
        rawFoodToCookedFoodDictionary = new Dictionary<ItemInHand, ItemInHand>();

        rawFoodToCookedFoodDictionary[ItemInHand.RAW_STEAK] = ItemInHand.COOKED_STEAK;
        rawFoodToCookedFoodDictionary[ItemInHand.RAW_SHRIMP] = ItemInHand.COOKED_SHRIMP;
    }

    void InitializeItemInHandToGameObjectDictionary() {
        itemInHandToGameObjectDictionary = new Dictionary<ItemInHand, GameObject>();

        itemInHandToGameObjectDictionary[ItemInHand.EMPTY] = null;
        itemInHandToGameObjectDictionary[ItemInHand.RAW_STEAK] = rawSteak;
        itemInHandToGameObjectDictionary[ItemInHand.COOKED_STEAK] = cookedSteak;
        itemInHandToGameObjectDictionary[ItemInHand.RAW_SHRIMP] = rawShrimp;
        itemInHandToGameObjectDictionary[ItemInHand.COOKED_SHRIMP] = cookedShrimp;
    }

    public static ItemInHand GetCookedVersion(ItemInHand uncookedFood) {
        return rawFoodToCookedFoodDictionary[uncookedFood];
    }

    public static bool IsCookedFood(ItemInHand food) {
        return rawFoodToCookedFoodDictionary.ContainsValue(food);
    }

    public static ItemInHand GetRandomFood() {
        
        ItemInHand randomFood = (ItemInHand)(Random.Range(0, (int)ItemInHand.COUNT));

        while (!rawFoodToCookedFoodDictionary.ContainsValue(randomFood)) {
            randomFood = (ItemInHand)(Random.Range(0, (int)ItemInHand.COUNT));
        }


        Debug.Log(randomFood);
        return randomFood;

    }
}
