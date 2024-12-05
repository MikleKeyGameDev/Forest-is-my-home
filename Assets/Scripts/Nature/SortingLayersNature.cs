using UnityEngine;

public class SortingLayersNature : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Entity _entity;

    private Color _colorBG = new Color(1f, 1f, 1f, 1f);
    private Color _colorFG = new Color(1f, 1f, 1f, 0.4f);

    private bool _isEntity;

    private void Update()
    {
        Sorting();
    }

    private void Sorting()
    {
        if(_isEntity == true)
        {
            if(transform.position.y > _entity.gameObject.transform.position.y)
            {
                _spriteRenderer.sortingLayerName = "NatureBG";
                _spriteRenderer.color = _colorBG;
            }
            else if(transform.position.y < _entity.gameObject.transform.position.y)
            {
                _spriteRenderer.sortingLayerName = "NatureFG";
                _spriteRenderer.color = _colorFG;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.TryGetComponent<Entity>(out _entity))
        {
            _isEntity = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.TryGetComponent<Entity>(out _entity))
        {
            _isEntity = false;
            _entity = null;
            _spriteRenderer.color = Color.white;
        }
    }
}
