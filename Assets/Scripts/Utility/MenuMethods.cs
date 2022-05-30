using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMethods : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;


    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
   
}
