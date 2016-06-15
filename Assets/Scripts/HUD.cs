using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Text score;
	public Text highScore;
	public int currentScore;
	public int totalCrystals;
	public int totalArtifacts;
	private static HUD instance = null;

	void Awake() {
		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
		else {
			Destroy(this.gameObject);
		}
	}

	void OnLevelWasLoaded() {
		if (Application.loadedLevelName == "Splash") {
			GameObject.Destroy(this.gameObject);
		}
		if (Application.loadedLevelName == "Level1") {
			GameObject[] crystals = GameObject.FindGameObjectsWithTag("Crystal");
			GameObject[] artifacts = GameObject.FindGameObjectsWithTag("Artifact");
			totalCrystals = crystals.Length;
			totalArtifacts = artifacts.Length;
		}
	}

	void Update () {
		GameObject[] crystals = GameObject.FindGameObjectsWithTag("Crystal");
		GameObject[] artifacts = GameObject.FindGameObjectsWithTag("Artifact");
		if (totalCrystals > crystals.Length) {
			updateTotalCrystals();
		}
		if (totalArtifacts > artifacts.Length) {
			updateTotalArtifacts();
		}

		if (GameObject.FindGameObjectWithTag("Player") != null) {
			PlayerData.Instance().SetScore(currentScore);
		}
		if (GameObject.FindGameObjectWithTag("Player") == null) {
			currentScore = 0;
		}
		this.score.text = "Score: " + PlayerData.Instance().GetScore();
		this.highScore.text = "HighScore: " + PlayerData.Instance().GetHighscore();


	}

	void updateTotalCrystals() {
		currentScore += 100;
		totalCrystals--;
	}

	void updateTotalArtifacts() {
		currentScore += 500;
		totalArtifacts--;
	}
}
