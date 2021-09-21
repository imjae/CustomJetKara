using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
	public float speed = 0.5f; // 이동 속력
	public float generateBullte = 0.3f;
	public GameObject healthBar;
	public GameObject bullet;
	Transform attackPoint;

	private bool isDead;
	private Rigidbody2D playerRigidbody; // 이동에 사용할 리지드바디 컴포넌트

	void Start()
	{
		isDead = false;
		playerRigidbody = GetComponent<Rigidbody2D>();

		InvokeRepeating("GenerateBullet", 0.5f, generateBullte);
	}

	void Update()
	{
		//수평축과 수직축의 입력값읠 감지하여 저장
		float xInput = Input.GetAxis("Horizontal");
		float yInput = Input.GetAxis("Jump");

		// 실제 이동속도를 입력값과 이동속력을 사용해 결정
		float xSpeed = xInput * speed;
		float ySpeed = yInput * speed;

		Vector2 newVelocity = new Vector2(xSpeed, ySpeed);

		//리지드바디의 속도에 newVelocity 할당
		playerRigidbody.velocity = newVelocity;
		// -------------------------------------------

	}

    void BackToMain()
	{
        SceneManager.LoadScene("MainMenu");
	}

	void GenerateBullet()
	{
		if (transform.Find("AttackPoint") != null)
			attackPoint = transform.Find("AttackPoint").gameObject.transform;

		GameObject cloneBullet = Instantiate(bullet, attackPoint);
		cloneBullet.transform.position = attackPoint.position;
		cloneBullet.transform.parent = FindObjectOfType<PlayerScript>().gameObject.transform;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject collisionObject = collision.gameObject;

		if(collision.tag == "Enemy")
			healthBar.GetComponent<HealthSystem>().TakeDamage(10);
		if(collision.tag == "Candy")
        {
			healthBar.GetComponent<HealthSystem>().HealDamage(collisionObject.GetComponent<CandyScript>().healAmount);
			Destroy(collision.gameObject);
		}
			
	}
}
