using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //speed of player of type float (pu)
    [SerializeField]
    private float speed;

    //[SerializeField]
    //private bool paused = false;

    //Lets add a variable to our character controller of controller
    private CharacterController controller;
    
    //Shooting variables needed is the gameobject bullet to instantiate prefab
    public GameObject bullet;
    //A bullet spawn
    public Transform bulletSpawn;
    //Some firerate
    [SerializeField]
    private float fireRate = 4;
    //And a time until next fire
    [SerializeField]
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    void FixedUpdate()
    {
        //Movement behaviour

        //Horizontal movement is done by adding a float with name space something like movementHorizontal and getting the input manager get axis Horizontal
        float movementHorizontal = Input.GetAxis("Horizontal");
        //Than do the same for Vertical movement
        float movementVertical = Input.GetAxis("Vertical");
        
        //Let remove the old movement behaviour to make it based around our rotation behaviour with vector movement based on our character controller.
        //We can keep the variable of movement but need to give it new behaviour with transform right * movementHorizontal + forward * movement vertical
        Vector3 move = transform.right * movementHorizontal + transform.forward * movementVertical;
        //Character controller movement is done with the syntax of move than the motion is the move variable * speed * time.deltatime.
        controller.Move(move * speed * Time.deltaTime);
    }

    private void Update()
    {        
        //If I press fire button(Inputmanager given button name "Fire1") than the time above next fire
        //I reset the time for next for equal to the time + fireRate and create the bullet on the correct location and rotation.
        if (Input.GetButton("Fire1") && Time.time > nextFire )
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }

        // if (Input.GetKey(KeyCode.Escape))
        // {
        //     if (paused == false)
        //     {
        //         PauseGame();  
        //     }
        // } 
        // else if (Input.GetKey(KeyCode.Escape))
        // {
        //     if (paused == true)
        //     {
        //         ResumeGame();
        //     }
        // }

    }
    
    // void PauseGame ()
    // {
    //     paused = true;
    //     Time.timeScale = 0.1f;
    // }
    // void ResumeGame ()
    // {
    //     Time.timeScale = 1;
    // }
}

