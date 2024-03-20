using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed;

    private int _currentPosition = 1;

    private void Update()
    {
        if(transform.position == _wayPoints[_currentPosition].position)
        {
            _currentPosition = ++_currentPosition % _wayPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentPosition].position, _speed * Time.deltaTime);
    }
}
