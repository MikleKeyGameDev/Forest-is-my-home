using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]

public class ItemSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool _isQuantitative;

    [SerializeField] private FoodSO _foodSO;
    [SerializeField] private WeaponSO _weapon;

    public FoodSO Food { get { return _foodSO; } }
    public WeaponSO WeaponSO { get { return _weapon; } }
    public string Name { get { return _name; } }
    public Sprite Sprite { get { return _sprite; } }
    public bool IsQuatitative { get { return _isQuantitative; } }
}
