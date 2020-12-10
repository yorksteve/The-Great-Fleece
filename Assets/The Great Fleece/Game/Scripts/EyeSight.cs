using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSight : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameOverCutscene.SetActive(true);
        }
    }

}
