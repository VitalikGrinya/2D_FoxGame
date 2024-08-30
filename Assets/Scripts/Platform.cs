using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaypoint = 0;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if(transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}