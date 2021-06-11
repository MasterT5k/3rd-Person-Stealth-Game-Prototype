using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private GameObject _startCutscene = null;
    [SerializeField]
    private float _skipToTime = 60f;
    private PlayableDirector _director = null;
    private bool _hasKeycard = false;

    private void Start()
    {
        if (_startCutscene != null)
        {
            if (_startCutscene.activeInHierarchy == false)
            {
                _startCutscene.SetActive(true);
            }
            _director = _startCutscene.GetComponent<PlayableDirector>();
            _director.Play();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (_director != null)
            {
                _director.time = _skipToTime;
            }
        }
    }

    public void SetKeycard(bool collectedCard)
    {
        _hasKeycard = collectedCard;
    }

    public bool CheckForKeycard()
    {
        return _hasKeycard;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}
