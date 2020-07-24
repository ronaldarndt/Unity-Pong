using Extensions;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameBehaviour : MonoBehaviour
{
    private PadBehaviour[] _pads;
    private BallBehaviour _ball;

    private Text[] _textsScore;

    public static GameInfoContainer GameContainer;

    void Start()
    {
        _pads = FindObjectsOfType<PadBehaviour>();

        _ball = FindObjectOfType<BallBehaviour>();
        _ball.Initiate();

        _textsScore = FindObjectsOfType<Text>();

        GameContainer = new GameInfoContainer();

        SoundHelper.Load();
        SoundHelper.Play(SoundHelper.Audios.Beep);
    }

    void Update()
    {
        _textsScore.First(x => x.name == "score_1").text = GameContainer.Score.Player1.ToString("00");
        _textsScore.First(x => x.name == "score_2").text = GameContainer.Score.Player2.ToString("00");

        if (Input.GetKey(KeyCode.W))
        {
            _pads[1].Move(1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _pads[1].Move(-1);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _pads[0].Move(1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _pads[0].Move(-1);
        }
        else if (Input.GetKey(KeyCode.R))
        {
            _ball.Initiate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.position.x < 0)
        {
            GameContainer.Score.Player1++;
        }
        else
        {
            GameContainer.Score.Player2++;
        }

        _ball.Initiate();
        SoundHelper.Play(SoundHelper.Audios.Beep);
    }
}
