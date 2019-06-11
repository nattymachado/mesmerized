﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleInventoryController : Singleton<CollectibleInventoryController>
{
    //Refence Variables
    [Header("Required References")]
    public GameObject[] specialSlots;
    public InventoryCenterBehaviour inventoryCenter;
    public InventoryObjectBehaviour specialItem;

    //Control Variables
    [Header("Control Variables")]
    public int totalSpecialSlots = 3;
    private int currentSlot = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        //Disable Extra Slots
        for(int i = totalSpecialSlots; i < 3; i++)
        {
            specialSlots[i].SetActive(false);
        }
    }

    public Vector2 GetNextVacantSlotScreenPosition()
    {
        return specialSlots[currentSlot].transform.position;
    }

    public void AddItem(Sprite imageSprite)
    {
        Debug.Log("Add Item");
        Image imageRef = specialSlots[currentSlot].transform.GetChild(0).GetComponent<Image>();
        imageRef.sprite = imageSprite;
        imageRef.enabled = true;
        currentSlot++;
        if (currentSlot == totalSpecialSlots)
        {
            StartCoroutine(WaitToGetSpecialItem(0f));   
        }
    }

    IEnumerator WaitToGetSpecialItem(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameEvents.UIEvents.TriggerItemsJoinAnimation.SafeInvoke();
        StartCoroutine(WaitToStartSpecialItemAnimation(1f));
    }

    IEnumerator WaitToStartSpecialItemAnimation(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        inventoryCenter.AddNewItem(specialItem);
    }
}