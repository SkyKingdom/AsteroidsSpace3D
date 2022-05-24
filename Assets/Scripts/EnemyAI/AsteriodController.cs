using UnityEngine;

public class AsteriodController : MonoBehaviour
{
    //Variables
    //We need to know the old position of where the player we can do that by getting the vector position.
    public Vector3 playerExPosition;

    //We created a speed variable between the randomizer number of 1,7.
    [SerializeField]
    private float speed;


    void Start()
    {
        //We need to bound the values of the players old position into a game object we can find the player by using GameObject.FindWithTag("Player").transform.position
        playerExPosition = GameObject.FindWithTag("Player").transform.position;
    }

    private void Update()
    {

        //So we need a create a specific vector3 variable for the asteroids position to translate it.
        Vector3 position = transform.position;
        //Now that we have determined the position we can call the variable into movement of vector 3
        //We do this by using a Vector3.Lerp
        position = Vector3.Lerp(position, playerExPosition, (Time.deltaTime * speed) / Vector3.Distance(playerExPosition, position));
        transform.position = position;
        //If the asteroids position reaches the old player position I just want to remove them.
        if (transform.position == playerExPosition)
        {
            Destroy(gameObject);
        }
    }

    //Note we dont need to use fixedupdate for this one since I'm just moving the object via Vector3 not via Rigidbody this time.

    //Lastly if the asteroids hits the player on trigger destroy the player.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
