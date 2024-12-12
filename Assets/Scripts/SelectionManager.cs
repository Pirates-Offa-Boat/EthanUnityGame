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
       // Cast a ray from the camera to the mouse position
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

       // Define the ground plane, assuming tiles are on the X-Z plane at y = 0
       Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

       // Check if the ray intersects with the ground plane
       if (groundPlane.Raycast(ray, out float enter))
       {
           // Get the point of intersection
           Vector3 hitPoint = ray.GetPoint(enter);
           Debug.Log("Ray hit point on ground plane: " + hitPoint);

           // Find the nearest tile to the hitPoint within a certain radius
           float detectionRadius = 0.5f; // Adjust this value to your tile spacing
           Collider[] colliders = Physics.OverlapSphere(hitPoint, detectionRadius);

           TileSelect closestTile = null;
           float closestDistance = float.MaxValue;

           foreach (var collider in colliders)
           {
               TileSelect tileSelect = collider.GetComponent<TileSelect>();
               if (tileSelect != null)
               {
                   float distance = Vector3.Distance(hitPoint, tileSelect.transform.position);
                   if (distance < closestDistance)
                   {
                       closestDistance = distance;
                       closestTile = tileSelect;
                   }
               }
           }

           // If a valid tile is found, handle its selection
           if (closestTile != null)
           {
               Debug.Log("Closest tile found: " + closestTile.name);

               // Deselect the currently selected tile if it's different
               if (currentSelection != null)
               {
                   currentSelection.Deselect();
               }

               // Select the new tile
               currentSelection = closestTile;
               currentSelection.Select();
           }
           else
           {
               Debug.LogWarning("No valid tile found near the hit point.");
           }
       }
       else
       {
           Debug.LogWarning("Ray did not hit the ground plane.");
       }
   }
}
