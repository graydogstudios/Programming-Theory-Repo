using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField]private float speed=5.0f;
    [SerializeField] private float horizontalInput;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float limitZ;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.left * horizontalInput * speed * 2);

        
      //  if (player.transform.position.z > limitZ )

    //    {
     //       player.transform.position.z = limitZ;
     //   }
     //   if (player.transform.z < -limitZ)

     //   {
     //       player.transform.z = -limitZ
     //   }
    }
}
