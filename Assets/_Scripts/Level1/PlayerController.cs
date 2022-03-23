using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    HealthSystemForDummies healthSystem;
    
    private PlayerAttack playerAttack;


    public bool jumping = false;
    public float movespeed = 5f;

    private bool isMovingRight = true;

    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        healthSystem = GetComponent<HealthSystemForDummies>();
    }

    void regenerate(){
        healthSystem.ReviveWithMaximumHealth();
    }

    void LateUpdate()
    {
        float hMove = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(hMove, 0f, 0f);
        Vector3 movement2 = new Vector3(Input.GetAxis("Vertical"), 0f, 0f);
        transform.position += movement * Time.deltaTime * movespeed;



        // If the input is moving the player right and the player is facing left...
        if (hMove > 0 && !isMovingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (hMove < 0 && isMovingRight)
        {
            // ... flip the player.
            Flip();
        }
//         if(healthSystem.CurrentHealth<100){
        //    Invoke("regenerate",5); //reviving health to maximum after 5 seconds 
      //  }

    }

    //Jumping Method adds force to the rigidbody
    public void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, 8f), ForceMode2D.Impulse);
    }  

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isMovingRight = !isMovingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("fireballPrefab")) {
        HealthSystemForDummies healthSystem = collision.gameObject.GetComponent<HealthSystemForDummies>();
        // Damage character for -10 units
        healthSystem.Kill();
        }

     }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "pressurePlate")
        {
            //SceneManager.LoadScene("Scene1");
        }
        if(col.gameObject.tag == "floor")
        {
            jumping = false;
            playerAttack.StopJumping();
        }
        if(col.gameObject.tag == "fireballPrefab")
        {
            Debug.Log("test");
        }
    
    }

    

    
}
