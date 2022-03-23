using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningGhoulScript : MonoBehaviour
{ 
    public float speed = 3f;
 
    public bool MoveLeft;

    public GameObject fireballPrefab;
    public float spawnTime = 3f;
    
    public float shootSpeed;
    public Transform attackPoint;
     public LayerMask player;
     public float attackRange=0.5f;
     public PlayerHealth playerHealth;
    
     void Start(){
         
        //in the start method, a random number is chosen to decide the direction of enemy_2
        int startDirection = Random.Range(0,2);
        //if the number chosen is 0, the enemy will move right
        if(startDirection==0){
        MoveLeft = false;
        //if the number is not 0, the enemy will move left
        }else{
        MoveLeft = true;
        }

         InvokeRepeating("Shoot",spawnTime,spawnTime);
    } 

     void Update(){
       //move function is called each frame in update()
      Move();
      Collider2D [] chars=Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player);
        int num=chars.Length;
        if(num!=0){
            Invoke("Attack", 2f);
            num--;
        }
   }

    void Move(){
   
    //creates a new vector3
      Vector3 position = transform.position;
      Vector3 pos = Vector3.zero;
      //defines how to move left, the y position must decrease at the same rate as the x position decreases
        if(MoveLeft){
        pos = new Vector3(position.x - speed * Time.deltaTime, position.y,0f);}
        //defines how it moves right, the y position must decrease at the same rate as the x position increases
        else{
        pos = new Vector3 (position.x + speed * Time.deltaTime, position.y,0f);}

        transform.position=pos;
        
        if(pos.x>84){
            MoveLeft=true;
       }if(pos.x<76){
            MoveLeft=false;}
        
        }


//only being called once bc in Start fct
       
        
       void Shoot(){
      
       Vector3 shootPosition= new Vector3(33,-1,0);
        
        GameObject newFireball= Instantiate(fireballPrefab,shootPosition,transform.rotation*Quaternion.Euler(0f,180f,0f));
        
        newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed*-speed*Time.fixedDeltaTime,0f);
        newFireball.tag="fireballPrefab";
        
        }

         private void Attack(){
        Collider2D [] chars=Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player);
        foreach(Collider2D players in chars){
           Debug.Log("we hit the player");
           playerHealth.UpdateHealth(-20);

    }
         }



    
    
}

