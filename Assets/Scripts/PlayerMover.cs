using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/**
 *  This component allows the player to add force to its object using the arrow keys.
 *  Works with a 3D RigidBody.
 */
// [RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TouchDetector))]


public class PlayerMover : MonoBehaviour {
    // private Rigidbody rb;
    private TouchDetector td;
    public GameObject gunHolderRef;

    public Text ammo;
    public Image health;

    public float currentHealth;
    public float maxHelath;

    public bool ProccedCollision = false;

    public float WeaponAngle;

    void Start() {
        // rb = GetComponent<Rigidbody>();
        td = GetComponent<TouchDetector>();
        currentHealth = maxHelath;
    }
    [SerializeField]
    float stepSize = 1f;

    private void Update() {
        // Keyboard events are tested each frame, so we should check them here.
        if (Input.GetKeyDown(KeyCode.Space)){
            // playerWantsToJump = true;
        }
        RotateWeapon(gunHolderRef);


    }

    /*
     * Note that updates related to the physics engine should be done in FixedUpdate and not in Update!
     */
    // private void FixedUpdate() {
    //     if (td.IsTouching()) {  // allow to walk and jump 
    //         // float horizontal = Input.GetAxis("Horizontal");
    //         // rb.AddForce(new Vector3(horizontal* walkForce, rb.velocity.y, rb.velocity.z), walkForceMode);
    //         // if (playerWantsToJump) {            // Since it is active only once per frame, and FixedUpdate may not run in that frame!
    //         //     rb.velocity = new Vector3(rb.velocity.x * slowDownAtJump, rb.velocity.y, rb.velocity.z);
    //         //     rb.AddForce(new Vector3(rb.velocity.x, jumpImpulse, rb.velocity.z), jumpForceMode);
    //         //     playerWantsToJump = false;
    //         // } 
    //         if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // up
    //         {
    //             transform.position += new Vector3(0, 0, -stepSize);
    //         }
    //         else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // down
    //         {
    //             transform.position += new Vector3(0, 0, stepSize);
    //         }
    //         else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // left
    //         {
    //             transform.position += new Vector3(stepSize, 0, 0);
    //         }
    //         else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // right
    //         {
    //             transform.position += new Vector3(-stepSize, 0, 0);
    //         }
    //     }
    // }

    public void playerHitted(float setDamage)
    {
        if(currentHealth < 0)
        {
            GameObject GameManager = GameObject.Find("GameManager");
            GameManager gameManagerScript = GameManager.GetComponent<GameManager>();
            gameManagerScript.SetLostPanel();

            
            //


            ///
        }
        currentHealth -= setDamage;
        health.fillAmount = currentHealth * 0.01f;
        
    }
    public void RotateWeapon(GameObject weapon)
    {
        //var mouse = Input.mousePosition;
        //WeaponAngle += Input.GetAxis("Mouse Y") * Time.deltaTime;
        ////WeaponAngle = Mathf.Clamp(WeaponAngle, 0, 180);
        //float y = WeaponAngle * Mathf.Rad2Deg;
        //weapon.transform.localRotation = Quaternion.AngleAxis(y,Vector3.right);
        //

        float mouseY = Input.GetAxis("Mouse Y");
        //Debug.Log("mouse x = " + _mouseX);
        Vector3 rotation = weapon.transform.localEulerAngles;
        rotation.x += mouseY * -0.35f;  // Rotation around the vertical (Y) axis
        weapon.transform.localEulerAngles = rotation;
        //
    }
    
}
