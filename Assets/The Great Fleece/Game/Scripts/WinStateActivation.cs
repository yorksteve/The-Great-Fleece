using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    [SerializeField] private GameObject _winCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.HasCard == true)
            {
                _winCutscene.SetActive(true);
            }
            else
            {
                Debug.Log("Must have key card");
            }
        }
    }
}
