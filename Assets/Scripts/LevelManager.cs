using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public enum Levels { Menu = 0, Level01 = 1, Level02 = 2,};
    public int Escena;
    public void ChangeLevel(Levels level)
    {
        SceneManager.LoadScene((int)level);
    }

    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        
        Application.Quit();
    }

    /*Aun no se usa*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ChangeLevel(Escena);
        }
    }
}
