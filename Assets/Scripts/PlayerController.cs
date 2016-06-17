using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector2 moving = new Vector2();
	
	void Update () {
		moving.x = moving.y = 0;

#if UNITY_STANDALONE
		if(Input.GetKey("right")){
			moving.x = 1;
		}
		else if(Input.GetKey("left")){
			moving.x = -1;
		}

		if(Input.GetKey("up")){
			moving.y = 1;
		}
		else if(Input.GetKey("down")){
			moving.y = -1;
		}
#elif UNITY_ANDROID
		if (Input.touchCount == 1) {
			if (Input.GetTouch(0).position.x > this.transform.position + 0.3f) {
				moving.x = 1;
			}
			else if (Input.GetTouch(0).position.x < this.transform.position - 0.3f) {
				moving.x = -1;
			}
			else {
				moving.y = 1;
			}
		}
#endif
	}
}
