using System.Collections;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    //Float variable for the speed of the bullet
    [SerializeField]
    private float speed;

    //Rigidbody behaviour to push the bullet forward later.
    private Rigidbody rb;

    //We need to get the reference to the playermanagement to add score whenever our bullet hits. However this variable can be private and we need to get the variable someway else because its outside the script.
    //We could make it public but since this particular object is a instantiate it can't keep the information of the public therefore we need to add a new behaviour to our start method.
    private PlayerManagement scoreMade;

    //In the start function we can add the variable scoremade to finding this object of the type. Since Playermanagement is only once in a scene or game we can just find the object tasype.
    void Start()
    {
        scoreMade = FindObjectOfType<PlayerManagement>();
        //We get the Rigidbody variable and we say that this variable contains the rigidbody component.
        rb = GetComponent<Rigidbody>();
        //We destroy the bullet by calling in a coroutine to delay it.
        StartCoroutine(BulletDestroy());

        //Since we have access to all the information of the rigidbody component we can call it the movement of velocity and we say that the transform should move forwards times the speed.
        rb.velocity = transform.forward * speed;
    }

    //The bullets also need to do destroy asteroids
    //We can now add to this destroy behaviour that if a enemy of tag is destroyed the reference to the points.
    //Since we have found the playermanagement we can call the variable and the score variable of that script and add a number += and than call the function to update the text.
    private void OnTriggerEnter(Collider other)
    {
        //We need to check the tag of the player by saying other gameobject check for the tag of Enemy.
        if(other.gameObject.CompareTag("Enemy"))
        {
            //We destroy the gameobject and call in the score variable which is now a component of playermanagement so we can access it.
            Destroy(other.gameObject);
            //We say here the playermanagement score variable is + 10 = whatever it was.
            scoreMade.score += 10;
            //We say here that playermanagement function points added need to be run to update the score.
            scoreMade.PointsAdded();
        }
    }
    
    //Coroutines are there to make sure that some lines of code can be called later. So we say that this destroy line of code is being called after 6 seconds here.
    IEnumerator BulletDestroy()
    {
        //The yield keyword performs custom and stateful iteration and returns each element of a collection one at a time sans the need of creating temporary collections.
        //The new keyword creates a new instance of a type.
        //Return exits a function when calling it. Whatever is below the return will not be executed, however in this situation
        yield return new WaitForSeconds(6.0f);
        Destroy(gameObject);
    }
}
