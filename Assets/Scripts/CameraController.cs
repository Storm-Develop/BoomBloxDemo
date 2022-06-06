using BoomBoxEnums;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Transform target;

    private Vector3 previousPos;


    void Update()
    {
        //TODO Implement Command Pattern;
        if (Input.GetMouseButtonDown((int)MouseClicks.RightClick) || (Input.GetMouseButton((int)MouseClicks.MiddleClick)))
        {
            previousPos = mainCamera.ScreenToViewportPoint(Input.mousePosition * Time.deltaTime);
        }
         
        if (Input.GetMouseButton((int)MouseClicks.RightClick))
        {
            MoveCursor(MoveDirection.Horizontal);
        }

        if ((Input.GetMouseButton((int)MouseClicks.MiddleClick)))
        {
            MoveCursor(MoveDirection.Vertical);
        }
    }

    private void MoveCursor(MoveDirection moveDirection)
    {
        Vector3 direction = previousPos = mainCamera.ScreenToViewportPoint(Input.mousePosition * Time.deltaTime);

        mainCamera.transform.position = target.position;

        if (moveDirection==MoveDirection.Horizontal)
        {
            mainCamera.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
        }
        else
        {
            mainCamera.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
        }
        mainCamera.transform.Translate(new Vector3(0, 0, -10));

        previousPos = mainCamera.ScreenToViewportPoint(Input.mousePosition * Time.deltaTime);
    }
}
