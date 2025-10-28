using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
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
        float camYRotation = Camera.main.transform.eulerAngles.y;
        if (camYRotation >= 140 && camYRotation <= 230)
        {
            transform.Rotate(new Vector3(mouseYMove, 0f, 0f), Space.Self);
        }
        else if (camYRotation > 230 && camYRotation <= 320)
        {
            transform.Rotate(new Vector3(0f, 0f, -mouseYMove), Space.Self);
        }
        else if (camYRotation > 50 && camYRotation <= 140)
        {
            transform.Rotate(new Vector3(0f, 0f, mouseYMove), Space.Self);
        }
        else
        {
            transform.Rotate(new Vector3(-mouseYMove, 0f, 0f), Space.Self);
        }
    }
}