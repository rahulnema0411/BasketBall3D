using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    public Slider slider;
    public TextMeshProUGUI scoreText;
    public Transform basketBallPos;
    public GameObject basketBall;
    public Animator animator;
    [SerializeField] private GameObject _powerPanel;
    
    private int score;
    private float slideValue;

    public float SlideValue { get => slideValue; set => slideValue = value; }
    public int Score { get => score; set => score = value; }

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        InitiateScore();
        AnimateSlider();
    }

    private void InitiateScore() {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncrementScore() {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }
    
    public void AnimateMenu() {
        gameObject.SetActive(true);
        animator.SetTrigger("ShowScoreMenu");
    }

    public void EnablePowerPanel() {
        _powerPanel.SetActive(true);
    }

    private void AnimateSlider() {
        slider.DOValue(1f, 1f).OnComplete(delegate() {
            slider.DOValue(0f, 1f).OnComplete(AnimateSlider);
        });
    }

    public float DisablePowerPanel() {
        float sliderVal = slider.value;
        _powerPanel.SetActive(false);
        return sliderVal;
    }
}
