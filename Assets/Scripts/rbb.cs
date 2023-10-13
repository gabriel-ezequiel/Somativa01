using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 90f;

    private Rigidbody rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(movement));

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //transform.Rotate(Vector3.up, mouseX * turnSpeed * Time.deltaTime);
        //transform.Rotate(new Vector3(0, mouseX * turnSpeed * Time.deltaTime, 0));

        //transform.Rotate(new Vector3(mouseY * turnSpeed * Time.deltaTime, 0, 0));

    }
}
