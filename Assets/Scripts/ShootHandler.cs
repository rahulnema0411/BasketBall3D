using System.Collections;
using UnityEngine;

public class ShootHandler : MonoBehaviour {
    [SerializeField] private Projection _projection;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private float _force = 20;
    [SerializeField] private Transform _ballSpawn;
    [SerializeField] private Animator characterAnimator;

    private Vector2 initialMouseButtonDownPosition;
    public Animator CharacterAnimator { get => characterAnimator; set => characterAnimator = value; }
    

    private void Update() {
        HandleControls();
    }

    private void HandleControls() {

        if(Input.GetMouseButtonDown(0)) {
            initialMouseButtonDownPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(0)) {
            Vector2 currentMousePosition = Input.mousePosition;
            _projection.Line.enabled = true;
            Vector2 diff = currentMousePosition - initialMouseButtonDownPosition;
            Vector2 directionVector = new Vector2(diff.x/Screen.width, diff.y/Screen.height);
            _ballSpawn.localRotation = Quaternion.Euler(-directionVector.y * 90f, directionVector.x * 90f, 0f);
            _projection.SimulateTrajectory(_ballPrefab, _ballSpawn.position, _ballSpawn.forward * _force);
        }
        if (Input.GetMouseButtonUp(0)) {
            ScoreManager.instance.EnablePowerPanel();
            this.enabled = false;
        }

    }

    public void DoThrowAnimation() {
        characterAnimator.SetTrigger("Throw");
        ScoreManager.instance.DisablePowerPanel();
        _projection.Line.enabled = false;
    }

    public void ThrowBall() {
        var spawned = Instantiate(_ballPrefab, _ballSpawn.position, _ballSpawn.rotation);
        spawned.Init(_ballSpawn.forward * _force, false);
        StartCoroutine(SetDribble());
    }

    private IEnumerator SetDribble() {
        yield return new WaitForSeconds(1f);
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        characterAnimator.SetTrigger("Dribble");
        this.enabled = true;
    }
}