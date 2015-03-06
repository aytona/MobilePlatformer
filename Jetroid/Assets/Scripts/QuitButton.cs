using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {
	void Update () {
		if (Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
