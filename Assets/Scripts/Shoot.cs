using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Rigidbody body;
    public float thrust;
    public Vector3 forceDirection, direction;
    public int waitForSeconds;

    private float timePassed = 0f;
    private Vector3 mouseButtonDownPosition;
    private Vector3 mouseButtonUpPosition;
    private bool canShoot = true;

    public bool CanShoot { get => canShoot; set => canShoot = value; }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            mouseButtonDownPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(0)) {
            ScoreManager.instance.slider.value = (Input.mousePosition.y - mouseButtonDownPosition.y)/1000;
            timePassed += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0)) {
            ShootBall();
        }
        if(timePassed >= 1f) {
            ShootBall();
        }
    }

    private void ShootBall() {
        if(canShoot) {
            mouseButtonUpPosition = Input.mousePosition;
            direction = (mouseButtonUpPosition - mouseButtonDownPosition)/1000;
            forceDirection = new Vector3(direction.x, 1f, direction.y);
            timePassed = 0f;
            body.AddForce(forceDirection * thrust);
            canShoot = false;
        }
    }
}
