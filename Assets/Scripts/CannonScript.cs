using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{

   float counter = 0;
   private void OnTriggerStay(Collider other)
   {

      
      var pirate = other.GetComponent<Enemy>();

      
      counter+=Time.deltaTime;
      
      if(counter >=0.5){

         if (pirate != null)
         {

            pirate.life -= 15;
            counter = 0;
         }
         
      }
   }
}
