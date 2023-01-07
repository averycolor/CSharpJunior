using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class DeathView : MonoBehaviour
{
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Player _player;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _retryButton.onClick.AddListener(OnRetry);
        _quitButton.onClick.AddListener(OnQuit);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _retryButton.onClick.RemoveListener(OnRetry);
        _quitButton.onClick.RemoveListener(OnQuit);
    }

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    void OnDied() 
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        Time.timeScale = 0;
    }

    void OnQuit()
    {
        Application.Quit();
    }

    void OnRetry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
