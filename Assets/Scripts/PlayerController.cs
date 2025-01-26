using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float laneWidth = 2f;
    public float boundaryLimit = 3f;

    private float targetXPosition;

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