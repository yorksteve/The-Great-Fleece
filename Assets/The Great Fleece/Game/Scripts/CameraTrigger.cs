using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Transform _triggerCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Camera.main.transform.position = _triggerCamera.transform.position;
            Camera.main.transform.rotation = _triggerCamera.transform.rotation;
        }
    }

}
