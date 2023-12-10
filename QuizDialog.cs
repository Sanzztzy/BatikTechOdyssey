using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizDialog : MonoBehaviour
{
    [SerializeField] Text targetText;
    [SerializeField] Text nameText;
    [SerializeField] Image potrait;
    [SerializeField] GameObject panel;
    
    
   
    DialogueContainer currentDialogue;
    int currentTextLine;

    [Range (0f, 1f)]
    [SerializeField] float visible;
    [SerializeField] float timePerLetter = 0.05f;
    float totalTimeToType, currentTime;
    string lineToShow;

    

    private void Update(){

        if(Input.GetMouseButtonDown(0)){
            PushText();
        }
        TypeOutText();

        
    }

    private void TypeOutText(){
        if(currentTime >= totalTimeToType){return ;}
        currentTime += Time.deltaTime;
        float progress = currentTime / totalTimeToType;
        progress =  Mathf.Clamp(progress,0,1f);
        int letterCount =(int)(lineToShow.Length * progress);
        targetText.text =lineToShow.Substring(0, letterCount);
    }

    private void PushText(){
        currentTextLine += 1;
        if(currentTextLine >= currentDialogue.line.Count){
            Conclude();
        }
        else{
           CycleLine();
          
        }
    }

     void CycleLine(){
         lineToShow = currentDialogue.line[currentTextLine];
         totalTimeToType = lineToShow.Length * timePerLetter;
         currentTime = 0f;
         targetText.text = "";    
     }

    public void Initialize(DialogueContainer dialogueContainer){
        Show(true);
        currentDialogue = dialogueContainer;
        currentTextLine = 0;
        targetText.text = currentDialogue.line[currentTextLine];
        UpdatePotrait();
    }

     private void UpdatePotrait(){
         potrait.sprite = currentDialogue.actor.potrait;
         nameText.text = currentDialogue.actor.Name;
     }

    private void Show(bool v){
        gameObject.SetActive(v);
    }

    private void Conclude(){

        Debug.Log("ending");
        Show(false);
        panel.SetActive(!panel.activeInHierarchy);

    }    
}
