using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip _voiceOverClip = null;
    private bool _hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_voiceOverClip != null && _hasPlayed == false)
            {
                _hasPlayed = true;
                AudioSource.PlayClipAtPoint(_voiceOverClip, Camera.main.transform.position);
            }
        }
    }
}
