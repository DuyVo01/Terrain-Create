using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float walkMoveSpeed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        
    }

    private void FixedUpdate()
    {
        WalkMove(MovementDirectionRelatedToCameraDirection());
    }

    private void Rotation()
    {
        Quaternion targetFeetRotation = Quaternion.Euler(0, mainCamera.transform.rotation.eulerAngles.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetFeetRotation, rotationSpeed * Time.deltaTime);
    }

    private Vector3 MovementDirectionRelatedToCameraDirection()
    {
        Vector3 movementDirection;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection = movementDirection.x * mainCamera.transform.right.normalized + movementDirection.z * mainCamera.transform.forward.normalized;
        movementDirection.y = 0;

        return movementDirection;
    }

    public void WalkMove(Vector3 movementDirection)
    {
        Vector3 playerHorizontalVelocity = playerRb.velocity;
        playerHorizontalVelocity.y = 0f;
        Vector3 finalSpeed = walkMoveSpeed * movementDirection;
        Vector3 speedDif = finalSpeed - playerHorizontalVelocity;
        float accelRate = 5;
        Vector3 movement = accelRate * speedDif;
        playerRb.AddForce(movement, ForceMode.Acceleration);
    }
}
