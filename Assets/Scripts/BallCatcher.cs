using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCatcher : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ball")) {
            InstantiateNewBallAndDestroyTheOldOne(other);
        }
    }

    private void InstantiateNewBallAndDestroyTheOldOne(Collider other) {
        ScoreManager.instance.InstantiateNewBall();
        Destroy(other.gameObject);
    }
}
