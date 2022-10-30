using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    public Slider slider;
    public TextMeshProUGUI scoreText;
    public Transform basketBallPos;
    public GameObject basketBall;
    public Animator animator;
    
    private int score;
    private float slideValue;

    public float SlideValue { get => slideValue; set => slideValue = value; }
    public int Score { get => score; set => score = value; }

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        InitiateScore();
    }

    private void InitiateScore() {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncrementScore() {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }

    public void InstantiateNewBall() {
        Instantiate(basketBall, basketBallPos.position, Quaternion.identity);
    }

    public void AnimateMenu() {
        gameObject.SetActive(true);
        animator.SetTrigger("ShowScoreMenu");
    }
}
