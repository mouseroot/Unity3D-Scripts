using UnityEngine;
using System.Collections;

public class DualStickController : MonoBehaviour {

    public float moveSpeed = 1.5f;
    public float shootSpeed = 1f;
    public GameObject projectile;
    public float shootDelay = 0.5f;

    [Header("Extendable Options")]
    public GameObject[] _projectilePool;

    private Vector2 moveDirection;
    private Vector2 shootDirection;
    private Vector2 position;
    private bool canFireWeapon = true;

    //Enable the weapon
    void enableWeaponFire()
    {
        canFireWeapon = true;
    }

    //Disable the weapon
    void disableWeaponFire()
    {
        canFireWeapon = false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Get Vector2 direction of movement
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Convert Vector3 to Vector2 for 2D
        position = new Vector2(transform.position.x, transform.position.y);

        //Move by <Position> + <Direction> * <Speed> * <Time>
        rigidbody2D.MovePosition(position + moveDirection * moveSpeed * Time.deltaTime);

        //If any of the two inputs have any data and the weapon can be fired
        if ((Input.GetAxis("FireHorizontal") != 0.0f || Input.GetAxis("FireVertical") != 0.0f) && canFireWeapon)
        {
            //Convert the keys pressed to a Vector2
            shootDirection = new Vector2(Input.GetAxis("FireHorizontal"), Input.GetAxis("FireVertical"));

            //Calculate the angle to rotate the sprite (-90 for sprites that are facing up)
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg - 90;

            //Create a projectile instance
            GameObject projectileInstance = Instantiate(projectile, position, Quaternion.AngleAxis(angle, Vector3.forward)) as GameObject;

            //Add force to the objects rigidbody
            projectileInstance.rigidbody2D.AddForce(shootDirection * shootSpeed, ForceMode2D.Force);

            //Disable the weapon
            disableWeaponFire();

            //Set a timer to re-enable the weapon (effective for holding down the attack buttons)
            Invoke("enableWeaponFire", shootDelay);
        }
	}
}
