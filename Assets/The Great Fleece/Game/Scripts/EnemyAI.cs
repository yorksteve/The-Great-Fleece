using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;
    [SerializeField] private int _currentTarget = 0;

    private NavMeshAgent _agent;
    private Animator _anim;
    private Vector3 _coinPos;

    private bool _reverse;
    private bool _targetReached;
    private bool _coinTossed = false;

    private void OnEnable()
    {
        Player.onToss += ChaseCoin;
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_wayPoints.Count > 0 && _wayPoints[_currentTarget] != null && _coinTossed == false)
        {
            _agent.SetDestination(_wayPoints[_currentTarget].position);

            float distance = Vector3.Distance(transform.position, _wayPoints[_currentTarget].position);

            if (distance < 1 && (_currentTarget == 0 || _currentTarget == _wayPoints.Count - 1))
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walk", false);
                }
            }
            else
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walk", true);
                }
            }

            if (distance < 1f && _targetReached == false)
            {
                if (_wayPoints.Count < 2)
                {
                    return;
                }

                _targetReached = true;
                StartCoroutine(WaitBeforeMoving());
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, _coinPos);
            if (distance < 4f)
            {
                _anim.SetBool("Walk", false);
            }
        }
    }

    private void ChaseCoin(Vector3 pos)
    {
        _coinPos = pos;
        _coinTossed = true;
        _agent.SetDestination(pos);
        _anim.SetBool("Walk", true);
    }

    IEnumerator WaitBeforeMoving()
    {
        if (_currentTarget == 0 || _currentTarget == _wayPoints.Count - 1)
        {
            if (_anim != null)
            {
                _anim.SetBool("Walk", false);
            }
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }

        if (_reverse == true)
        {
            _currentTarget--;

            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }
        else
        {
            _currentTarget++;

            if (_currentTarget == _wayPoints.Count)
            {
                _reverse = true;
                _currentTarget--;
            }
        }
        _targetReached = false;
    }

    private void OnDisable()
    {
        Player.onToss -= ChaseCoin;
    }
}
