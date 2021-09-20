using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject slime;

	public TextMesh scoreLabel;
	public static int score;
	public int Score
	{
		set
		{
			score = value;

			scoreLabel.text = Score.ToString();
		}
		get
		{
			return score;
		}
	}

	void Start () 
	{
		score = 0;

		InvokeRepeating("CreateObjects", 1,1);
	}

	void CreateObjects()
	{
		Instantiate(slime, new Vector3(7.5f, Random.Range(-3.45f, 3.45f) , 0) , Quaternion.identity);
		
	}
}
