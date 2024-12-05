using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Animator), typeof (Collider2D))]
public class Item : MonoBehaviour
{
    private const string MaterialType = "Material";
    private const string WeaponType = "Weapon";
    private const string FoodType = "Food";

    [SerializeField] private ItemSO _itemSO;
    [SerializeField] private WeaponSO _weapon;
    [SerializeField] private FoodSO _foodSO;

    private string _type;

    private Collider2D _coll;
    private Animator _anim;

    public ItemSO SOItem { get { return _itemSO; } }
    public WeaponSO WeaponSO { get { return _weapon; } }
    public FoodSO Food { get { return _foodSO; } }
    
    public string TypeItem { get { return _type; } }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _coll = GetComponent<Collider2D>();

        if (_foodSO != null)
        {
            _type = FoodType;
        }
        else if(_weapon != null)
        {
            _type = WeaponType;
        }
        else
        {
            _type = MaterialType;
        }
    }

    public void LootItem()
    {
        StartCoroutine(TimeAnim());
    }

    private IEnumerator TimeAnim()
    {
        _anim.Play("Loot");
        _coll.enabled = false;
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}
