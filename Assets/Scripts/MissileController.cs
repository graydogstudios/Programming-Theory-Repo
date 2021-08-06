using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PLZBEINVISUALSTUDIO
public class MissileController : PlayerController
{
  //  [SerializeField] public GameObject missile;
   // [SerializeField] private float speed = 1.0f;
    [SerializeField] public float forwardSpeed = 1.0f;
  //  [SerializeField] private float horizontalInput;
  //  [SerializeField] private Rigidbody missileRb;
  //  [SerializeField] private float limitZ = 5.0f;
   // [SerializeField] private float gracePeriod = 1.0f;
    [SerializeField] private float offset=2.0f;
    //Jump control
 //   [SerializeField] private float jumpSpeed = 5.0f;
 //   public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1,0,0) * Time.deltaTime*forwardSpeed;
        CheckMove();


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();

        }

        //  if (player.transform.position.z > limitZ)

        // {
        //     player.transform.position.z = limitZ;
        // }
        // if (player.transform.z < -limitZ)

        //  {
        //      player.transform.z = -limitZ;
        //  }

        CapPosition();
        DestroyObject();
    }

    public override void CapPosition()
    {
        Vector3 missilePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ResetSpeed();
        missilePos.z = Mathf.Clamp(transform.position.z, -limitZ+offset, limitZ-offset);
        transform.position = missilePos;
    }

   

    public override void Jump()
    {
        isGrounded = false;
        playerRb.AddForce(Vector3.forward * jumpSpeed, ForceMode.Impulse);
        StartCoroutine("JumpCoolDown");


    }

    
    IEnumerator JumpCoolDown()
    {

        yield return new WaitForSeconds(2.0f);
        //CanJumpAgain();
        //   return null;
        isGrounded = true;
    }

    // void CanJumpAgain()
    //  { isGrounded = true; }







}
