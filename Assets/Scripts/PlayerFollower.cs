using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;

    void Update()
    {
        var direction = (_player.position - transform.position);
        transform.Translate(direction * _speed);
    }
}
