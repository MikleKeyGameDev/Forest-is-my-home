using UnityEngine;

public class ButtonUse : MonoBehaviour
{
    [SerializeField] private Cell _cell;

    private CellHendRight _cellHendRight;
    
    private Player _player;

    private void Awake()
    {
        _cellHendRight = FindAnyObjectByType<CellHendRight>();
        _player = FindAnyObjectByType<Player>();
    }

    public void Use()
    {
        _cellHendRight.AddToItem(_cell.Item_SO);
        Debug.Log($"Вы взяли в руки - {_cell.Item_SO.Name}");
        _cell.DelleteItem();
    }
}
