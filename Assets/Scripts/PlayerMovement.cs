using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bulletPrefab;
    float shootDelay = 0.25f;
    float timer = 0;
    float linearSpeed = 5f;
    float rotationSpeed = 90f;
    float shipSize = 0.01f;

    void Update()
    {
        // move ship
        Vector3 pos = transform.position;
        Vector3 move = new Vector3(0, Input.GetAxis("Vertical") * linearSpeed * Time.deltaTime, 0);

        // rotate ship
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime * -1;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;
        
        pos += rot * move;

        // make sure ship stays in boundaries
        if(pos.y+shipSize > Camera.main.orthographicSize){
            pos.y = Camera.main.orthographicSize-shipSize;
        }
        if(pos.y-shipSize < -Camera.main.orthographicSize){
            pos.y = -Camera.main.orthographicSize+shipSize;
        }

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
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
