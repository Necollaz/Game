using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    private void Start()
    {
        SetDestinationToPlayer();
    }

    private void Update()
    {
        if(_target != null)
        {
            MoveTowardsPlayer();
            RotateTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        if(_target != null)
        {
            Vector3 direction = _target.position - transform.position;
            transform.position += direction.normalized * _speed * Time.deltaTime;
        }
    }

    private void RotateTowardsPlayer()
    {
        if(_target != null)
        {
            transform.LookAt(_target);
        }
    }

    private void SetDestinationToPlayer()
    {
        Player player = FindObjectOfType<Player>();

        if(player != null)
        {
            _target = player.transform;
        }
    }
}
