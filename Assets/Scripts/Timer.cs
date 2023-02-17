using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float timerValue = 0f;

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timerValue += Time.deltaTime; 
        timerText.text = Mathf.Round(timerValue) + " s.".ToString();
    }
}
