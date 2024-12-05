using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _speed;
    [SerializeField] private float _minDamage;
    [SerializeField] private float _maxDamage;

    public float Health { get { return _health; } }
    public float MaxHealth { get { return _maxHealth; } }
    public float Speed { get { return _speed; } }

    public float Damage { get { return Random.Range(_minDamage, _maxDamage); } }

    public void TakeDamage(float damage)
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
