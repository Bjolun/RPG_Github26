using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    
    private PlayerInputActions _input;
    public event EventHandler OnInteractAction;

    private bool isRunning = false;


    private void Awake()
    {
        _input = new PlayerInputActions();
        _input.Player.Interact.performed += InteractOnperformed;
    }

    private void InteractOnperformed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        Vector2 inputVector = _input.Player.Move.ReadValue<Vector2>();
        Vector3 movementVector = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += movementVector * (movementSpeed * Time.deltaTime);
        transform.forward = Vector3.Slerp(transform.forward, movementVector, rotationSpeed * Time.deltaTime);

        if (movementVector == Vector3.zero)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }

    }

    public bool IsRunning()
    {
        return isRunning;
    }
}
