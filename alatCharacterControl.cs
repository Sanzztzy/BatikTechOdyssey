using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class alatCharacterControl : MonoBehaviour
{
    characterControler2D mc;
    character c;
    Rigidbody2D rgbd2d;
    ToolbarController toolbarController;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;   
    AttackController attackController;
    [SerializeField] int weaponEnergyCost = 10;
     [SerializeField] AudioClip onOpenedAudio;
    Animator animator;
    
     
    private void Awake(){
        c = GetComponent<character>();
        mc = GetComponent<characterControler2D>();
        rgbd2d= GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolbarController>();
        attackController = GetComponent<AttackController>();
        animator = GetComponent<Animator>();
       
    }

     private void Update(){

        if(Input.GetMouseButtonDown(0)){

           
            WeaponAction();
        }


        if (Input.GetMouseButtonDown(0))
        {   
            
            if(UseTool() == true){
                return;
            }
        }
          if(Input.GetKeyDown(KeyCode.Escape)){
            QuitGame();
        }
     }
     private void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

     private void WeaponAction(){
        Item item = toolbarController.GetItem;
        if(item == null){return;}
        if(item.isWeapon == false){return;}

        animator.SetTrigger("act");
        EnergyCost(weaponEnergyCost);

        Vector2 position = rgbd2d.position + mc.lastMotionVector * offsetDistance;
        attackController.Attack(item.damage, mc.lastMotionVector);
        AudioManager.instance.Play(onOpenedAudio);
        
     }

     private bool UseTool(){
        Vector2 position = rgbd2d.position + mc.lastMotionVector * offsetDistance;

        Item item = toolbarController.GetItem;
        if(item == null){return false;}
        if(item.onAction == null){return false;}
        animator.SetTrigger("act");
        EnergyCost(item.onAction.energyCost);
        bool complete = item.onAction.OnApply(position);
        AudioManager.instance.Play(onOpenedAudio);
        return complete;
       
     }
     private void EnergyCost(int energyCost){
        c.GetTired(energyCost);


     }
}

 //     Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);  
        //     foreach(Collider2D c in colliders){ 
        //     ToolHit hit = c.GetComponent<ToolHit>();
        //     if (hit != null){
        //         hit.Hit();
        //         return true;
        //     }
        // }
