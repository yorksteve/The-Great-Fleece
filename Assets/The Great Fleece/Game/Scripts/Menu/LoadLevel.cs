using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private Image _progressBar;

    private void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Main");

        while (asyncOperation.isDone == false)
        {
            _progressBar.fillAmount = asyncOperation.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
