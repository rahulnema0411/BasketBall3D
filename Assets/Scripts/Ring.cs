using System.Collections;
using UnityEngine;

public class Ring : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ball")) {
            ScoreManager.instance.IncrementScore();
        }
    }
}
