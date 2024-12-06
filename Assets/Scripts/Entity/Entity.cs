using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _speed;
    [SerializeField] private int _minDamage;
    [SerializeField] private int _maxDamage;

    public float Health { get { return _health; } }
    public float MaxHealth { get { return _maxHealth; } }
    public float Speed { get { return _speed; } }

    public int Damage { get { return Random.Range(_minDamage, _maxDamage + 1); } }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if( _health <= 0)
        {
            _health = 0;
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log($"{gameObject.name} пал смертью храбрых.");
    }
}
