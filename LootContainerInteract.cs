using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LootContainerInteract : Interactable
{

    [SerializeField] GameObject closedChest;
    [SerializeField] GameObject openedChest;
    [SerializeField] bool opened;
    [SerializeField] GameObject PickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;
    [SerializeField] Item item;
    [SerializeField] ResourceNodeType nodeType;
    [SerializeField] float ttl = 10f;
    [SerializeField] AudioClip onOpenedAudio;
   
   public override void Interact(character Char){
   
        if (opened == false){
            opened = true;
            closedChest.SetActive(false);
            openedChest.SetActive(true);
            AudioManager.instance.Play(onOpenedAudio);

            while (dropCount > 0){
                dropCount -= 1;

                Vector3 position = transform.position;
                position.x += spread * UnityEngine.Random.value - spread / 2;
                position.y += spread * UnityEngine.Random.value - spread / 2;
                GameObject go = Instantiate(PickUpDrop);
                go.transform.position = position;

            }          
        }
    }
    
    private void Update(){
        if(opened == true){
           
            SceneManager.LoadScene("Credit");
        }      
    }
}
