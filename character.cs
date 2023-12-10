using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat {

    public int maxVal;
    public int currVal;

    public Stat(int curr, int max){

        maxVal = max;
        currVal = curr;
    }
    
    internal void Subtract(int amount){

        currVal -= amount;
    }
    internal void Add(int amount){

        currVal += amount;
        if(currVal  > maxVal ){ currVal = maxVal;}
    }
    internal void SetToMax(){

        currVal = maxVal;
    }
}

public class character : MonoBehaviour, IDamageable
{
    public Stat hp;
    [SerializeField] StatusBar hpBar;
    public Stat stamina;
    [SerializeField] StatusBar staminaBar;

    public bool isDead;
    public bool isExhausted;
    float regen;
    

    DisableController disable;
    PlayerRespawn playerRespawn;

    private void Awake(){
        disable = GetComponent<DisableController>();
        playerRespawn = GetComponent<PlayerRespawn>();
    }

    private void Start(){

        UpdateHPBar();
        UpdateStaminaBar();
    }

    private void UpdateHPBar(){
        hpBar.Set(hp.currVal, hp.maxVal);
    }
    private void UpdateStaminaBar(){
        staminaBar.Set(stamina.currVal , stamina.maxVal);
    }
    
    internal void TakeDamage(object damage){
        throw new NotImplementedException();
    }

    public void TakeDamage(int amount){

        if(isDead == true){return;}
        hp.Subtract(amount);
            if(hp.currVal <= 0){
            Dead();
            }
        UpdateHPBar();
    }

    private void Dead(){
        isDead = true;
        disable.DisableControl();
        playerRespawn.StartRespawn();
    }

    public void Heal(int amount){

        hp.Add(amount);
        UpdateHPBar();
    }

    public void FullHeal(){

        hp.SetToMax();
         UpdateHPBar();
    }

     private void RegenerateHealth(){
        if (hp.currVal < hp.maxVal){
        regen += Time.deltaTime;
   
            if (regen >= 1f){
                Heal(3); 
                regen = 0f;
            }
        }
    }

    public void GetTired(int amount){

        stamina.Subtract(amount);
            if(stamina.currVal <= 0){
            Exhausted();
            }
        UpdateStaminaBar();
    }
    private void Exhausted(){
        isExhausted = true;
        disable.DisableControl();
        playerRespawn.StartRespawn();
    }


    public void Rest(int amount){

        stamina.Add(amount);
        UpdateStaminaBar();
    }

    public void FullRest(){

        stamina.SetToMax();
        UpdateStaminaBar();
    }
    private void RegenerateStamina(){
        if (stamina.currVal < stamina.maxVal){
        regen += Time.deltaTime;
   
            if (regen >= 1f){
                Rest(5); 
                regen = 0f;
            }
        }
    }


    private void Update(){
        
        RegenerateStamina();
        RegenerateHealth();

    }


    public void CalculateDamage(ref int damage){
       
    }
  
    public void ApplyDamage(int damage){
       TakeDamage(damage);
    }
     
    public void CheckState(){
        
    }

}
