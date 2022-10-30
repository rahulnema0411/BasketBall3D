using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Animator titleAnimator, highscoreAnimator, tapToPlayAnimator, menuAnimator;
    public Button playButton;
    public TextMeshProUGUI highScore;


    private void Start() {
        SetButtons();
        SetHighScore();
    }

    private void SetHighScore() {
        highScore.text = "High Score: " + GetHighScore();
    }

    private string GetHighScore() {
        return PlayerPrefs.GetInt("high_score", 0).ToString();
    }

    private void SetButtons() {
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(delegate() {
            GameManager.instance.Play();
        });
    }

    public void AnimateMenu() {
        AnimateTitle();
        AnimateHighScore();
        AnimateTapToPlay();
    }

    private void AnimateTitle() {
        titleAnimator.SetTrigger("AnimateTitle");
    }

    private void AnimateHighScore() {
        highscoreAnimator.SetTrigger("AnimateHighScore");
    }

    private void AnimateTapToPlay() {
        tapToPlayAnimator.SetTrigger("AnimateTapToPlay");
    }

    public void AnimateAndDisable() {
        menuAnimator.SetTrigger("HideMenu");
    }

    public void DisableMenu() {
        gameObject.SetActive(false);
    }
}
