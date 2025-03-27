using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [Header("Button Setup")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button shootButton;

    [Header("UI Setup")]
    [SerializeField] private TMP_Text greetingText;
    [SerializeField] private TMP_Text scoreText;

    [Header("Imafe Setup")]
    [SerializeField] private Image image;


    public static event Action OnStartButtonPressed;
    public static event Action OnRestartButtonPressed;
    public static event Action OnShootButtonPressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(OnUIStartButtonPressed);
        restartButton.onClick.AddListener(OnUIRestartButtonPressed);
        shootButton.onClick.AddListener(OnUIShootButtonPressed);

        restartButton.gameObject.SetActive(false);
        shootButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false); //New

        scoreText.text = "SCORE: 0"; //New
    }

    void OnUIStartButtonPressed()
    {
        OnStartButtonPressed?.Invoke();

        startButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        shootButton.gameObject.SetActive(true);
        //greetingText.text = "SHOOT THE ENEMY!!!";
        
        
        greetingText.gameObject.SetActive(false);
        
    }

    void OnUIRestartButtonPressed()
    {
        OnRestartButtonPressed?.Invoke();
        startButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        shootButton.gameObject.SetActive(false);
        greetingText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true); //New
    }

    void OnUIShootButtonPressed()
    {
        OnShootButtonPressed?.Invoke();
    }

    public void UpdeteDateScore(int score)
    {
        scoreText.text = $"SCORE: {score}";
    }


}
