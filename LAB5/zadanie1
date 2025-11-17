using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie1 : MonoBehaviour
{
    public float speed = 1f;
    public GameObject target;
    private Vector3 start;
    private GameObject player;
    private Vector3 lastPos;
    
    void Start()
    {
        lastPos = transform.position;
        start = transform.position;
        player= GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 0.02f)
            { 
                target.transform.position = start;
                start = transform.position;
            }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);;
        player.transform.position += transform.position - lastPos;
        lastPos = transform.position;
        }
    }

}
