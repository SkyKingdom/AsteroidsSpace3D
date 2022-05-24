using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //For this class we need to add some following behaviour.
    //This class will give freedom to the players behaviour.
    
    //Since we want the mouselook it might be good to get a variable for the mouseSensitivity of float.
    [SerializeField]
    private float mouseSensitivity = 100f;

    //We also would need to translate our camera rotation into our player body transform.
    public Transform playerBody;

    //Lastly I don't want the player to rotate to much on the x - Rotation so we can Clamp that behaviour. But first we need a variable of the float.
    [SerializeField] private float Rotation = 0f;
    
    //I also need to lock the rotation with Cursor.lockState = CursorLockMode.Locked; This line of code basically get the lockstate and locks it. Remember to unlock it whenever you dont want it! 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // In the update function we want the mouse rotation input. And we can do that with the input manager again. We need two variables of float for both the X and the Y. It is a inputmanager get axis.
    // We than can add the mousesensitivity to the look behaviour and since we are working with a frame base we need to multiple it with the deltatime.
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Now we need the rotation translation and clamp the screen.
        //All we need to know is that the xrotation variable is than minus the current Y mouse position (-=)
        //We than need to start using some clamping of our screen to not make the rotation of looking up be a annoyance. We use the syntax of Mathf.Clamp
        Rotation -= mouseY;
        Rotation = Mathf.Clamp(Rotation, -20f, 20f);
        
        //Lastly we need to rotate this transform on the localrotation because of the player body. We need to add some Euler angles to this rotation of xRotation and y and z values.
        //Than why we added the playerbody transform is to playerbody rotate with the vector3 up times the mouseX; This basically makes the body rotate on the X rotation.
        transform.localRotation = Quaternion.Euler(Rotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
