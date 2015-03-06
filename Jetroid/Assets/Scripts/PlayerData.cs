using UnityEngine;
using System.Collections;

public class PlayerData {
	private static PlayerData instance = null;
	private const string HighScoreKey = "Highscore";
	
	public static PlayerData Instance() {
		if (instance == null) {
			instance = new PlayerData();
			instance.highscore = PlayerPrefs.GetInt(HighScoreKey);
		}
		return instance;
	}
	
	private PlayerData() {}
	private int score;
	public int GetScore() {
		return this.score;
	}
	
	public void SetScore(int newScore) {
		this.score = newScore;
		if (this.score > this.highscore) {
			this.highscore = score;
			PlayerPrefs.SetInt(HighScoreKey, this.highscore);
		}
	}
	private int highscore;
	public int GetHighscore() {
		return this.highscore;
	}
}
