using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bulletPrefab;
    float shootDelay = 0.25f;
    float timer = 0;
    float linearSpeed = 5f;
    float shipSize = 0.01f;
    int health = 3;

    void Update()
    {
        // move ship
        Vector3 pos = transform.position;
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * linearSpeed * Time.deltaTime, 0, 0);
        pos += move;

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float width = Camera.main.orthographicSize * screenRatio;

        if(pos.x+shipSize > width){
            pos.x = width-shipSize;
        }
        if(pos.x-shipSize < -width){
            pos.x = -width+shipSize;
        }

        // ship position
        transform.position = pos;

        // player shoot bullet (by pressing "p")
        timer -= Time.deltaTime;
        if(Input.GetKey(KeyCode.P)  && timer <= 0){
            timer = shootDelay;
            Vector3 offset = transform.rotation * new Vector3(0, 1.5f, 0);
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
        if(health <= 0){
            Score.death = true;
            Destroy(gameObject);
        }

        // press ESC to quit
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }    
    }

    // if player get shot
    void OnTriggerEnter2D(){
        health--;
        Debug.Log("Trigger");
    }
}
