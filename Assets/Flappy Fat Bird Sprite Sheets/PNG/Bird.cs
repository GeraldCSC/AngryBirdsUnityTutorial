using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
	Vector3 _initialPosition;

	[SerializeField]float _lanchPower = 500;

	bool _lanched = false;

	float _timestale = 0;

    private void Awake()
    {
		this._initialPosition = transform.position;
    }

    private void Update()
    {
		GetComponent<LineRenderer>().SetPosition(0, this._initialPosition);
		GetComponent<LineRenderer>().SetPosition(1, this.transform.position);
		if (this._lanched == true && GetComponent<Rigidbody2D>().velocity.magnitude < 0.1)
        {
			_timestale = _timestale + Time.deltaTime;
        }

		if (this.transform.position.y > 10 || this.transform.position.y < -10 ||
			this.transform.position.x < -10 || this.transform.position.x > 10 ||
			this._timestale > 2
			)
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void OnMouseDown()
	{
		GetComponent<SpriteRenderer>().color = Color.red;
		GetComponent<LineRenderer>().enabled = true;
	}

	private void OnMouseUp() //when mouse is released
	{
		GetComponent<SpriteRenderer>().color = Color.white;
		Vector2 directionToInitPos = this._initialPosition - transform.position;
		directionToInitPos = directionToInitPos * this._lanchPower;
		GetComponent<Rigidbody2D>().AddForce(directionToInitPos);
		GetComponent<Rigidbody2D>().gravityScale = 1;
		this._lanched = true;
		GetComponent<LineRenderer>().enabled = false;
	}

    private void OnMouseDrag()
    {
		var hello = Input.mousePosition;
		hello.z = 10;
		transform.position = Camera.main.ScreenToWorldPoint(hello);
	}

}
