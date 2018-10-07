using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float jumpPower = 700f;

    private PlayerWalk playerWalk;
    private Rigidbody2D rb;

    private void Start ()
    {
        playerWalk = GetComponent<PlayerWalk> ();

        rb = GetComponent<Rigidbody2D> ();
    }

    private void Update ()
    {
        if ( Input.GetKeyDown ( KeyCode.Space ) )
        {
            if ( playerWalk.isGrounded )
            {
                rb.AddForce ( Vector2.up * jumpPower );
            }
        }
    }
}