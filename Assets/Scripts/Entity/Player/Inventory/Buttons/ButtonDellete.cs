using UnityEngine;

public class ButtonDellete : MonoBehaviour
{
    [SerializeField] private Cell _cell;

    public void Dellete()
    {
        _cell.DelleteItem();
    }
}
