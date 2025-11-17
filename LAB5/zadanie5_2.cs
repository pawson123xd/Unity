using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class zadanie5_2 : MonoBehaviour
{
    public float speed = 1f;
    public GameObject target;
    private Vector3 start;

    
    void Start()
    {
        start = transform.position;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveToTarget());
        }
    }

    private IEnumerator MoveToTarget()
    {
        target.transform.position = start;
        start = transform.position;
        while (true)
        {
            Debug.Log("ok");
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            yield return null;
            if (Vector3.Distance(transform.position, target.transform.position) < 0.02f)
            {
                break;
            }
        }
        target.transform.position = start;
        start = transform.position;
        
    }
}
