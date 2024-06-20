using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class PlayerControls : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput _playerInput;
    private Rigidbody2D _rb;
    
    private PlayerInputActions _playerInputActions;
    private InputAction _moveInput;
    private InputAction _runInput;

    [Header("Movement")]
    [SerializeField] private float _walkSpeed = 200f;
    [SerializeField] private float _runSpeedMultiplier = 1.8f;
    
    [Header("Animation")]
    [SerializeField]private GameObject _parentRenderer;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        
        // creating the instance of input actions our player has access to
        // and making sure if this script is added to an object the inputs are set to events
        _playerInputActions = new PlayerInputActions();
        _playerInput.currentActionMap = _playerInputActions.Player;
        _playerInput.notificationBehavior = PlayerNotifications.InvokeCSharpEvents;
    }

    private void OnEnable()
    {
        _playerInputActions.Player.Interact.performed += Interact;
        _playerInputActions.Player.Interact.Enable();
        
        _moveInput = _playerInputActions.Player.Move;
        _moveInput.Enable();
        
        _runInput = _playerInputActions.Player.Run;
        _runInput.Enable();
    }
    

    private void Interact(InputAction.CallbackContext obj)
    {
        Debug.Log("Interacting");
    }
    

    private void FixedUpdate()
    {
        Move();
        SelectAnimation();
    }


    private void Move()
    {
        _rb.velocity = CalculateVelocity();
    }

    private Vector2 CalculateVelocity()
    {
        //assigning the speed multiplier
        float speedMultiplier = _runInput.IsPressed() ? _runSpeedMultiplier : 1;
        
        //reading direction input
        Vector2 moveVelocity = _moveInput.ReadValue<Vector2>();
        moveVelocity *= (_walkSpeed * Time.deltaTime * speedMultiplier);
        
        return moveVelocity;
    }
    private void SelectAnimation()
    {
        _animator.SetFloat("MovementSpeed",_rb.velocity.magnitude);

        if (_rb.velocity.magnitude < 0.1f) return;
        
        //checking if we are moving left
        int lookLeft = _rb.velocity.x > 0 ? 1 : -1;
        // I don't like doing it this way but the animations on the asset reduced of my options
        _parentRenderer.transform.localScale = new Vector3(lookLeft, 1, 1);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Interact.Disable();
        _moveInput.Disable();
    }
}
