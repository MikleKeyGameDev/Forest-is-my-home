using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Nature : MonoBehaviour
{
    [SerializeField] private ItemSO _item;

    [SerializeField] private Sprite _notRipeSprite;
    [SerializeField] private Sprite _ripeSprite;

    [SerializeField] private float _minTimeToRipe;
    [SerializeField] private float _maxTimeToRipe;

    [SerializeField] private int _maxNumberBerries;
    [SerializeField] private int _minNumberBerries;

    [SerializeField] private SpriteRenderer _renderer;

    private Animator _anim;

    private int _numberBerries;

    private bool _isRipe;

    public bool IsRipe {  get { return _isRipe; } }

    private void Start()
    {
        _anim = GetComponent<Animator>();
        StartCoroutine(MaturationTimer());
    }

    public ItemSO Harvest()
    {
        if (_isRipe)
        {
            _numberBerries--;

            StartCoroutine(TimeAnim());


            if (_numberBerries <= 0)
            {
                _numberBerries = 0;
                _isRipe = false;
                _renderer.sprite = _notRipeSprite;
                StartCoroutine(MaturationTimer());
            }

            return _item;
        }
        else
        {
            Debug.Log("Куст ещё не созрел!");
            return null;
        }
    }

    private void Maturation()
    {
        _renderer.sprite = _ripeSprite;
        _isRipe = true;
        _numberBerries = Random.Range(_minNumberBerries, _maxNumberBerries);
    }

    private IEnumerator MaturationTimer()
    {
        float time = Random.Range(_minTimeToRipe, _maxTimeToRipe);
        yield return new WaitForSeconds(time);
        Maturation();
    }

    private IEnumerator TimeAnim()
    {
        _anim.Play("Harvest");
        yield return new WaitForSeconds(0.33f);
        _anim.Play("Idle");
    }
}
