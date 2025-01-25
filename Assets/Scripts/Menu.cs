using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
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
