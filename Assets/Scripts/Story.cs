using UnityEngine;

public class Story : MonoBehaviour
{
    [SerializeField] private GameObject[] stories;
    
    private void Awake()
    {
        SetStoryUI();
    }

    private void SetStoryUI()
    {
        foreach (var story in stories)
        {
            story.SetActive(false);
        }

        if (GameManager.CurrentStory <= stories.Length)
        {
            stories[GameManager.CurrentStory].SetActive(true);
        }
        else
        {
            Debug.LogError("Scene not loaded");
        }
    }
}
