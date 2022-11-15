using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VirusCollider : MonoBehaviour
{

    // Sound Effects
    Renderer rend;
    Color c;
    [SerializeField] private AudioSource deadSoundEffect;

    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Virus"))
        {
            StartCoroutine("GetHurt");
            Destroy(collision.gameObject);
            deadSoundEffect.Play();
            Invoke("LoadScene", 0.5f);
        }

    }
    IEnumerator GetHurt(){
        
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        rend.material.color = Color.white;
    }

    void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
