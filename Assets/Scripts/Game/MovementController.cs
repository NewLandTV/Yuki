using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    [SerializeField]
    private KeyCode moveRightKey = KeyCode.D;
    [SerializeField]
    private KeyCode moveLeftKey = KeyCode.A;

    private Vector2 moveDirection;

    private new Rigidbody2D rigidbody;

    private void Awake() => Initialize();

    private void Update() => InputKeys();

    private void FixedUpdate() => Move();

    private void Initialize() => rigidbody = GetComponent<Rigidbody2D>();

    private void InputKeys()
    {
        bool pressedRightKey = Input.GetKey(moveRightKey);
        bool pressedLeftKey = Input.GetKey(moveLeftKey);
        bool movable = (pressedRightKey || pressedLeftKey) && pressedRightKey != pressedLeftKey;

        if (!movable)
        {
            moveDirection = Vector2.zero;

            return;
        }

        if (pressedRightKey)
        {
            moveDirection = Vector2.right;
        }

        if (pressedLeftKey)
        {
            moveDirection = Vector2.left;
        }
    }

    private void Move()
    {
        if (moveDirection.sqrMagnitude == 0f)
        {
            return;
        }

        float x = moveDirection.x * moveSpeed;
        float y = rigidbody.velocity.y;

        Vector2 velocity = new Vector2(x, y);

        rigidbody.velocity = velocity;
    }
}
