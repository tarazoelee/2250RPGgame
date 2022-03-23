using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)){
           Attack();
       }
    }
    void Attack(){
        //play attack animation
        //find enemies
        //destroy enemies
        
    }
}
