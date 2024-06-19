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

    [Header("Movement")]
    [SerializeField] private float _walkSpeed = 200f;
    [SerializeField] private float _runSpeed = 400f;

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
    }
    
    void Start()
    {
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        Debug.Log("Interacting");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveVelocity = _moveInput.ReadValue<Vector2>();
        moveVelocity *= (_walkSpeed * Time.deltaTime);
        _rb.velocity = moveVelocity;
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
