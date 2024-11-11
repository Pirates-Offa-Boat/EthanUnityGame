using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    
       public void PlayGame(){ 
         SceneManager.LoadScene("Game");
      }
      public void QuitGame(){
         Application.Quit();
      }
      public void ReturnToMenu(){
         SceneManager.LoadScene("Menu");
      }
        public void ViewControls(){
         SceneManager.LoadScene("Controls");
      }


}
