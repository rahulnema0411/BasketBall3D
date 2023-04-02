using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Menu menu;
    public ScoreManager scoreManager;
    public ShootHandler shootHandler;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    public void Play() {
        shootHandler.enabled = true;
        menu.AnimateAndDisable();
        scoreManager.AnimateMenu();
    }

}
