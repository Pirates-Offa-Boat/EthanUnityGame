using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : MonoBehaviour
{
private void OnTriggerStay(Collider other)
   {

      
      var pirate = other.GetComponent<Enemy>();

      
      pirate.life -= 20*Time.deltaTime;
   }
}
