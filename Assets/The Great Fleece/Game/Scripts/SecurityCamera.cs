using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCutscene;
    [SerializeField] private Animator _anim;

    private Renderer _rend;
    private WaitForSeconds _cutsceneYield;

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _cutsceneYield = new WaitForSeconds(.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _anim.enabled = false;
            Color color = new Color(.6f, .114f, .114f, .3f);
            _rend.material.SetColor("_TintColor", color);
            StartCoroutine(EnableCutscene());
        }
    }

    IEnumerator EnableCutscene()
    {
        yield return _cutsceneYield;
        _gameOverCutscene.SetActive(true);
    }
}
