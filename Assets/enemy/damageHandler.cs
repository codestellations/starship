using System.Collections;
using UnityEngine;

public class damageHandler : MonoBehaviour
{
    int health = 1;
    
    void OnTriggerEnter2D() 
    {
       health--;
       if (health <=0)
       {
           Destroy(gameObject);
       }
    }
}