using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MissileController
{
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameManager.score);
        transform.position += new Vector3(-1  -gameManager.score/ 100, 0, 0) * Time.deltaTime * forwardSpeed;
        CheckMove();


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();

        }
        DestroyObject();
       
    }

    public override void Jump()
    {
        isGrounded = false;
        playerRb.AddForce(new Vector3(-1,0,0) * jumpSpeed, ForceMode.Impulse);
        StartCoroutine("JumpCoolDown");
    }

    public override void DestroyObject()
    {
        if (transform.position.y < -10)

        {
            gameManager.UpdateScore(1);
            Destroy(gameObject);

        }
    }

    IEnumerator JumpCoolDown()
    {

        yield return new WaitForSeconds(20.0f);
        //CanJumpAgain();
        //   return null;
        isGrounded = true;
    }
}
