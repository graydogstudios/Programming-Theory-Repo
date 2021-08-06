using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PLZBEINVISUALSTUDIO
public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;
    [SerializeField] public float speed = 1.0f;
    [SerializeField] public float horizontalInput;
    [SerializeField] public Rigidbody playerRb;
    [SerializeField] public float limitZ=5.0f;
    [SerializeField] public float gracePeriod = 1.0f;

    //Jump control
    [SerializeField] public float jumpSpeed = 5.0f;
    public bool isGrounded=true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
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

    public virtual void DestroyObject()
    { 
        if (transform.position.y < -10) 
        
        {
            gameManager.UpdateScore(2); 
            Destroy(gameObject);
            
                }  
    }
    public virtual void CapPosition()
    {
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ResetSpeed();
        paddlePos.z = Mathf.Clamp(transform.position.z, -limitZ, limitZ);
        transform.position = paddlePos;
    }

   public virtual void ResetSpeed()
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

    public virtual void CheckMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.forward * horizontalInput * speed * 2);
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
