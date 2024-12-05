using UnityEngine;

public class ButtonEat : MonoBehaviour
{
    [SerializeField] private Cell _cell;

    private Player _player;

    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
    }

    public void Eat()
    {
        _player.ToEat(_cell.Item_SO.Food.NutritionalValue);
        _cell.DelleteItem();
    }
}
