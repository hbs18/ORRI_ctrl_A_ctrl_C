using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //[SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;

    void OnTriggerEnter2D(Collider2D obj){
        //source.PlayOneShot(clip);
        AudioSource.PlayClipAtPoint(clip, transform.position);
        Destroy(gameObject);
    }
}
