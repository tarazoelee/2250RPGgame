using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float dieTime;
    public float damage;


   void Start(){
       StartCoroutine(CountDownTimer());
       gameObject.SetActive(true);
   }

  void OnCollisionEnter2D(Collision2D col){
        /*if (col.transform.CompareTag("player"))
        {
            HealthSystemForDummies healthSystem = col.gameObject.GetComponent<HealthSystemForDummies>();

            // Damage enemy for -100 units
            healthSystem.AddToCurrentHealth(-10);
        }*/
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            HealthSystemForDummies healthSystem = col.gameObject.GetComponent<HealthSystemForDummies>();

            // Damage enemy for -100 units
            healthSystem.AddToCurrentHealth(-10);
            Destroy(gameObject);
        }
    }



    IEnumerator CountDownTimer(){
        gameObject.SetActive(true);
        yield return new WaitForSeconds(dieTime);
        Die();
    }


    void Die(){
        gameObject.SetActive(false);
    } 





}
