using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScreenView : MonoBehaviour
{
    [SerializeField]
    private Text _timeText;

    [SerializeField]
    private float _duration;

    private Timer _timer;

    private void OnEnable()
    {
        _timer = new Timer(_duration);
        _timer.TimeChanged += UpdateTime;
    }

    private void OnDisable()
    {
        _timer.TimeChanged -= UpdateTime;
    }

    [ContextMenu("TimerLaunch")]
    public void LaunchTimer(Action onEnded) => _timer.Launch(onEnded);

    private void UpdateTime(float expiredTime)
    {
        var minutes = (int)( expiredTime / 60f);
        var seconds = expiredTime - minutes * 60f;

        var strMin = minutes > 9 ? minutes.ToString()
            : $"0{minutes.ToString()}";

        var strSec = seconds > 9 ? seconds.ToString()
          : $"0{seconds.ToString()}";

        _timeText.text = $"{strMin} : {strSec}";
    }

}