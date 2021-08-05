using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PLZBEINVISUALSTUDIO
public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float horizontalInput;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float limitZ=5.0f;
    [SerializeField] private float gracePeriod = 1.0f;

    //Jump control
    [SerializeField] private float jumpSpeed = 5.0f;
    public bool isGrounded=true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.forward * horizontalInput * speed * 2);

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
    }

    void CapPosition()
    {
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ResetSpeed();
        paddlePos.z = Mathf.Clamp(transform.position.z, -limitZ, limitZ);
        transform.position = paddlePos;
    }

    void ResetSpeed()
    {
        //Reset player velocity if a bound is reached, so player can move more easily
        if (transform.position.z < -limitZ * gracePeriod || transform.position.z > limitZ * gracePeriod)
        {
            playerRb.velocity = Vector3.zero; 
        
        }

    }

    public virtual void Jump()
    {
        isGrounded = false;
        playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
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
