using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StorySwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    
    private void Start()
    {
        StartCoroutine(SwitchStoryPages());
    }
    
    private IEnumerator SwitchStoryPages()
    {
        float progress = 0;
        
        foreach (var page in pages)
        {
            yield return new WaitForSeconds(2);
            Image pageImage = page.GetComponent<Image>();
            while (progress < 1)
            {
                progress += Time.deltaTime;
                pageImage.color = new Color(1, 1, 1, Mathf.Clamp01(1 - progress));
                yield return null;
            }
            progress = 0;
            page.SetActive(false);
        }
        
        SceneManager.LoadSceneAsync(GameManager.CurrentStory + 2);
    }
}
