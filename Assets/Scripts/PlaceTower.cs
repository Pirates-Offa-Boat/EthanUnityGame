using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Tower;
   


    public void spawnTower(){
      int cost =  Tower.GetComponent<CannonScript>().cost;

      var sm = FindObjectOfType<SelectionManager>();
      var cs = sm.currentSelection;

      if (cs.filled == false && LevelManager.main.gold >= cost)
        {
      var go = Instantiate(Tower);

         Debug.Log(cs.transform.position);
         go.transform.position = cs.transform.position;
         cs.filled = true;
         cs.Tower = go;
            LevelManager.main.gold -= cost;
      }

   }
}
