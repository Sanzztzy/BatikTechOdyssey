using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterInteractController : MonoBehaviour
{
    characterControler2D character;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;  
    character Char ;
    private void Awake(){
        character = GetComponent<characterControler2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
        Char = GetComponent<character>();
    }

 private void Update(){
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
     }

     private void Interact(){
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);  
            foreach(Collider2D c in colliders){ 
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null){
                hit.Interact(Char);
                break;
            }
        }
     }

}
