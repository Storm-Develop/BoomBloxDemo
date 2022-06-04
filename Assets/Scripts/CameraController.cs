using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Transform target;

    private const int MiddleClick = 2;

    private const int RightClick = 1;
    private float turnSpeed = 5f;

    private Vector3 previousPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //TODO Implement Command Pattern;
        if (Input.GetMouseButtonDown(RightClick) || (Input.GetMouseButton(MiddleClick)))
        {
            previousPos = mainCamera.ScreenToViewportPoint(Input.mousePosition * Time.deltaTime);
        }
         
        if (Input.GetMouseButton(RightClick))
        {
            Vector3 direction = previousPos = mainCamera.ScreenToViewportPoint(Input.mousePosition * Time.deltaTime) ;


            mainCamera.transform.position = target.position;

           // mainCamera.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            mainCamera.transform.Rotate(new Vector3(0, 1, 0), - direction.x * 180, Space.World);

            mainCamera.transform.Translate(new Vector3(0,0, -10));

            previousPos = mainCamera.ScreenToViewportPoint(Input.mousePosition * Time.deltaTime);

        }

        if ((Input.GetMouseButton(MiddleClick)))
        {
            Vector3 direction = previousPos = mainCamera.ScreenToViewportPoint(Input.mousePosition * Time.deltaTime);

            mainCamera.transform.position = target.position;

            mainCamera.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);

            mainCamera.transform.Translate(new Vector3(0, 0, -10));

            previousPos = mainCamera.ScreenToViewportPoint(Input.mousePosition * Time.deltaTime);

        }
    }
}
