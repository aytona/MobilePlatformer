﻿using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public const int IDLE = 0;
	public const int OPENING = 1;
	public const int OPEN = 2;
	public const int CLOSING = 3;
	public float closeDelay = .5f;
	public AudioClip doorSound;

	private int state = IDLE;
	private Animator animator;
	
	void Start () {
		animator = GetComponent<Animator> ();
	}

	void OnOpenStart() {
		state = OPENING;
		if (doorSound) {
			AudioSource.PlayClipAtPoint(doorSound, transform.position);
		}
	}

	void OnOpenEnd() {
		state = OPEN;
	}

	void OnCloseStart() {
		state = CLOSING;
	}

	void OnCloseEnd() {
		state = IDLE;
	}

	void DissableCollider2D() {
		collider2D.enabled = false;
	}

	void EnableCollider2D() {
		collider2D.enabled = true;
	}

	public void Open() {
		animator.SetInteger ("AnimState", 1);
	}

	public void Close() {
		StartCoroutine(CloseNow());
	}

	private IEnumerator CloseNow() {
		yield return new WaitForSeconds(closeDelay);
		animator.SetInteger("AnimState", 2);
	}
}
