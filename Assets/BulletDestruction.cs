using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestruction : MonoBehaviour
{
    float timer = 3f;
    void Update()
    {
        void OnTriggerEnter2D(){
            Destroy(gameObject);
        }

        timer -= Time.deltaTime;
        if(timer <= 0){
            Destroy(gameObject);
        }
        
    }
}
