using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void NextLevel(){
        SceneManager.LoadScene(3);
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
}
