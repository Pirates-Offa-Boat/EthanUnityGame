using UnityEngine;

public class TileSelect : MonoBehaviour
{
   public GameObject Tower;
   public GameObject IndicatorPrefab;
   public GameObject Indicator;
   public bool selected = false;
   public bool filled = false;
   
   public void Select()
   {
      
      Debug.Log(gameObject.name + " selected!");
      selected = true;
      Indicator = Instantiate(IndicatorPrefab);
      Vector3 newPosition = gameObject.transform.position;
      newPosition.y += 0.2f;
      Indicator.transform.position = newPosition;
   }

   public void Deselect()
   {
      Debug.Log(gameObject.name + " deselected!");
      selected = false;
      Destroy(Indicator);
   }
}
