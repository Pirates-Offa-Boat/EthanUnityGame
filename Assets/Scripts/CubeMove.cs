using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeMove : MonoBehaviour
{
   public Rigidbody body;
   public int jumpCount = 2;
   public int jumpTimer = 0;
   // Start is called before the first frame update
   void Start()
   {
      body = GetComponent<Rigidbody>();
      
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.W))
      {
         if (jumpCount > 0){
         body.velocity += new Vector3(0, 6, 0);
         jumpCount -= 1;
         }
      }

      if (Input.GetKey(KeyCode.D))
      { 
         if(body.velocity.x < 10){
         body.velocity += new Vector3(5, 0, 0);
         }
      }
      if (Input.GetKey(KeyCode.A))
      {
         if(body.velocity.x > -10){
         body.velocity += new Vector3(-5, 0, 0);
         }
         
      }
      if(body.velocity.y == 0){
         jumpTimer+=1;
         if(jumpTimer == 2){
            jumpCount = 2;
            jumpTimer = 0;
         }
      }
      if(Input.GetKeyDown(KeyCode.Space)){
         body.velocity = new Vector3(0,body.velocity.y,0);
      }
      if(body.position.y < -12){
         SceneManager.LoadScene("LoseMenu");
      }
   }
}
