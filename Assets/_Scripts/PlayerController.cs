using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float fastMultiplier = 2f;
    public float slowMultiplier = 0.5f;
    public float mouseSensitivity = 2f;
    public float verticalLookLimit = 85f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotationX = rot.x;
        rotationY = rot.y;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        if (Mouse.current == null) return;
        Vector2 mouseDelta = Mouse.current.delta.ReadValue() * mouseSensitivity;
        rotationY += mouseDelta.x;
        rotationX -= mouseDelta.y;
        rotationX = Mathf.Clamp(rotationX, -verticalLookLimit, verticalLookLimit);
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    void HandleMovement()
    {
        float speed = moveSpeed;
        Vector3 direction = Vector3.zero;
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            speed *= fastMultiplier;
        }
        if (Keyboard.current.leftAltKey.isPressed)
        {
            speed *= slowMultiplier;
        }
        if (Keyboard.current.wKey.isPressed) 
        {
            direction += transform.forward;
        }
        if (Keyboard.current.sKey.isPressed) 
        {
            direction -= transform.forward;
        }
        if (Keyboard.current.aKey.isPressed) 
        {
            direction -= transform.right;
        }
        if (Keyboard.current.dKey.isPressed) 
        {
            direction += transform.right;
        }
        if (Keyboard.current.spaceKey.isPressed) 
        {
            direction += Vector3.up;
        }
        if (Keyboard.current.leftCtrlKey.isPressed) 
        {
            direction -= Vector3.up;
        }
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
