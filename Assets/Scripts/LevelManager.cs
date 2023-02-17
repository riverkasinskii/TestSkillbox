using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float sceneLoadDelay = 2f;
    
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }        

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        StartCoroutine(WaitAndLoad(GetCurrentIndex(), sceneLoadDelay));
    }

    private IEnumerator WaitAndLoad(int index, float delay)
    {        
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(GetCurrentIndex());
    }

    private int GetCurrentIndex()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        return nextSceneIndex;
    }
}
