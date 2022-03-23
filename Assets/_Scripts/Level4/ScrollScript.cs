using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 5f;
    float height = 0.25f;
    Vector3 posi;
    void Start(){
        posi = transform.position;
    }
     public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="scroll"){
            Destroy(col.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
    float posY = Mathf.Sin(Time.time * speed)*height+posi.y;
    transform.position = new Vector3(transform.position.x, posY, transform.position.z);
}}
