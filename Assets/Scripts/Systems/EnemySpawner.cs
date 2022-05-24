using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //We want to spawn both asteroids and enemies.
    public GameObject asteroids;
    public GameObject enemies;
    
    //We than need to keep a repeating of function to make it infinite. We can use InvokeRepeating.
    private void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroids),4, Random.Range(4,8));
        InvokeRepeating(nameof(SpawnEnemies), 4, Random.Range(4,8));
    }

    //We need to create two functions within this class. One for spawning asteroids and one for spawning the enemies.
    //Both of the need a variable of a vector3 to determine the random spawn location. Than we can determine the random range of the object and instantiate that object.
    //For the asteroids we can keep the rotations undefined. but for the enemies I want the rotations on y randomized.
    void SpawnAsteroids()
    {
        Vector3 rsp = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
        Instantiate(asteroids, rsp, Quaternion.identity);
    }
    
    void SpawnEnemies()
    {
        Vector3 rsp = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
        Instantiate(enemies, rsp, Quaternion.Euler(0f, Random.Range(0, 360), 0f));
    }
}