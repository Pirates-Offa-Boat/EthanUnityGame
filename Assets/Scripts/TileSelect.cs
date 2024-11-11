using UnityEngine;

public class TileSelect : MonoBehaviour
{
   private Material originalMaterial;
   public Material selectedMaterial; // Assign a highlight material for visual feedback when selected
   public bool selected = false;

   public void Start()
   {
      originalMaterial = GetComponent<Renderer>().material;
   }

   public void Select()
   {
      GetComponent<Renderer>().material = selectedMaterial; // Change to selected material
      Debug.Log(gameObject.name + " selected!");
      selected = true;  
   }

   public void Deselect()
   {
      GetComponent<Renderer>().material = originalMaterial; // Revert to original material
      Debug.Log(gameObject.name + " deselected!");
      selected = false;
   }
}
