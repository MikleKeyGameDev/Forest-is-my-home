using UnityEngine;

[RequireComponent (typeof(Entity))]

public class CameraMove : MonoBehaviour
{
    private Entity _entity;
    private Camera _camera;

    private float _differenceX;
    private float _differenceY;

    private void Start()
    {
        _camera = FindAnyObjectByType<Camera>();
        _entity = GetComponent<Entity>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _differenceX = transform.position.x - _camera.gameObject.transform.position.x;
        _differenceY = transform.position.y - _camera.gameObject.transform.position.y;

        if( _differenceX < -3f || _differenceX > 3f || _differenceY < -3f || _differenceY > 3f)
        {
            _camera.gameObject.transform.position = Vector3.MoveTowards(_camera.gameObject.transform.position, new Vector3(transform.position.x, transform.position.y, _camera.gameObject.transform.position.z), _entity.Speed * Time.deltaTime);
        }
    }
}
