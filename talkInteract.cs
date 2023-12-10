using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkInteract : Interactable
{
    [SerializeField] DialogueContainer dialogue;

    public override void Interact (character Char){
        GameManager.instance.dialogueSystem.Initialize(dialogue);
    }
}
