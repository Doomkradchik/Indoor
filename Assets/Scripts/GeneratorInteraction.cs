using System;
using System.Collections;
using UnityEngine;

public class GeneratorInteraction : MonoBehaviour
{
    [SerializeField]
    private Generator _generator;

    public Generator Generator => _generator;
    public bool isEnabled => !_generator.isRepaired;

    private Coroutine _repairingRoutine;

    public event Action ProgressChanged;

    private readonly float _soundDeltaStep = 0.3f;

    private float _progress;
    public float ProgressBar
    {
        get => _progress;

        private set
        {
            _progress = value;
            ProgressChanged?.Invoke();
            Debug.Log(_progress);
        }
    }

    public void Execute(Action onEnded)
    {
        _repairingRoutine = StartCoroutine(RepairingRoutine(onEnded));
    }

    public void Undo()
    {
        SoundAudioManager.Instance
          .StopSound(SoundAudioManager.AudioData.Kind.Repairing);

        if (_repairingRoutine != null)
             StopCoroutine(_repairingRoutine);
        ProgressBar = 0f;
    }

    public void SetRotationToGenerator(Transform perfromer)
    {
       var dir = (_generator.transform.position -
       transform.position).normalized;

        dir = new Vector3(dir.x, 0f, dir.z);
        perfromer.rotation = Quaternion.LookRotation(dir
            , Vector3.up);
    }

    public void SetPosition(Transform perfromer)
    {
        perfromer.position = new Vector3(
            transform.position.x,
            perfromer.position.y,
            transform.position.z);
    }

    private IEnumerator RepairingRoutine(Action onEnd)
    {
        var expiredSec = 0f;

        while(ProgressBar < 1f)
        {
            expiredSec += Time.fixedDeltaTime;
            ProgressBar = expiredSec / _generator.ReparationTime;

            if(expiredSec >= _soundDeltaStep)
                SoundAudioManager.Instance
                   .PlaySound(SoundAudioManager.AudioData.Kind.Repairing);

            yield return null;
        }
        _generator.Repair();

        SoundAudioManager.Instance
                   .PlaySound(SoundAudioManager.AudioData.Kind.ReparationDone);
        onEnd.Invoke();
    }

}
