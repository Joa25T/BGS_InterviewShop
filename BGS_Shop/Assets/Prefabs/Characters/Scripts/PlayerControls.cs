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
    private Collider2D _collider;
    
    private PlayerInputActions _playerInputActions;
    private InputAction _moveInput;
    private InputAction _runInput;
    private InputAction _interactInput;

    [Header("Movement")]
    [SerializeField] private float _walkSpeed = 200f;
    [SerializeField] private float _runSpeedMultiplier = 1.8f;
    
    [Header("Animation")]
    [SerializeField]private GameObject _parentRenderer;
    [SerializeField]private CanvasRenderer _interactPopUp;
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
        //caching in the Input Actions as we need to read their values in different methods instead of calling a specific one
        _interactInput = _playerInputActions.Player.Interact;
        _interactInput.Enable();
        
        _moveInput = _playerInputActions.Player.Move;
        _moveInput.Enable();
        
        _runInput = _playerInputActions.Player.Run;
        _runInput.Enable();
    }

    private void FixedUpdate()
    {
        Move();
        SelectAnimation();
    }
    
    private void Move()
    {
        _rb.velocity = CalculateVelocity();
        
        //applying a force zero so the rigid-body doesn't go to sleep preventing us from opening the ui
        _rb.AddForce(Vector2.zero);
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

    private void OnTriggerStay2D(Collider2D other)
    {
        //UIManager.Instance.OpenPanel(_interactPopUp);
        if (_interactInput.ReadValue<float>() < 0.1f) return;
        if (other.TryGetComponent(out Interactable interactable))
        {
            interactable.OnInteract(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            interactable.CloseUIPanel();
        }
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Interact.Disable();
        _moveInput.Disable();
    }
}
