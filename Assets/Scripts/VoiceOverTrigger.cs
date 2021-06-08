using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip _voiceOverClip = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_voiceOverClip != null)
            {
                AudioSource.PlayClipAtPoint(_voiceOverClip, Camera.main.transform.position);
            }
        }
    }
}
