using UnityEngine;

public class ButtonUse : MonoBehaviour
{
    [SerializeField] private Cell _cell;

    private CellHendRight _cellHendRight;

    private void Awake()
    {
        _cellHendRight = FindAnyObjectByType<CellHendRight>();
    }

    public void Use()
    {
        _cellHendRight.AddToItem(_cell.Item_SO);
        Debug.Log($"�� ����� � ���� - {_cell.Item_SO.Name}");
        _cell.DelleteItem();
    }
}
