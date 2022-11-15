using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{

    private int sanitizers = 0;

    // Sound Effects
    [SerializeField] private AudioSource collectSoundEffect;

    [SerializeField] private Text sanitizerTxt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sanitizer"))
        {
            Destroy(collision.gameObject);
            collectSoundEffect.Play();
            sanitizers++;
            sanitizerTxt.text = sanitizers + "";
        }

    }
}
