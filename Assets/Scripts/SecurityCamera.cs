using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SecurityCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _cutsceneObj = null;
    [SerializeField]
    private float _cutseneDelay = 0.5f;
    [SerializeField]
    private Color _alertColor = Color.red;
    private Animator _anim = null;
    private MeshRenderer _renderer = null;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();

        if (transform.parent != null)
        {
            _anim = GetComponentInParent<Animator>();
            if (_anim == null)
            {
                Debug.LogError("Animator is Null");
            }
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _renderer.material.SetColor("_TintColor", _alertColor);

            if (_anim != null)
            {
                _anim.enabled = false;
            }

            StartCoroutine(StartCutscene(other.gameObject));
        }
    }

    IEnumerator StartCutscene(GameObject other)
    {
        yield return new WaitForSeconds(_cutseneDelay);

        if (_cutsceneObj != null)
        {
            if (_cutsceneObj.activeInHierarchy == false)
            {
                _cutsceneObj.SetActive(true);
            }
        }

        other.SetActive(false);
    }
}
