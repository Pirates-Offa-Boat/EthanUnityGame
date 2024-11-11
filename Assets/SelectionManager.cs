using UnityEngine;

public class SelectionManager : MonoBehaviour
{
   public TileSelect currentSelection;

   void Update()
   {
      if (Input.GetMouseButtonDown(0)) // Detect left mouse button click
      {
         SelectObjectUnderCursor();
      }
   }

   void SelectObjectUnderCursor()
   {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      if (Physics.Raycast(ray, out hit))
      {
         if (hit.collider.gameObject.layer == LayerMask.NameToLayer("UI"))
            return;

         Debug.Log("Raycast hit: " + hit.collider.gameObject.name); // Log what was hit

         TileSelect tileSelect = hit.collider.GetComponent<TileSelect>();

         if (tileSelect != null)
         {
            Debug.Log("Selectable tile found: " + tileSelect.gameObject.name);

            // Deselect previous selection if there is one
            if (currentSelection != null)
            {
               if(currentSelection == tileSelect){
               currentSelection.Deselect();
                  currentSelection = null;
               }else{
                  currentSelection.Deselect();
                  currentSelection = tileSelect;
                  currentSelection.Select();
               }
            }else{

            // Select the new object and update currentSelection
            currentSelection = tileSelect;
               currentSelection.Select();
            }
         }
         else
         {
            Debug.LogWarning("TileSelect component not found on " + hit.transform.name);
         }
      }
      else
      {
         Debug.Log("Raycast did not hit any objects.");
      }
   }
}
