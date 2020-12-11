using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private AudioClip _coinSound;

    private NavMeshAgent _agent;
    private Animator _anim;
    private Vector3 _target;

    private bool _coinThrown;

    public delegate void CoinToss(Vector3 pos);
    public static event CoinToss onToss;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                _agent.SetDestination(hitInfo.point);
                _anim.SetBool("Walk", true);
                _target = hitInfo.point;
            }
        }

        float distance = Vector3.Distance(transform.position, _target);

        if (distance < 1f)
        {
            _anim.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(1) && _coinThrown == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                _anim.SetTrigger("Throw");
                _coinThrown = true;
                Instantiate(_coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinSound, transform.position);
                onToss(hitInfo.point);
            }
        }
    }
}
