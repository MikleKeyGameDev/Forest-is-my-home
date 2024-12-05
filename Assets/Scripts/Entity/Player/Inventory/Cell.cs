using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Image))]

public class Cell : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject _butEat;
    [SerializeField] private GameObject _butDell;
    [SerializeField] private GameObject _butUse;

    [SerializeField] private Text _textQuantity;

    [Header("DataItem")]
    [SerializeField] private string _nameItem;
    [SerializeField] private ItemSO _item;

    [Header("DataCell")]
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private int _quantity;
    [SerializeField] private int _maxQuantity;

    private Image _image;

    public ItemSO Item_SO { get { return _item; } }

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        SetSprite();
        SwitchButtons();
        SetText();
    }

    public bool AddToQuatitative(ItemSO item)
    {
        if(_nameItem == item.Name && _quantity < _maxQuantity)
        {
            _quantity++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddToVoid(ItemSO item)
    {
        if (_quantity <= 0)
        {
            _nameItem = item.Name;
            _item = item;
            _quantity++;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetText()
    {
        if(_quantity > 0)
        {
            _textQuantity.text = _quantity.ToString();
        }
        else if( _quantity <= 0)
        {
            _textQuantity.text = null;
        }
    }

    private void SetSprite()
    {
        if(_quantity <= 0)
        {
            _image.sprite = _defaultSprite;
            _item = null;
            _nameItem = null;
        }
        else
        {
            _image.sprite = _item.Sprite;
        }
    }

    private void SwitchButtons()
    {
        if (_quantity > 0)
        {
            if (_item.Food != null)
            {
                _butEat.SetActive(true);

                _butUse.SetActive(false);
            }
            else if(_item.WeaponSO != null)
            {
                _butUse.SetActive(true);

                _butEat.SetActive(false);
            }

            _butDell.SetActive(true);
        }
        else
        {
            _butEat.SetActive(false);
            _butDell.SetActive(false);
            _butUse.SetActive(false);
        }
    }

    public void DelleteItem()
    {
        _quantity--;
    }
}
