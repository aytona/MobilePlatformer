using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float movementDamping = 1.5f;

	void Awake() {
		camera.orthographicSize = ((Screen.height/2.0f) / 100f);
	}

	void LateUpdate() {
		if (!target) {
			return;
		}

		Vector3 currentPosition = this.transform.position;
		float cameraZ = currentPosition.z;
		currentPosition = Vector3.Lerp(currentPosition, target.position, this.movementDamping *Time.deltaTime);
		currentPosition.z = cameraZ;
		this.transform.position = currentPosition;
	}
}
