using UnityEngine;
public class zadanie3 : MonoBehaviour
{
    public float speed = 2.0f;
    private int move = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3[] moves;
    void Start()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        moves = new Vector3[]
        {
            new Vector3(speed * Time.deltaTime*0.5f, 0.0f, 0.0f),
            new Vector3(0.0f, 0.0f, speed * Time.deltaTime*0.5f),
            new Vector3(-speed * Time.deltaTime*0.5f, 0.0f, 0.0f),
            new Vector3(0.0f, 0.0f, -speed * Time.deltaTime*0.5f),
        };
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x >= 10 && transform.position.z <= 0) || (transform.position.x >= 10 && transform.position.z >= 10) || (transform.position.x <= 0 && transform.position.z >= 10))
        {
            move++;
            transform.Rotate(0.0f, 90.0f, 00.0f, Space.World);
        }
        else if (transform.position.x <= 0 && transform.position.z <= 0 && move==3)
        {
            transform.Rotate(0.0f, 90.0f, 00.0f, Space.World);
            move = 0;
        }
        transform.position = transform.position + moves[move];
    }
}
