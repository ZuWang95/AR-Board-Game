using UnityEngine;
using TMPro;

public class ChessClock : MonoBehaviour
{
    public TextMeshProUGUI timerText1; // Text UI for the first timer
    public TextMeshProUGUI timerText2; // Text UI for the second timer

    private float time1 = 600; // 10 minutes in seconds
    private float time2 = 600; // 10 minutes in seconds

    private bool isTimer1Active = false;
    private bool isTimer2Active = false;

    void Update()
    {
        if (isTimer1Active)
        {
            time1 -= Time.deltaTime;
            UpdateTimerDisplay();
        }

        if (isTimer2Active)
        {
            time2 -= Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    public void Timer1ButtonPressed()
    {
        isTimer1Active = false;
        isTimer2Active = true;
        UpdateTimerDisplay();  // Update display immediately
    }

    public void Timer2ButtonPressed()
    {
        isTimer2Active = false;
        isTimer1Active = true;
        UpdateTimerDisplay();  // Update display immediately
    }

    public void ResetButtonPressed()
    {
        time1 = 600;
        time2 = 600;
        isTimer1Active = false;
        isTimer2Active = false;
        UpdateTimerDisplay();  // Update display immediately
    }

    private void UpdateTimerDisplay()
    {
        timerText1.text = FormatTime(time1);
        timerText2.text = FormatTime(time2);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
