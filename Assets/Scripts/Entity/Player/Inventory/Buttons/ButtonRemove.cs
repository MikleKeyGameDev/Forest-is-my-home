using UnityEngine;

public class ButtonRemove : MonoBehaviour
{
    [SerializeField] private CellHendRight _cell;

    private Inventory _inventory;

    private void Start()
    {
        _inventory = FindAnyObjectByType<Inventory>();
    }

    public void Remove()
    {
        _inventory.SortingItems(_cell.Item_SO);
        _cell.DelleteItem();
    }
}
