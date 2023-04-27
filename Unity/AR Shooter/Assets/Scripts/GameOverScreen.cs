using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _contents;
    [SerializeField] private Button _retryButton;

    private void OnEnable()
    {
        _player.Died += OnPlayerDeath;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDeath;
    }

    private void OnPlayerDeath(Entity player)
    {
        Show();
    }

    private void Show()
    {
        _contents.SetActive(true);
        _retryButton.onClick.AddListener(Hide);
        Time.timeScale = 0f;
    }

    private void Hide()
    {
        _retryButton.onClick.RemoveListener(Hide);
        Time.timeScale = 1f;
        _contents.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
