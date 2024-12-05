using UnityEngine;

[RequireComponent (typeof(Entity), typeof(Rigidbody2D), typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    private const string AxisX = "Horizontal";
    private const string AxisY = "Vertical";
    private const string AnimWalk = "isWalk";

    [SerializeField] private GameObject _helpUI;

    private Entity _entity;
    private Rigidbody2D _rb;
    private Animator _anim;

    private bool _isLeft;

    private float _inputX;
    private float _inputY;

    private void Start()
    {
        _entity = GetComponent<Entity> ();
        _rb = GetComponent<Rigidbody2D> ();
        _anim = GetComponent<Animator> ();
    }

    private void FixedUpdate()
    {
        Walk();
    }

    private void Update()
    {
        SwitchAnim();
    }

    private void Walk()
    {
        _inputX = Input.GetAxisRaw (AxisX);
        _inputY = Input.GetAxisRaw (AxisY);
        Vector2 move = new Vector2 (_inputX, _inputY).normalized * _entity.Speed;
        _rb.velocity = move;

        if(_inputX < 0f && _isLeft == false)
        {
            Flip();
        }
        else if (_inputX > 0f && _isLeft == true)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isLeft = !_isLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;

        _helpUI.GetComponent<SpriteRenderer>().flipX = _isLeft;
    }

    private void SwitchAnim()
    {
        _anim.SetBool(AnimWalk, _inputX != 0f || _inputY != 0f);
    }
}
