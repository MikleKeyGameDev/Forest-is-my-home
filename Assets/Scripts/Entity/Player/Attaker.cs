using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Entity), typeof(Animator))]

public class Attaker : MonoBehaviour
{
    [SerializeField] private Hends _hend;

    private Entity _playerEntity;
    private Animator _anim;
    private Entity _enemyEntity;
    
    private bool _isVisibleEntity;
    private bool _isAttak;

    private void Start()
    {
        _playerEntity = GetComponent<Entity>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckToEnemy();
    }

    private void CheckToEnemy()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(AttackTimer());
        }
    }

    private void Attack(Entity entity, int damage)
    {
        entity.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Entity>(out _enemyEntity))
        {
            _isVisibleEntity = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Entity>(out _enemyEntity))
        {
            _isVisibleEntity = true;
            _enemyEntity = null;
        }
    }

    private IEnumerator AttackTimer()
    {
        if(_isAttak == false)
        {
            _isAttak = true;
            _anim.Play("Attack");

            if (_enemyEntity != null && _isVisibleEntity)
            {
                Attack(_enemyEntity, _hend.Attack());
            }

            yield return new WaitForSeconds(0.5f);
            _anim.Play("Idle");
            _isAttak = false;
        }
    }
}
