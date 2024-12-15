using UnityEngine;

public class Gun : Weapon
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletSpawnPoint;

    public override void Attack()
    {
        if (Time.time < attackTime)
        {
            return;
        }

        attackTime = Time.time + weaponData.rate;

        Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        GameObject instance = Instantiate(bullet, bulletSpawnPoint.position, rotation);

        instance.transform.localRotation = rotation;
    }
}
