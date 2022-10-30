using UnityEngine;

public class DoPingPong : MonoBehaviour {


    private int direction = 1;

    void Update() {
        
        transform.Translate(direction * Vector3.forward * Time.deltaTime);
        if(transform.position.z > 1.0f) {
            direction = -1;
        }
        if(transform.position.z < -1.0f) {
            direction = 1;
        }
    }
}
