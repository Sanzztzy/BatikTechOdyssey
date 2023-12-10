using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableController : MonoBehaviour
{
   characterControler2D characterController;
   alatCharacterControl alatCharacter;
   InventoryController inventoryController;
   ToolbarController toolbarController;

    private void Awake(){

        characterController = GetComponent<characterControler2D>();
        alatCharacter = GetComponent<alatCharacterControl>();
        inventoryController = GetComponent<InventoryController>();
        toolbarController = GetComponent<ToolbarController>();
    }

    public void DisableControl(){
        characterController.enabled = false;
        alatCharacter.enabled = false;
        inventoryController.enabled = false;
        toolbarController.enabled = false;
    }

    public void EnableControl(){
        characterController.enabled = true;
        alatCharacter.enabled = true;
        inventoryController.enabled = true;
        toolbarController.enabled = true;
    }
}
