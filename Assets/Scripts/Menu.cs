using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private GameObject creditsPanel;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
        creditsButton.onClick.AddListener(ToggleCredits);
    }

    private void ToggleCredits()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        GameManager.CurrentStory = 0;
        SceneManager.LoadSceneAsync(1);
    }
}
