using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public int speed = 7;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 movement = Vector3.right * x + Vector3.forward * z;
        characterController.Move(movement);
    }
}
