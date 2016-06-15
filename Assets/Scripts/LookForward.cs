using UnityEngine;
using System.Collections;

public class LookForward : MonoBehaviour {

	public Transform sightStart, sightEnd;
	public bool needsCollision = true;

	private bool collision = false;
	
	void Update () {
		collision = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("Solid"));
		Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

		if (collision == needsCollision) {
			this.transform.localScale = new Vector3 ((transform.localScale.x == 1) ? -1 : 1, 1, 1);
		}
	}
}
