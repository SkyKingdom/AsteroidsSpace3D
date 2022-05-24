using System.Collections;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    /*
    So make a trigger detection that checks if it hits the player and maybe deduct some health

    Than we need the bullet do be destroyed else they stay endless.
    Lets say after 6 seconds
    You do this by using a IENumerator and we call it bulletdestroy
    We than need too at a startcoroutine to start.
    
    Give a number by calling a yield return new and waiting for a couple of seconds to call a function
    Than destroy it
    */
    
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(BulletDestroy());
        
        //We need -1 movement to sent the bullets backwards. Or change the bulletspawn pivot around so the blue arrow is forward. (I changed it to follow pivot)
        rb.velocity = transform.forward * speed; 
    }

    //The bullets also need to do destroy asteroids
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Debug.Log("Lose 1hp");
        }
    }

    IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(6.0f);
        Destroy(gameObject);
    }
}
