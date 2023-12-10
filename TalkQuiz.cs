using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkQuiz : Interactable
{
    [SerializeField] DialogueContainer dialogue;

    public override void Interact (character Char){
        GameManager.instance.quizDialog.Initialize(dialogue);
    }
    
    
}
