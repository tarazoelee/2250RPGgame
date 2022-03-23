using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /*
    [SerializeField] private float speed; 
    private bool hit;
    private BoxCollider2D boxcollider; 
    private Animator anim; 

    private void Awake(){
        boxcollider = GetComponent<BoxCollider2D>;
        anim = GetComponent<Animator>;
    }
    private void Update(){
        if(hit){
            return;
        }
        float movementSpeed = speed*Time.deltaTime* direction;
        transform.Translate(movementSpeed,0f,0f);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        hit = true;
        boxcollider.enabled =false;
        anim.SetTrigger("explode");


    }
    public void SetDirection(float direction){
        direction= direction;
        gameObject.setActive(true);
        hit=false;
        boxcollider.enabled=true;
    }
    private void Deactivate(){
        gameObject.setActive(false);
    }
    */
}
