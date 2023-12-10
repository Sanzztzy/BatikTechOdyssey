using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed;
    [SerializeField] Vector2 attakSize = Vector2.one;
    [SerializeField] int damage = 50;
    [SerializeField] float timeToAttack = 1f;
    
    float attackTimer;

    void Start()
    {
        player = GameManager.instance.player.transform;
        attackTimer = Random.Range(0, timeToAttack);
        
    }

   
    void Update()
    {
       
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
        Attack();
    }
    private void Attack(){

        attackTimer -= Time.deltaTime;
        if (attackTimer > 0f) { return; }
        attackTimer = timeToAttack;

    Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, attakSize.x);

    for (int i = 0; i < targets.Length; i++)
    {
        if (targets[i].CompareTag("Player"))
        {
            Damageable character = targets[i].GetComponent<Damageable>();
            if (character != null)
            {
                float distance = Vector2.Distance(transform.position, character.transform.position);
                if (distance <= 2f) // Change this value based on your desired range
                {
                    character.TakeDamage(damage);
                }
            }
        }
    }
    }
}
