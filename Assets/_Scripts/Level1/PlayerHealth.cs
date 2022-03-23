using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    HealthSystemForDummies healthScript;
    public float health= 0f;
    [SerializeField]private float maxHealth = 100f;
    public Slider slider;

    public Text lives;

    private Animator anim;

    private float currentHealth = 100f;
    

    private void Start(){
        healthScript = GetComponent<HealthSystemForDummies>();
        anim = GetComponent<Animator>();
        health= maxHealth;
        //lives = GetComponent<Lives>();
    }

    public void UpdateHealth(float mod){
        healthScript.AddToCurrentHealth(mod);
        currentHealth += mod;
        /*health = health - mod;
        if(health> maxHealth){
            health= maxHealth;
        }
        else if (health <= 0f){
            health=0f;
            //Destroy(this.gameObject);
        }*/
        if(currentHealth == 0)
        {
            anim.SetTrigger("die");
        }
        
    //lives.text="Lives: "+health.ToString();
    
}

    
}
