using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemInHand
{
    EMPTY,
    RAW_STEAK,
    COOKED_STEAK,
    PLATE
}

public class ItemInHandDatabase : MonoBehaviour
{
    public static Dictionary<ItemInHand, GameObject> itemInHandToGameObjectDictionary;
    
    private static Dictionary<ItemInHand, ItemInHand> rawFoodToCookedFoodDictionary;

    [SerializeField] GameObject rawSteak;
    [SerializeField] GameObject cookedSteak;

    // Start is called before the first frame update
    void Start()
    {
        InitializeItemInHandToGameObjectDictionary();
        rawFoodToCookedFoodDictionary = new Dictionary<ItemInHand, ItemInHand>();

        rawFoodToCookedFoodDictionary[ItemInHand.RAW_STEAK] = ItemInHand.COOKED_STEAK;
    }

    void InitializeItemInHandToGameObjectDictionary() {
        itemInHandToGameObjectDictionary = new Dictionary<ItemInHand, GameObject>();

        itemInHandToGameObjectDictionary[ItemInHand.EMPTY] = null;
        itemInHandToGameObjectDictionary[ItemInHand.RAW_STEAK] = rawSteak;
        itemInHandToGameObjectDictionary[ItemInHand.COOKED_STEAK] = cookedSteak;
    }

    public static ItemInHand GetCookedVersion(ItemInHand uncookedFood) {
        return rawFoodToCookedFoodDictionary[uncookedFood];
    }

    public static bool IsCookedFood(ItemInHand food) {
        return rawFoodToCookedFoodDictionary.ContainsValue(food);
    }
}
