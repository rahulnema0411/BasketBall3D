using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Vector3 forceDirection;
    public Vector2 initialMouseButtonDownPosition;
    private bool canShoot = true;
    [SerializeField] private Animator characterAnimator;


    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            initialMouseButtonDownPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(0)) {
            Vector2 currentMousePosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(0)) {
            Vector2 finalMousePosition = Input.mousePosition;
        }
    }

    // void Update() {
    //     if(Input.GetMouseButtonDown(0)) {
    //         mouseButtonDownPosition = Input.mousePosition;
    //     }
    //     if(Input.GetMouseButton(0)) {
    //         ScoreManager.instance.slider.value = (Input.mousePosition.y - mouseButtonDownPosition.y)/1000;
    //         timePassed += Time.deltaTime;
    //     }
    //     if (Input.GetMouseButtonUp(0)) {
    //         ShootBall();
    //     }
    //     if(timePassed >= 1f) {
    //         ShootBall();
    //     }
    // }

    // private void ShootBall() {
    //     Debug.LogError("ShootBall" + canShoot);
    //     if(canShoot) {
    //         mouseButtonUpPosition = Input.mousePosition;
    //         direction = (mouseButtonUpPosition - mouseButtonDownPosition)/1000;
    //         forceDirection = new Vector3(direction.x, 1f, direction.y);
    //         timePassed = 0f;
    //         //body.AddForce(forceDirection * thrust);
    //         characterAnimator.SetTrigger("Throw");
    //         canShoot = false;
    //         StartCoroutine(_setDribble());
    //     }
    // }

    // private IEnumerator _setDribble() {
    //     yield return new WaitForSeconds(4f);
    //     transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    //     characterAnimator.SetTrigger("Dribble");
    // }
}
