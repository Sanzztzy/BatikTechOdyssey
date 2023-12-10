using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    private void Awake(){

        instance = this ;
    }
    public GameObject player;
    public ItemContainer inventoryContainer;
    public itemDragAndDrop dragAndDrop ;
    public DialogueSystem dialogueSystem;
    public OnScreenMessageSystem messageSystem;
    public DayTimeController timeController;
    public QuizDialog quizDialog;

    public delegate void OnEnemyDeath(EnemyProfile enemyProfile);
    public OnEnemyDeath onEnemyDeath;

    public Text objectiveText;
    public Animator objectiveAnim;

    public void UpdateTracker(string newText){

        objectiveText.text = newText;
        objectiveAnim.Play("ObjectivePopUp");
    }

    
}
