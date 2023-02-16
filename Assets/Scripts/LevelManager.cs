using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float sceneLoadDelay = 2f;
    public void LoadLevel(int value)
    {
        StartCoroutine(WaitAndLoad(value, sceneLoadDelay));
    }    

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator WaitAndLoad(int sceneValue, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneValue);
    }
}
