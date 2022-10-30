using UnityEngine;

public class CameraAnimationHandler : MonoBehaviour {

    public void OnAnimationFinish() {
        GameManager.instance.menu.AnimateMenu();
    }
}
