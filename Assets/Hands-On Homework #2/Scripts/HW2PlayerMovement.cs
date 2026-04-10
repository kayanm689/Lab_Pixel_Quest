using UnityEngine;

public class HW2PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float _xspeed;
    private float _yspeed;

    public float speed = 3;

    private string InputX = "Horizontal";
    private string InputY = "Vertical";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _xspeed = Input.GetAxis(InputX);
        _yspeed = Input.GetAxis(InputY);

        _rigidbody2D.velocity = new Vector2(_xspeed, _yspeed) * speed;
    }

}
