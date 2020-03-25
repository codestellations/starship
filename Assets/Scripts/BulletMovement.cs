using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    float speed = 7f;
    float timer = 5f;

    void Update()
    {
        timer -= Time.deltaTime;
        Vector3 pos = transform.position;
        Vector3 move = new Vector3(0, speed * Time.deltaTime, 0);
        pos += transform.rotation * move;
        transform.position = pos;

        if(timer <= 0){
            Destroy(gameObject);
        }
    }
    // player's bullet hit enemy, add score then destroy the bullet
    void OnTriggerEnter2D(){
        Score.scoreValue += 10;
        Destroy(gameObject);
    }
}
