using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    public GameObject enemy;
    int numberOfEnemies = 5;

    Vector2 bottomLeft;
    Vector2 topRight;

    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight =  Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); 

        for (int i = 0; i< numberOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        x = Random.Range(-7, 7);
        y = Random.Range(4, 6);
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = new Vector2(x, y);
    }
}