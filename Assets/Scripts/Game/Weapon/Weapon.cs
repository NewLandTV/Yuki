using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected WeaponData weaponData;
    public WeaponData WeaponData => weaponData;
    public string WeaponName => weaponData.name;

    protected Transform target;

    [SerializeField]
    protected bool followTarget = true;
    [SerializeField]
    protected bool followAround = true;

    protected float angle;
    protected float attackTime;

    protected Camera mainCamera;

    public abstract void Attack();

    protected void Awake() => Initialize();

    protected void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }

        FollowTarget();
        FollowAround();
    }

    public static float CalculateAngle(Vector3 position)
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 direction = Camera.main.ScreenToWorldPoint(mousePosition) - position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle;
    }

    private void Initialize()
    {
        target = FindObjectOfType<Character>().transform;

        mainCamera = Camera.main;
    }

    private void FollowTarget()
    {
        if (!followTarget)
        {
            return;
        }

        transform.position = target.position;
    }

    private void FollowAround()
    {
        if (!followAround)
        {
            return;
        }

        angle = CalculateAngle(transform.position);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = rotation;
    }
}
