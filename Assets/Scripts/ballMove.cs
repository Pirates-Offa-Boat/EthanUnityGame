using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour
{
   private float velocity = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKey(KeyCode.Space))
      {
         this.transform.position += new Vector3(0, velocity, 0);
      }
      if (Input.GetKey(KeyCode.LeftControl))
      {
         this.transform.position -= new Vector3(0, velocity, 0);
      }
      if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
      {
         this.transform.position += new Vector3(velocity, 0, 0);
      }
      if (Input.GetKey(KeyCode.A))
      {
         this.transform.position -= new Vector3(velocity, 0, 0);
      } //move that ball
   }
}
