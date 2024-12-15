using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 11.11f;
    [SerializeField]
    private float randomSizeDelta = 1.11f;

    private void Awake() => Initialize();

    private void Initialize()
    {
        transform.localScale = Vector3.one * Random.Range(-randomSizeDelta, randomSizeDelta);
    }

    private void Update() => MoveForward();

    private void MoveForward()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
