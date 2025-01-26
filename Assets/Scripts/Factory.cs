using UnityEngine;

public class Factory : MonoBehaviour
{
    public bool Move = true;
    
    void Update()
    {
        if (transform.position.z > -10 && Move)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 5);
        }
    }
}
