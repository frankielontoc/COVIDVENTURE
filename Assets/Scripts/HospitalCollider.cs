using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HospitalCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hospital"))
        {
            Invoke("LoadScene", 0.3f);
        }

    }

    void LoadScene()
    {
        SceneManager.LoadScene(4);
    }
}
