using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie4 : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;

    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation=Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation=Quaternion.identity;
        }
        // pobieramy wartości dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        // wykonujemy rotację wokół osi Y
        player.Rotate(Vector3.up * mouseXMove);
        // a dla osi X obracamy kamerę dla lokalnych koordynatów
        // -mouseYMove aby uniknąć ofektu mouse inverse
        float camYRotation = Camera.main.transform.eulerAngles.y;;
        Vector3 rot = transform.eulerAngles;
        Debug.Log(rot.z);
        if (rot.y != 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }
        if (rot.x == 270)
        {
            transform.rotation = Quaternion.Euler(-89.9f, 0, transform.eulerAngles.z);
        }
        if (rot.x == 90)
        {
            transform.rotation = Quaternion.Euler(89.9f, 0, transform.eulerAngles.z);
        }
        if (rot.z < 270 && rot.z >= 260 )
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 0, -89.9f);
        }
        if (rot.z >= 90 && rot.z <= 100)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 0, 89.9f);
        }
        if (camYRotation >= 140 && camYRotation <= 230 )
        {
            float mouseYMovelimit = Mathf.Clamp(mouseYMove, -0.2f, 0.2f);
            transform.Rotate(new Vector3(mouseYMovelimit, 0f, 0f), Space.Self);
        }
        else if (camYRotation > 230 && camYRotation <= 320 )
        {
            float mouseYMovelimit = Mathf.Clamp(mouseYMove, -0.2f, 0.2f);
            transform.Rotate(new Vector3(0f, 0f, -mouseYMovelimit), Space.Self);
        }
        else if (camYRotation > 50 && camYRotation <= 140 )
        {
            float mouseYMovelimit = Mathf.Clamp(mouseYMove, -0.2f, 0.1f);
            transform.Rotate(new Vector3(0f, 0f, mouseYMovelimit), Space.Self);
        }
        else
        {
            float mouseYMovelimit = Mathf.Clamp(mouseYMove, -0.2f, 0.2f);
            transform.Rotate(new Vector3(-mouseYMovelimit, 0f, 0f), Space.Self);
        }
        
    }
}