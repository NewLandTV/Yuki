using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;

    private bool jumpKeyDown;
    private bool onGround;

    private new Rigidbody2D rigidbody;

    private void Awake() => Initialize();

    private void Update() => InputKeys();

    private void FixedUpdate()
    {
        CheckGround();
        TryJump();
    }

    private void Initialize() => rigidbody = GetComponent<Rigidbody2D>();

    private void InputKeys() => jumpKeyDown = Input.GetKeyDown(KeyCode.Space);

    private void CheckGround()
    {
        Vector2 origin = rigidbody.position;
        Vector2 size = new Vector2(0.9f, 0.1f);

        float angle = 90f;

        Vector2 direction = Vector2.down;

        float distance = 0.55f;

        RaycastHit2D hit = Physics2D.BoxCast(origin, size, angle, direction, distance, groundLayer);

        onGround = hit.collider != null;
    }

    private void TryJump()
    {
        bool canJump = jumpKeyDown && onGround;

        if (!canJump)
        {
            return;
        }

        Vector2 force = Vector2.up * jumpForce;

        ForceMode2D mode = ForceMode2D.Impulse;

        rigidbody.AddForce(force, mode);
    }
}
