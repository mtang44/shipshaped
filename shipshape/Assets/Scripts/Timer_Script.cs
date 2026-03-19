using UnityEngine;
using TMPro; // For TextMeshPro UI
using System; // For TimeSpan formatting (optional)

public class TimerManager : MonoBehaviour
{
    // Reference to the UI Text element in the Inspector
    public TextMeshProUGUI timerText; 

    // Total time for the countdown
    public float totalTime = 0f; 

    // Boolean to control if the timer is running
    private bool timerIsRunning = false;

    [SerializeField] private GameObject player;

    void Start()
    {
        // Start the timer automatically when the game begins
        timerIsRunning = true; 
    }

    void Update()
    {
        if (timerIsRunning)
        {   
            
            if (player.activeSelf == true) //replace with end condition (Player death)
            {
                // Increase timer every frame
                totalTime += Time.deltaTime; 
                DisplayTime(totalTime);
            }
            else
            {
                // Timer finished
                Debug.Log("Time has run out!");
                timerIsRunning = false;
                // Trigger game over event or other action here
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // Format the float value into minutes and seconds (00:00 format)
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 100;

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
    }
}

