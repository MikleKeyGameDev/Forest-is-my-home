using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Player), typeof(Entity))]

public class Bars : MonoBehaviour
{
    [SerializeField] private Image _imageHealth;
    [SerializeField] private Image _imageHunger;

    private Player _player;
    private Entity _entity;

    private void Start()
    {
        _player = GetComponent<Player>();
        _entity = GetComponent<Entity>();
    }

    private void Update()
    {
        SetToBar();
    }

    private void SetToBar()
    {
        _imageHealth.fillAmount = _entity.Health / _entity.MaxHealth ;
        _imageHunger.fillAmount = _player.Hunger / 100f;
    }
}
