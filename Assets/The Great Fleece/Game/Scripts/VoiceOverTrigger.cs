using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _voiceOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(_voiceOver, Camera.main.transform.position);
        }
    }
}
