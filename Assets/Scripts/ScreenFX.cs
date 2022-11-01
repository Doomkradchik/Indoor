using System;
using System.Collections;
using UnityEngine;

public class ScreenFX : MonoBehaviour
{
    [SerializeField]
    private Material _material;

    [SerializeField]
    private float _noisesDuration;
    [SerializeField]
    private float _transparencyTimeStart;
    [SerializeField]
    private float _transparencyTimeEnd;

    private readonly float _minNoises = 0f;
    private readonly float _maxNoises = 1f;

    private const string NOISES_PROPERTY_KEY = "_noisesPercentage";

    private Coroutine _invokeNoisesRoutine;
    private float _currentPercentage;

    private float Percentage
    {
        set 
        {
            _currentPercentage = 1f - value;
            _material.SetFloat(NOISES_PROPERTY_KEY, _currentPercentage);
        }
    }

    private void OnEnable()
    {
        Percentage = _minNoises;
    }

    [ContextMenu("InvokeNoises")]
    public void InvokeNoises(ActionData<Camera> onCamChanged)
    {
        _invokeNoisesRoutine = StartCoroutine(PerformNoises(onCamChanged));
    }

    private IEnumerator PerformNoises(ActionData<Camera> onCamChanged)
    {
        yield return 
            StartCoroutine(PureMaterialTransparency(_minNoises, _maxNoises, _transparencyTimeStart));

        var waitForDuration = new WaitForSeconds(_noisesDuration);
        yield return waitForDuration;

        onCamChanged.Launch();

        yield return
            StartCoroutine(PureMaterialTransparency(_maxNoises, _minNoises, _transparencyTimeEnd));


    }

    private IEnumerator PureMaterialTransparency(float from, float to, float time) 
    {
        var expiredSeconds = 0f;
        var progress = 0f;

        while (progress < 1f)
        {
            expiredSeconds += Time.fixedDeltaTime;
            progress = (float)(expiredSeconds / time);
            Percentage = Mathf.Lerp(from, to, progress);

            yield return null;
        }
    }
    

    public class ActionData<T>
    {
        public T OldContext;
        public T NewContext;
        public Action<T, T> Changed;

        public void Launch()
        {
            Changed?.Invoke(OldContext, NewContext);
        }
    }

}
