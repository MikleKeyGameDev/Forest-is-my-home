using UnityEngine;
using UnityEngine.UI;

public class CellHendRight : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject _butRemove;

    [Header("DataItem")]
    [SerializeField] private ItemSO _item;

    [Header("DataCell")]
    [SerializeField] private Sprite _defaultSprite;

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
    }

    public bool AddToItem(ItemSO item)
    {
        if (_item == null)
        {
            _item = item;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetSprite()
    {
        if (_item == null)
        {
            _image.sprite = _defaultSprite;
        }
        else
        {
            _image.sprite = _item.Sprite;
        }
    }

    private void SwitchButtons()
    {
        if(_item != null)
        {
            _butRemove.SetActive(true);
        }
        else
        {
            _butRemove.SetActive(false);
        }
    }

    public void DelleteItem()
    {
        _item = null;
    }
}
