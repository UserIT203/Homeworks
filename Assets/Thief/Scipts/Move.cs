using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoints;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i); 
    }

    private void Update()
    {
        Transform target = _points[_currentPoints];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _currentPoints++;

            if(_currentPoints >= _points.Length)
            {
                _currentPoints = 0;
            }
        }
    }
}
