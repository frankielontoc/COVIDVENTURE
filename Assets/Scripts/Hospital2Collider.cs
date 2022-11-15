using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hospital2Collider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hospital2"))
        {
            Invoke("LoadScene", 0.3f);
        }

    }

    void LoadScene()
    {
        SceneManager.LoadScene(5);
    }
}
