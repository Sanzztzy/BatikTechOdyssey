using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    const float day = 86400f;
    float time;

    [SerializeField] float timeScale = 60f;
    [SerializeField] Text text;
    [SerializeField] float startTime = 28800f;
    List<TimeAgent> agents;

    private void Awake(){
        agents = new List<TimeAgent>();
         
    }

    private void Start(){

        time = startTime;
    }

    public void Subscribe(TimeAgent timeAgent){
        agents.Add(timeAgent);
    }

    public void Unsubscribe(TimeAgent timeAgent){
        agents.Remove(timeAgent);
    }

    float Hours{
        get{return time / 3600f;}
    }
    float Minutes{
        get{return time % 3600f /60f;}
    }
    private void Update(){

        time += Time.deltaTime * timeScale;
        int h =(int) Hours;
        int m = (int) Minutes;
        text.text = h.ToString("00") + ":" + m.ToString("00");
        if(time > day){
            nextDay();
        }

        for (int i = 0; i < agents.Count; i++){
            agents[i].Invoke();
        }
    }

    private void nextDay(){

        time = 0;
    }

}
