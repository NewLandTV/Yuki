using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private Weapon[] weapons;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform character;

    private Weapon equipWeapon;

    private void Update() => Equip();

    private void Equip()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ApplyWeapon(weapons[0]);
        }
    }

    private void ApplyWeapon(Weapon weapon)
    {
        if (equipWeapon != null)
        {
            Destroy(equipWeapon.gameObject);
        }

        equipWeapon = Instantiate(weapon, character.position, Quaternion.identity, player);

        float angle = Weapon.CalculateAngle(equipWeapon.transform.position);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        equipWeapon.transform.rotation = rotation;
    }
}
