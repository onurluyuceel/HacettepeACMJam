using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   public void PlayButtonClicked()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Build içindeki scene'lerde aktif sceneden sonraki sahneyi yüklüyor.

   }

    public void QuitButtonClicked()
    {
        Debug.Log("Quitted");
        Application.Quit();
    }
}
