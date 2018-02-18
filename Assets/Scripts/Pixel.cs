using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour {
	// Скорость передвижения игрока
	public float speed =20f;
	// Массив спрайтов (картинок) для лица игрока
	public Sprite[] sprites = new Sprite[3];
	// булевые переменные (ложь / истина)
	// shot_run - готов к выстрелу
	// gound - на земле
	private bool shot_run = true, ground = false;
	// Экземпляр пули
	public GameObject shot_original;
	// сама пуля
	private GameObject shot;
	// Этот объект юнити отвечает за физические свойства объекта
	private Rigidbody2D rb;
	// сила прижка и направление двиежения игрока соответсвенно
	public int jumpForce = 1000, direction = 0;

	void Start(){
		// инициализируем в rb обнет отвечающий за физику
		rb = GetComponent<Rigidbody2D>();
	}
	void Update(){
		// Нажатие кнопки влево
		if (Input.GetKey(KeyCode.LeftArrow)) {
			// устанавливаем направление
			direction = 1;
			// меняем спрайт лица
			GetComponent<SpriteRenderer>().sprite = sprites[1];
			// двигаемся на лево
		//	transform.Translate(Vector2.left * speed * Time.deltaTime);
			rb.MovePosition(rb.position+Vector2.left * speed * Time.deltaTime);
		}
		// все тоже самое но направо
		if (Input.GetKey(KeyCode.RightArrow)) {
			direction = 2;
			GetComponent<SpriteRenderer>().sprite = sprites[2];
		//	transform.Translate(Vector2.right * speed * Time.deltaTime);
			rb.MovePosition(rb.position+Vector2.right * speed * Time.deltaTime);
		}
		// нажатие кнопки вверх и стоим если на земле то ...
		if (Input.GetKey(KeyCode.UpArrow) && ground /*rb.IsTouchingLayers()*/){
			// устанавливаем направление 0
			direction = 0;
			// указывает что не на земле
			ground = false;
			// меняем спрайт лица
			GetComponent<SpriteRenderer>().sprite = sprites[0];
			// обекту отвечающему за физику даем силу прижка вверх
			rb.AddForce(Vector2.up*jumpForce);

			//transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
		// если Esc кнопка то выход из игры
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}

		// если нажат пробел и к выстрелу готов то ...
		if (Input.GetKey(KeyCode.Space) && shot_run) {
			// проверим еще что не в полоте
			if (direction != 0) {
				//указываем что не готовы стрелять снова
				shot_run = false;
				// запускаем куратину
				StartCoroutine(instObj());
				// уменьшаем персонажа
				transform.localScale -= new Vector3(0.1F, 0.1F, 0.1F);
				// создаем новую пулю
				shot = Instantiate(shot_original, transform.position, Quaternion.identity) as GameObject;
				// активируем ее
				shot.SetActive(true);
				// если направление на лево то даем е скорость отрицательную
				//if (direction == 2) shot.GetComponent<Shot>().speed = 100f;
				if (direction == 1) shot.GetComponent<Shot>().speed = -shot.GetComponent<Shot>().speed;
				//shot = Instantiate(shot_original, transform.position, Quaternion.identity) as GameObject;
			}
		}
	}

	// Срабатвает тогда когда косаемся других коллайдеров
    void OnCollisionEnter2D(Collision2D other) {
		// нсли земля то
		if (other.gameObject.tag == "Ground") {
			// укажем что на земле
			ground = true;
		}
	}

	// куратина запускает эту штуку
     IEnumerator instObj () {
		 // тут ждем пол секунды
		 yield return new WaitForSeconds(0.5f);
		// Destroy(shot);
		// и снова готовы стрелять
		 shot_run = true;
	 }
}
