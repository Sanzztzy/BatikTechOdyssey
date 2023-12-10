using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class characterControler2D : MonoBehaviour{

    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 2f;
    //[SerializeField] AudioClip onOpenedAudio;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;


    void Awake(){
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    private void Update(){

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical =   Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(
        horizontal,
        vertical 
        );   
        animator.SetFloat("horizontal",horizontal);
        animator.SetFloat("vertical", vertical);

        moving = horizontal !=0 || vertical !=0;
        animator.SetBool("moving", moving);

        if(horizontal != 0 || vertical !=0){
        lastMotionVector = new Vector2(
            horizontal,vertical
        ).normalized;
         animator.SetFloat("lastHorizontal" , horizontal);
         animator.SetFloat("lastVertical", vertical);
        }

        
    }

    void FixedUpdate(){
        Move();

    }

    private void Move(){
        rigidbody2d.velocity = motionVector * speed;
        //AudioManager.instance.Play(onOpenedAudio);
    
    }

    private void OnDisable(){

        rigidbody2d.velocity = Vector2.zero;
    }
}
