using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private GameObject _uiHelp;
    [SerializeField] private GameObject _inventory;

    private Item _item;
    private Nature _nature;

    private bool _isItem;
    private bool _isNature;

    private bool _isActiveInventory;

    private void Update()
    {
        ShowHelpUI();
        Collect();
        SwitchInventory();
    }

    private void Collect()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (_isItem == true)
            {
                if (_inventory.GetComponent<Inventory>().SortingItems(_item.SOItem))
                {
                    _item.LootItem();
                    return;
                }
                else
                {
                    Debug.Log("Инвентарь полон!");
                    return;
                }
            }
            else if (_isNature == true)
            {
                ItemSO item = _nature.Harvest();

                if (item != null)
                {
                    if (_inventory.GetComponent<Inventory>().SortingItems(item))
                    {
                        return;
                    }
                    else
                    {
                        Debug.Log("Инвентарь полон!");
                        return;
                    }
                }
            }
            else
            {
                return ;
            }
        }
    }

    private void SwitchInventory()
    {
        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            _isActiveInventory = !_isActiveInventory;

            if (_isActiveInventory == true)
            {
                Time.timeScale = 0f;
            }
            else if(_isActiveInventory == false)
            {
                Time.timeScale = 1f;
            }
        }

        _inventory.SetActive(_isActiveInventory);
    }

    private void ShowHelpUI()
    {
        if (_isItem)
        {
            _uiHelp.SetActive(true);
        }
        else if(_isNature == true && _nature.IsRipe == true)
        {
            _uiHelp.SetActive(true);
        }
        else
        {
            _uiHelp.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.TryGetComponent<Item>(out _item))
        {
            _isItem = true;
        }
        else if (coll.gameObject.TryGetComponent<Nature>(out _nature))
        {
            _isNature = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.TryGetComponent<Item>(out _item))
        {
            _isItem = false;
            _item = null;
        }
        else if (coll.gameObject.TryGetComponent<Nature>(out _nature))
        {
            _isNature = false;
            _nature = null;
        }
    }
}
