using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardActivation : MonoBehaviour
{
    [SerializeField] private GameObject _sleepingGuardCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _sleepingGuardCutscene.SetActive(true);
            GameManager.Instance.HasCard = true;
        }
    }
}
