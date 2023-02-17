using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Health playerHealth;      

    [Header("Score")]
    [SerializeField] private Slider experienceSlider;
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();        
    }

    private void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
        experienceSlider.minValue = scoreKeeper.GetScore();
        experienceSlider.maxValue = scoreKeeper.GetLevelExperience();
    }
    
    private void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        experienceSlider.value = scoreKeeper.GetScore();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000000");
    }
}
