using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{ 
    bool isR, isL, isU,canJump;
    bool isRight, isLeft, isUp;
    public float forceUp = 1200f;
    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    //Este es un cambio de prueba
    void Start()
    {
     rb = gameObject.GetComponent<Rigidbody2D>();
     animator =  gameObject.GetComponent<Animator>();
     canJump = false;
    }

    // Update is called once per frame

    void OnBecameInvisible()
    {
       Application.LoadLevel(0);
    }

    void getInput(){
         
         if(Input.GetKey(KeyCode.UpArrow)){
            isUp = true;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            isLeft = true;
            isRight = false;
            isUp = false;
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            isRight = true;
            isUp = false;
            isLeft = false;
        }
    
        else{
            isUp = false;
            isLeft = false;
            isRight = false;
        }
        playAnimation();
    }

    void playAnimation(){
        //Run Movemment
        if(isUp || isU){
            animator.SetBool("isJump",true);
            animator.SetBool("isRun",false);
        }
        else if(isLeft || isL){
            animator.SetBool("isRun",true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("isJump",false);
        }
        else if(isRight || isR){
            animator.SetBool("isRun",true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("isJump",false);
        }
        else{
            animator.SetBool("isRun",false);
            animator.SetBool("isJump",false);      
        }
    
    }

    void Update()
    {
        getInput();
      

        if(isR || isRight){
            rb.AddForce(new Vector2(2000f * Time.deltaTime,0));
            }
        else if(isL || isLeft){
            rb.AddForce(new Vector2(-2000f * Time.deltaTime,0));
            } 

    }

    void FixedUpdate(){
        if((isUp || isU) && canJump){
            rb.AddForce(new Vector2(0,forceUp));
            canJump = false;
            
        } 
    }
        
    
    void OnCollisionEnter2D(Collision2D collider){
        print("Suelo");
        if(collider.collider.name == "ground"){
            canJump = true;
            animator.SetBool("isFall",false);
            }
    }

    void OnCollisionExit2D(Collision2D coll){
        if(coll.collider.name == "ground"){
        animator.SetBool("isFall",true);
        }
    }


    

   public void buttonLeft(){
    isL = true;
    
    } 
    public void buttonLeftRelease(){
     isL = false;
        }
    public void buttonRight(){
        isR = true;
        
        } 
    public void buttonRightRelease(){
        isR = false;
        
        }
    public void buttonUp(){
        isU = true;
        
        } 
        public void buttonUpRelease(){
            isU = false;
        }
    
}

