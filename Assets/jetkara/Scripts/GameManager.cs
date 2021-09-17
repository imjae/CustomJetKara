using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject[] gargabes;

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
		Instantiate(gargabes[(int)Random.Range(0, gargabes.Length)], new Vector3(7.5f, Random.Range(-3.45f, 3.45f) , -3) , Quaternion.identity);
	}
}
