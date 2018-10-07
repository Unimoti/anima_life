using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour {
	public float speed = 5;
	public bool isGrounded = true;
	private Rigidbody2D rb;
	private Vector3 defalutScale;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		defalutScale = transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		Walk(x);
		Turn(x);
	}

	private void Walk ( float inputValue ){
    if ( inputValue != 0 )
    {
        // Rigidbody2D に力を加えることでプレイヤーキャラクターを移動させる
        rb.AddForce( Vector2.right * inputValue * speed * Time.deltaTime, ForceMode2D.Impulse);
				Debug.Log(Vector2.right * inputValue * speed * Time.deltaTime);
    }
  }

	private void Turn ( float inputValue ){
    if ( inputValue > 0 )
    {
        transform.localScale = defalutScale;
    }
    else if ( inputValue < 0 )
    {
        // ローカルスケールのXの値を反転させることで、スプライトを反転させる
        transform.localScale = new Vector3 ( -defalutScale.x, defalutScale.y, defalutScale.z );
    }
  }

	private void OnCollisionEnter2D ( Collision2D collision ){
		isGrounded = true;
	}

	private void OnCollisionExit2D ( Collision2D collision ){
		isGrounded = false;
	}
}
