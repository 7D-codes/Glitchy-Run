using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    //FPS Counter
    [SerializeField] private TextMeshProUGUI fpsText;
    private float _timer;
    private float _refresh = 0.1f;
    private int _frames;
    private void Start()
    {
        //FPS Counter
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            _timer = Time.unscaledTime + _refresh;
            fpsText.text = _frames.ToString("D2");
            _frames = 0;
        }
        _frames++;
    }


}