using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Entity))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _hunger;
    [SerializeField] private float _maxHunger = 100f;

    private Entity _entity;

    public float Hunger { get { return _hunger; } }

    private void Start()
    {
        _entity = GetComponent<Entity>();
        StartCoroutine(StraveTimer());
    }

    private void Strave()
    {
        _hunger--;

        if(_hunger <= 0f)
        {
            _hunger = 0f;
            _entity.TakeDamage(1);
        }

        StartCoroutine(StraveTimer());
    }

    public void ToEat(float hunger)
    {
        _hunger += hunger;

        if(_hunger > _maxHunger)
        {
            _hunger = _maxHunger;
        }
    }

    private IEnumerator StraveTimer()
    {
        yield return new WaitForSeconds(10f);
        Strave();
    }
}
