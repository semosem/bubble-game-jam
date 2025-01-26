using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject youLostPanel;
    [SerializeField] private Button loseButton;
    [SerializeField] private Button winButton;
    
    [SerializeField] private GameObject[] obstacles;
    public bool isGameActive = true;
    
    private List<GameObject> spawnedObstacles = new List<GameObject>();
    
    private void Start()
    {
        youLostPanel.SetActive(false);
        loseButton.onClick.AddListener(ShowYouLostPanel);
        
        StartCoroutine(SpawnObstaclesRoutine());
    }

    private void ShowYouLostPanel()
    {
        youLostPanel.SetActive(true);
    }
    
    private IEnumerator SpawnObstaclesRoutine()
    {
        while (isGameActive)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-4, 4), 0, 30);
            GameObject spawned = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPosition, Quaternion.identity);
            spawnedObstacles.Add(spawned);
            yield return new WaitForSeconds(0.75f);
        }
    }
    
    public void DestroyObstacles()
    {
        foreach (var obstacle in spawnedObstacles)
        {
            Destroy(obstacle);
        }
    }
}
