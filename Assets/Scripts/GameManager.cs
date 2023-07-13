using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float playerHP;
    
    private int gear = 1;

    public TextMeshProUGUI hp;
    public PathFollower pathFollower;
    public AudioSource engine;
    public GameObject endPanel;
    public GameObject winText;
    public GameObject loseText;
    public GameObject winButton;
    public GameObject loseButton;

    public float engineSoundSpeed;
    public float engineReleaseSpeed;
    public float maxEnginePitch;
    public float reduceRPM = 3f;
    public int totalGears = 5;
    public int level;
    public bool lastLevel;
    public bool end = false;

    void Start()
    {
        // Set current level as default
        PlayerPrefs.SetInt("Level", level);

        // Set speed according to HP and display
        hp.text = "HP: " + playerHP.ToString();
        pathFollower.speed = playerHP * 0.04f;
    }

    void Update()
    {
        // Engine sound
        // If level has ended, slowly turn down engine noise
        if (end && engine.pitch > 1f)
        {
            engine.pitch -= Time.deltaTime+ engineReleaseSpeed;
        }

        if (engine.pitch < maxEnginePitch && !end)    // Increase engine pitch until max pitch
            engine.pitch += Time.deltaTime + engineSoundSpeed;
        if (engine.pitch >= maxEnginePitch && !end)    // At max pitch, change gear and lower engine pitch as long as total gears are not reached
        {
            if (gear < totalGears)
            {
                engine.pitch = reduceRPM;

                reduceRPM += 0.125f;
                gear++;
                if (reduceRPM > maxEnginePitch - 1)
                {
                    reduceRPM = maxEnginePitch - 1;
                }
            }
        }
    }

    public void ChangePlayerHP(float amount)
    {
        if (playerHP + amount >= 200)
        {
            playerHP += amount;
            pathFollower.speed = playerHP * 0.04f;
            hp.text = "HP: " + playerHP.ToString();
        }
        else
        {
            playerHP = 200;
            pathFollower.speed = playerHP * 0.04f;
            hp.text = "HP: " + playerHP.ToString();
        }
    }

    public void PlayerWin()
    {
        winText.SetActive(true);
        winButton.SetActive(true);
        loseText.SetActive(false);
        loseButton.SetActive(false);
        endPanel.SetActive(true);
    }

    public void PlayerLose()
    {
        winText.SetActive(false);
        winButton.SetActive(false);
        loseText.SetActive(true);
        loseButton.SetActive(true);
        endPanel.SetActive(true);
    }

    public void OnContinueButton()
    {
        if (!lastLevel)
            SceneManager.LoadScene("Level " + (level + 1).ToString());
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void OnRetryButton()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
