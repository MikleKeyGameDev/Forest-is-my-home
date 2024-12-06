using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]

public class WeaponSO : ScriptableObject
{
    [SerializeField] private int _damage;

    public int Damage { get { return _damage; } }
}
