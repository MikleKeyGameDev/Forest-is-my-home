using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]

public class WeaponSO : ScriptableObject
{
    [SerializeField] private float _damage;

    public float Damage { get { return _damage; } }
}
