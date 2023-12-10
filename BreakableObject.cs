using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour, IDamageable
{

    [SerializeField] GameObject PickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;
    [SerializeField] Item item;
    [SerializeField] ResourceNodeType nodeType; 
    [SerializeField] int hp = 10;

    public void ApplyDamage(int damage){
        hp -= damage;
    }

    public void CalculateDamage(ref int damage){
        damage = 30 ;
    }
  
    public void CheckState(){
        if(hp <= 0){
            while (dropCount > 0){
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(PickUpDrop);
            go.transform.position = position;
            }    
        Death();
        }     
    }  
    public EnemyProfile enemyProfile;

    public void Death(){

        if(GameManager.instance.onEnemyDeath !=null) GameManager.instance.onEnemyDeath.Invoke(enemyProfile);

        Destroy(gameObject);
    }
}
