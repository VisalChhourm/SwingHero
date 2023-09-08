using UnityEngine;

public class SimpleEnemy : CharacterMovement
{
    [SerializeField] private Transform _target = null;
    [SerializeField] private float _stoppingDistance = 1;

    private void Start()
    {
        if (_target == null)
        {
            var player = GameObject.FindWithTag("Player");
            if (player != null)
                _target = player.transform;
        }
    }

    protected override void HandleUserInput()
    {
        if (_target != null)
        {
            Vector2 delta = _target.position - transform.position;
            if (delta.magnitude > _stoppingDistance)
            {
                // Keep moving. Not yet reach destination
                moveDirection = delta.normalized;
            }
            else
            {
                // Reached destination. No need to keep moving
                moveDirection = Vector2.zero;
            }
        }
        else
        {
            moveDirection = Vector2.zero;
        }
    }
}
