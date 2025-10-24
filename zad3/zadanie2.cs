using UnityEngine;

public class zadanie2 : MonoBehaviour
{
    public float speed = 2.0f;
    void Start()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
    void Update()
    {
        if (transform.position.x>=10 ||transform.position.x<=0)
        {
            speed *= -1;
        }
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        
    }
}
