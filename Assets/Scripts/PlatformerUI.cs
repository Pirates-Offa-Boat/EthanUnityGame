using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerUI : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
