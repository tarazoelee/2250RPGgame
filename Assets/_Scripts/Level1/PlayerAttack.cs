using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float attackCooldown; //before fire next shot 
   private Animator anim; 
   private PlayerController playerMovement; 
   private float coolDownTimer = 1;
   public Transform attackPoint;
   public float attackRange=0.5f;
   public LayerMask enemyLayer;
   public CoinScripts coin;

   public GameObject LightBandit;
   public GameObject ghoul;

   private void Awake(){
       anim = GetComponent<Animator>();
       playerMovement = GetComponent<PlayerController>();
   }
   private void Update(){
       if(Input.GetKeyDown(KeyCode.W) ){
        Attack();
       }
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.jumping == false)
        {
            Jump();
        }

        float hMove = Input.GetAxis("Horizontal") * 40f;
        anim.SetFloat("speed",hMove);
       coolDownTimer+=Time.deltaTime;
   }
   private void Attack(){
       anim.SetTrigger("attack");
       //coolDownTimer=0;

       Collider2D [] enemies=Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
       
        foreach(Collider2D enemy in enemies){
            if(enemy.gameObject.tag=="Enemy"){
                Debug.Log("we hit an enemy");
                Destroy(LightBandit);
                coin.addCoins(3);
            }
            else{
                Debug.Log("we hit an enemy");
                Destroy(ghoul);
                coin.addCoins(5);
            }
        

       }
    
      
   }

    private void Jump()
    {
        playerMovement.jumping = true;
        anim.SetBool("isJumping",true);
        playerMovement.Jump();
    }

    public void StopJumping()
    {
        anim.SetBool("isJumping",false);
    }
    
    /* void OnTriggerEnter (Collider collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided with LightBandit");
                //enemy = GameObject.FindGameObjectWithTag ("Enemy");
                //enemyHealth = enemy.GetComponent<EnemyHealth> ();
                Destroy(LightBandit);
        }
        else if(collider.gameObject.tag=="burningGhoul"){
            Debug.Log("Collided with ghoul");
                //enemy = GameObject.FindGameObjectWithTag ("Enemy");
                //enemyHealth = enemy.GetComponent<EnemyHealth> ();
                Destroy(ghoul);
        }
    }
    */
}
