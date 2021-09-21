using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance; // 싱글톤을 할당할 전역 변수
	public float generateSlime;
	public GameObject slime;

	public TextMesh scoreLabel;
	public int score = 0; // 게임 점수

	private bool isGameover = false; // 게임 오버 상태
									 // 게임 시작과 동시에 싱글톤을 구성
	void Awake()
	{
		// 싱글톤 변수 instance가 비어있는가?
		if (instance == null)
		{
			// instance가 비어있다면(null) 그곳에 자기 자신을 할당
			instance = this;
		}
		else
		{
			// instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우

			// 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
			// 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
			Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
			Destroy(gameObject);
		}
	}

	void Start () 
	{
		score = 0;

		InvokeRepeating("CreateObjects", 1, generateSlime);
	}

	// 점수를 증가시키는 메서드
	public void AddScore(int newScore)
	{
		if (!isGameover)
		{
			// 점수를 증가
			score += newScore;

			scoreLabel.text = score.ToString();
		}
	}

	void CreateObjects()
	{
		Instantiate(slime, new Vector3(7.5f, Random.Range(-3.45f, 3.45f) , 0) , Quaternion.identity);
		
	}
}
