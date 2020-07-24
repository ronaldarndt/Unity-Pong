using UnityEngine;

public class PadBehaviour : MonoBehaviour
{
    private const float MOV_SPEED = 1;

    private Rigidbody2D _rb2;

    void Start()
    {
        _rb2 = GetComponent<Rigidbody2D>();
    }

    public void Move(int dir)
    {
        _rb2.MovePosition(_rb2.position + new Vector2(0, dir));
    }
}
