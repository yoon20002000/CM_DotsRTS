using System;
using UnityEngine;

public class MouseWorldPosition : MonoBehaviour
{
    public static MouseWorldPosition Instance { get; private set; }
    
    [SerializeField]
    private Camera mainCamera;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public Vector3 GetPosition()
    {
        if (mainCamera != null)
        {
            Ray mouseCameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            // if (Physics.Raycast(mouseCameraRay, out RaycastHit raycastHit))
            // {
            //     return raycastHit.point;
            // }

            Plane plane = new Plane(Vector3.up, Vector3.zero);
            if (plane.Raycast(mouseCameraRay, out float distance))
            {
                return mouseCameraRay.GetPoint(distance);
            }
            else
            {
                return Vector3.zero;
            }
        }

        return Vector3.zero;
    }
}
