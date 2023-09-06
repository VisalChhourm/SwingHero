using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region Inspector

    /// <summary>
    /// Movement speed per second of this character
    /// </summary>
    [SerializeField]
    private float _moveSpeed = 10;
    /// <summary>
    /// True if the character's currently facing the right
    /// </summary>
    [SerializeField]
    private bool _isFacingRight = false;

    #endregion

    #region Fields

    /// <summary>
    /// Component for controlling character's physics body. We will be using it for moving this character
    /// </summary>
    private Rigidbody2D _rigidBody;
    /// <summary>
    /// Component for controlling character's animation
    /// </summary>
    private Animator _animator;

    #endregion

    #region Properties

    /// <summary>
    /// Direction that this character is moving toward
    /// </summary>
    public Vector2 moveDirection { get; set; }
    /// <summary>
    /// Component for controlling character's physics body. We will be using it for moving this character
    /// </summary>
    public Rigidbody2D rigidBody => _rigidBody;
    /// <summary>
    /// True if the character's currently facing the right. Change this property's value will also rotate this character's facing.
    /// </summary>
    public bool isFacingRight
    {
        get { return _isFacingRight; }
        set
        {
            if (value != _isFacingRight)
            {
                _isFacingRight = value;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
    }

    #endregion

    #region Unity Callbacks

    /// <summary>
    /// Awake call once at the very first of the object's life cycle
    /// </summary>
    protected void Awake()
    {
        // Get rigidbody component and animator component that attached to this game object for later use

        _rigidBody = GetComponent<Rigidbody2D>();
        if (_rigidBody == null)
        {
            _rigidBody = gameObject.AddComponent<Rigidbody2D>();
        }

        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            _animator = GetComponentInChildren<Animator>();
        }
    }

    /// <summary>
    /// Update call every frame. Game Logic loop should be written in it.
    /// </summary>
    protected void Update()
    {
        HandleUserInput();
        HandleAnimation();
    }

    /// <summary>
    /// FixedUpdate call every physics update step. Logic related to physics should be written in it.
    /// </summary>
    protected void FixedUpdate()
    {
        Vector2 vel = moveDirection * _moveSpeed;
        _rigidBody.velocity = vel;
        if (moveDirection.x != 0)
        {
            isFacingRight = moveDirection.x > 0;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Get user input to update moveDirection
    /// </summary>
    protected virtual void HandleUserInput()
    {
        moveDirection = new Vector2
        {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical")
        };
    }

    /// <summary>
    /// Handle character's animation
    /// </summary>
    protected virtual void HandleAnimation()
    {
        if (_animator != null)
        {
            bool isMoving = moveDirection.x != 0 || moveDirection.y != 0;
            _animator.SetBool("IsMoving", isMoving);
        }
    }

    #endregion
}
