using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float linearSpeed = 5f;
    public float rotationSpeed = 90f;
    float shipSize = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotate ship
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime * -1;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        // move ship
        Vector3 pos = transform.position;
        Vector3 move = new Vector3(0, Input.GetAxis("Vertical") * linearSpeed * Time.deltaTime, 0);
        pos += rot * move;

        // make sure ship stays in scene
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
        transform.position = pos;
    }
}
