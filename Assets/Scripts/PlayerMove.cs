using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{ 
    bool isR, isL, isU,isOnGround;
    Rigidbody2D rb;

    // Start is called before the first frame update
    //Este es un cambio de prueba
    void Start()
    {
     rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void OnBecameInvisible()
    {
       Application.LoadLevel(0);
    }

    void Update()
    {

      

        if(isR){
            rb.AddForce(new Vector2(2000f * Time.deltaTime,0));
            }
        if(isL){
            rb.AddForce(new Vector2(-2000f * Time.deltaTime,0));
            }
        

    }

    void FixedUpdate(){
        if(isU && isOnGround){
            rb.AddForce(new Vector2(0,1000));
        }
    }
        
    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.name == "ground"){
            gameObject.GetComponent<Animator>().SetBool("isFall",false);
            isOnGround = true;
            }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.name == "ground"){
            gameObject.GetComponent<Animator>().SetBool("isFall",true);
            gameObject.GetComponent<Animator>().SetBool("isRun",false); 
            gameObject.GetComponent<Animator>().SetBool("isJump",false);
            isOnGround = false;
            isU = false;
            }
    }

    

   public void buttonLeft(){
    isL = true;
    gameObject.GetComponent<Animator>().SetBool("isRun",true);
    gameObject.GetComponent<SpriteRenderer>().flipX = true;
    } 
    public void buttonLeftRelease(){
        isL = false;
        gameObject.GetComponent<Animator>().SetBool("isRun",false);
        }
    public void buttonRight(){
        isR = true;
        gameObject.GetComponent<Animator>().SetBool("isRun",true);
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
        } 
    public void buttonRightRelease(){
        isR = false;
        gameObject.GetComponent<Animator>().SetBool("isRun",false);
        }
    public void buttonUp(){
        isU = true;
        gameObject.GetComponent<Animator>().SetBool("isJump",true);
        } 
        public void buttonUpRelease(){
            
        }
    
}

