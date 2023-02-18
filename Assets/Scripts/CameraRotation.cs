using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float xRotationSpeed;
    [SerializeField] private float yRotationSpeed;

    private Vector2 rotation;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * yRotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * xRotationSpeed * Time.deltaTime;

        rotation.x -= mouseY;
        rotation.y += mouseX;

        rotation.x = Mathf.Clamp(rotation.x, -90, 90);

        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
    }
}
