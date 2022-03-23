using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    [SerializeField] private float attackDamage=10f;
    [SerializeField] private float attackSpeed=1f;
    public PlayerHealth playerHealth;
    private Animator animator;
    public LayerMask player;
    public float attackRange=0.5f;
     public Transform attackPoint;
    public bool canAttack;
    
     

    private void Awake(){
        animator=GetComponent<Animator>();
    }
    private void Update(){
        Collider2D [] chars=Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player);
        int num=chars.Length;
        if(num!=0){
            Invoke("Attack", 2f);
            num--;
        }
    }
    private void Attack(){
        Collider2D [] chars=Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player);
        foreach(Collider2D players in chars){
           Debug.Log("we hit the player");
           playerHealth.UpdateHealth(-10);

    }
}
}
