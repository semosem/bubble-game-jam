using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float laneWidth = 2f;
    public float boundaryLimit = 2f;

    private float targetXPosition;
    
    [SerializeField] private Animator animator;
    [SerializeField] private GameController gameController;
    [SerializeField] private Factory factory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            animator.SetTrigger("Die");
            gameController.isGameActive = false;
            gameController.DestroyObstacles();
            gameController.ShowYouLostPanel();
            factory.Move = false;
            
            Invoke("GoToMenu", 10);
        }
    }

    private IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(2);
        
        gameController.ShowYouLostPanel();
        
        yield return new WaitForSeconds(2);
        
        SceneManager.LoadSceneAsync(0);
    }
    
    void Start()
    {
        targetXPosition = transform.position.x;
    }

    void Update()
    {
        HandleInput();
        MovePlayer();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            targetXPosition -= laneWidth;
            targetXPosition = Mathf.Clamp(targetXPosition, -boundaryLimit, boundaryLimit);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            targetXPosition += laneWidth;
            targetXPosition = Mathf.Clamp(targetXPosition, -boundaryLimit, boundaryLimit);
        }
    }

    void MovePlayer()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(targetXPosition, currentPosition.y, currentPosition.z);

        transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * moveSpeed);
    }
}