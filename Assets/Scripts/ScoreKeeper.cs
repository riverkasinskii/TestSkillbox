using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int levelExperience = 5000;
    private int score;

    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    public int GetScore()
    { 
        return score; 
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);

        if (score >= levelExperience)
        {
            levelManager.LoadLevel();
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetLevelExperience()
    {
        return levelExperience;
    }
}    
