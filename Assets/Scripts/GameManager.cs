using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Menu menu;
    public ScoreManager scoreManager;
    public Shoot basketball;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    public void Play() {
        menu.AnimateAndDisable();
        scoreManager.AnimateMenu();
        basketball.enabled = true;
    }

}
