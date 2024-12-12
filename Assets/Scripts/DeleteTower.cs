using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTower : MonoBehaviour
{
   public GameObject Tower;



   public void deleteTower()
   {
      

      var sm = FindObjectOfType<SelectionManager>();
      var cs = sm.currentSelection;

      if (cs.filled == true && cs)
      {
         var go = cs.Tower;
         LevelManager.main.gold += (go.GetComponent<TowerScript>().cost /2);

         Destroy(go);
         cs.filled = false;
      }

   }
}
