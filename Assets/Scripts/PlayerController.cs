using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public int speed = 7;
    public Transform CameraPostion;
    public int sensitivity = 77;
    float xRotation = 0f;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        PlayerMovement();
        CameraMovement();
    }
    void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 movement = Vector3.right * x + Vector3.forward * z;
        characterController.Move(movement);
    }
    void CameraMovement()
    {
        float xMouse = Input.GetAxis("Mouse X") * sensitivity *Time.deltaTime;
        float yMouse = Input.GetAxis("Mouse Y") * sensitivity*Time.deltaTime;
        xRotation = xRotation - yMouse;
        xRotation = Mathf.Clamp(xRotation, -77f, 90f);
        CameraPostion.localRotation = Quaternion.Euler(xRotation,0,0);
        transform.Rotate(Vector3.up * xMouse);
    }
}
