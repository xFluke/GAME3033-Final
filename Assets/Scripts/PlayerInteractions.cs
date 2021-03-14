using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInteractions : MonoBehaviour
{
    public UnityEvent<ItemInHand> onItemInHandChange;

    [SerializeField] private ItemInHand itemInHand;
    public ItemInHand ItemInHand {
        get { return itemInHand; }
    }

    private bool inRangeOfAppliance = false;
    private bool inRangeOfCounter = false;
    private Appliance applianceInteractingWith;

    // Start is called before the first frame update
    void Start()
    {
        itemInHand = ItemInHand.EMPTY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log(other.name);
        if (other.transform.parent.CompareTag("Appliance")) {
            inRangeOfAppliance = true;
            applianceInteractingWith = other.transform.parent.GetComponent<Appliance>();
        }
        //else if (other.transform.parent.CompareTag("Counter")) {
        //    inRangeOfCounter = true;
        //}
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Appliance")) {
            inRangeOfAppliance = false;
            applianceInteractingWith = null;
        }
        //else if (other.transform.parent.CompareTag("Counter")) {
        //    inRangeOfCounter = false;
        //}
    }

    public void OnInteract(InputValue value) {
        if (value.isPressed && inRangeOfAppliance) {
            if (InteractionValid()) {
                if (applianceInteractingWith.ApplianceType == ApplianceType.ItemSpawner) {
                    itemInHand = applianceInteractingWith.ItemToGive;
                    onItemInHandChange.Invoke(itemInHand);
                }
                else if (applianceInteractingWith.ApplianceType == ApplianceType.ItemCooker) {
                    // Interacting with empty ItemCooker
                    if (!applianceInteractingWith.JustCooked) {
                        applianceInteractingWith.Cook(itemInHand);

                        itemInHand = ItemInHand.EMPTY;
                        onItemInHandChange.Invoke(itemInHand);
                    } // Interacting with ItemCooker that already finished cooking
                    else {
                        applianceInteractingWith.Reset();

                        itemInHand = applianceInteractingWith.ItemToGive;
                        onItemInHandChange.Invoke(ItemInHand);
                    }
                    
                }
            }
        }
    }

    bool InteractionValid() {
        if (!applianceInteractingWith.Interactable)
            return false;

        Debug.Log("Required Item: " + applianceInteractingWith.RequiredItem);

        Debug.Log("My Item: " + itemInHand);

        return applianceInteractingWith.RequiredItem == itemInHand;
    }
}
