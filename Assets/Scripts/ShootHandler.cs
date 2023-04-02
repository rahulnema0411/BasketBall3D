using UnityEngine;

public class ShootHandler : MonoBehaviour {
    [SerializeField] private Projection _projection;

    private Vector2 initialMouseButtonDownPosition;

    private void Update() {
        HandleControls();
    }

    #region Handle Controls

    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private float _force = 20;
    [SerializeField] private Transform _ballSpawn;

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
            _projection.Line.enabled = false;
            Vector2 finalMousePosition = Input.mousePosition;
            var spawned = Instantiate(_ballPrefab, _ballSpawn.position, _ballSpawn.rotation);
            spawned.Init(_ballSpawn.forward * _force, false);
        }

    }

    #endregion
}