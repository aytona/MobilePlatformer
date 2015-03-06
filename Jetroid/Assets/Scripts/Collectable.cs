using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public AudioClip pickupSound;

	void OnTriggerEnter2D (Collider2D target) {
		if (target.gameObject.tag == "Player") {
			if (pickupSound) {
				AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			}
			Destroy (gameObject);
		}
	}
}
