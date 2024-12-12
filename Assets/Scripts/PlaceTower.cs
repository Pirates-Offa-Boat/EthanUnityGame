using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Tower;
    
    public void spawnTower(){
      int cost =  Tower.GetComponent<TowerScript>().cost;

      var sm = FindObjectOfType<SelectionManager>();
      var cs = sm.currentSelection;

      if (cs != null && !cs.filled && LevelManager.main.gold >= cost)
      {
         var go = Instantiate(Tower);

         // Adjust the position of the tower
         Vector3 tilePosition = cs.transform.position;

         // Offset the tower's position by 0.25 units above the tile
         Vector3 towerPosition = tilePosition;
         towerPosition.y += 0.2f;

         go.transform.position = towerPosition;

         Debug.Log($"Tower placed at position: {towerPosition}");

         // Update selection and resources
         cs.filled = true;
         cs.Tower = go;
         LevelManager.main.gold -= cost;
      }
   }
}
