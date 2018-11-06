using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour {
	public float speed = 1;
	public bool isGrounded = true;
	public float runForce = 1.5f;       // 走り始めに加える力
	public float runSpeed = 0.5f;       // 走っている間の速度
	public float runThreshold = 2.2f;   // 速度切り替え判定のための閾値
	float stateEffect = 1;       // 状態に応じて横移動速度を変えるための係数

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
				// 左右の移動。一定の速度に達するまではAddforceで力を加え、それ以降はtransform.positionを直接書き換えて同一速度で移動する
				float speedX = Mathf.Abs (rb.velocity.x);
				if (speedX < runThreshold) {
					rb.AddForce (transform.right * inputValue * runForce * stateEffect); //未入力の場合は key の値が0になるため移動しない
				} else {
					transform.position += new Vector3 (runSpeed * Time.deltaTime * inputValue * stateEffect, 0);
				}
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
		if (collision.gameObject.tag == "Ground") {
			if (!isGrounded)
				isGrounded = true;
		}
	}

	private void OnTriggerStay2D( Collision2D collision ){
		if (collision.gameObject.tag == "Ground") {
			if (!isGrounded)
				isGrounded = true;
		}
	}

	private void OnCollisionExit2D ( Collision2D collision ){
		if (collision.gameObject.tag == "Ground") {
			if (isGrounded)
				isGrounded = false;
		}
	}
}
