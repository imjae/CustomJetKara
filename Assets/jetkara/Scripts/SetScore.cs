using UnityEngine;

public class SetScore : MonoBehaviour 
{
	public TextMesh bestScoreLabel;
	public TextMesh scoreLabel;

	void Start () 
	{
		scoreLabel.text = "Score: " + GameManager.instance.score.ToString();

		if (GameManager.instance.score > 0)
		{
			if (PlayerPrefs.GetInt("Score", 0) < GameManager.instance.score)
			{
				PlayerPrefs.SetInt("Score", GameManager.instance.score);
				PlayerPrefs.Save();
			}
		}

		bestScoreLabel.text = "HighScore: " + PlayerPrefs.GetInt("Score", 0).ToString();
		GameManager.instance.score = 0;
	}
}