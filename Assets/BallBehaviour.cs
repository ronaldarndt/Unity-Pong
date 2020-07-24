using Extensions;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float InitialSpeed = 15f;
    public float SpeedIncrease = 1.05f;

    private float _speed;
    private Vector2 _force;
    private Rigidbody2D _rb2;

    void Start()
    {
        _rb2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb2.MovePosition(_rb2.position + (_force * _speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var x = _force.x;
        var y = _force.y * -1;

        if (col.gameObject.name.Contains("pad"))
        {
            if (col.contactCount > 0)
            {
                var contacts = new ContactPoint2D[1];
                col.GetContacts(contacts);

                var contact = contacts[0];
                var bounds = contact.collider.bounds;

                const float BALL_HEIGHT = 0.5f;

                y = contact.point.y.Remap(
                    (Mathf.Abs(bounds.min.y) + BALL_HEIGHT) * Mathf.Sign(bounds.min.y),
                    (Mathf.Abs(bounds.max.y) + BALL_HEIGHT) * Mathf.Sign(bounds.max.y),
                    -1,
                    1);
            }

            x *= -1;

            _speed *= SpeedIncrease;
        }

        _force = new Vector2(x, y);

        SoundHelper.Play(SoundHelper.Audios.Plop);
    }

    public void Initiate()
    {
        _rb2.position = CameraHelper.Center;

        _speed = InitialSpeed;
        _force = new Vector2(Random.value > 0.5 ? -1 : 1, Random.Range(-1, 1));
    }
}
