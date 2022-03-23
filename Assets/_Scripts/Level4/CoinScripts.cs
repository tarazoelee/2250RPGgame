using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CoinScripts : MonoBehaviour
{
   public int count;
   public Text counterText;
   void Start(){
       count = 0;
       setCounterText();
   } 

   public void OnTriggerEnter2D(Collider2D collide){
        if(collide.gameObject.tag=="coin"){
            Destroy(collide.gameObject);
            count = count+1;
            setCounterText();
        }
    }
    public void addCoins(int num){
        count=count+num;
        setCounterText();
    }
    void setCounterText(){
        counterText.text="Coins: "+count.ToString();
    }


}
