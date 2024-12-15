using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "New Weapon Data")]
public class WeaponData : ScriptableObject
{
    public new string name = "My Weapon";
    public Sprite sprite;
    public int damage = 10;
    public float rate = 0.5f;
    public Type type;

    public enum Type
    {
        Gun
    }
}
