using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    //speed of player of type float (pu)
    private float speed;

    //Shooting variable
    public GameObject bullet;
    public Transform bulletSpawn;
    [SerializeField] private float fireRate;
    [SerializeField] private float nextFire;

    //Set the direction of the enemy to left.
    [SerializeField] private Vector3 dir = Vector3.left;

    //Variables to set a max position from moving left and right.
    [SerializeField] private float maxRangeLeft;
    [SerializeField] private float maxRangeRight;
    
    // Update is called once per frame
    void Update()
    {
        //Direction translation.
        transform.Translate(dir*speed*Time.deltaTime);
        
        //Transform.position is used to get the informations of the position and now just whatever it is on the xAxis than the operator says lesser than OR equal to the maxrange.
        //Than our movement changes to right.
        //Than else if other position is back to whatever is greater than OR equal to maxrange. Direction back to left. Than we have a loop.
        //Change after amount
        if(transform.position.x <= maxRangeLeft)
        {
            dir = Vector3.right;
        }else if(transform.position.x >= maxRangeRight){
            dir = Vector3.left;
        }

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}