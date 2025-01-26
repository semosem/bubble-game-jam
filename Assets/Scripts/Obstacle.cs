using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Update()
    {
        // Move the obstacle towards the player
        transform.Translate(Vector3.back * Time.deltaTime * 5);
        
        if (transform.position.z < -2)
        {
            Destroy(gameObject);
        }
    }
}
