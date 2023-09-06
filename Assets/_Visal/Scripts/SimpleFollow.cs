using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    [SerializeField] private Transform _target = null;
    [SerializeField] private Vector2 _offset = Vector2.zero;

    private void Start()
    {
        if (_target == null)
        {
            _target = transform.parent;
            _offset = transform.localPosition;
        }
        transform.SetParent(null);
    }

    private void Update()
    {
        if (_target == null)
        {
            // Destroy itself if there is no target to follow
            Destroy(gameObject);
            return; 
        }

        Vector2 pos = _target.position;
        pos += _offset;
        transform.position = pos;
    }
}
