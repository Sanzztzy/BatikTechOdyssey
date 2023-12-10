using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    [SerializeField] string nameEssentialScene;
    [SerializeField] string nameNewGameStartScene;

    AsyncOperation operation;

    public void ExitGame(){
    Debug.Log("Quit the game");
            #if UNITY_EDITOR
        
                    UnityEditor.EditorApplication.isPlaying = false;
             #else
         
                    Application.Quit();
            #endif

    }

    public void StartNewGame(){
    
        SceneManager.LoadScene(nameNewGameStartScene, LoadSceneMode.Single);
        SceneManager.LoadScene(nameEssentialScene, LoadSceneMode.Additive);
     
    }

  
}
