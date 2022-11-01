using System;
using UnityEngine;

public class Instuction : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _slides;

    [SerializeField]
    private GameObject _cameras;

    [SerializeField]
    private Camera _cam;

    private int _index = 0;

    public event Action Ended;

    private void Start()
    {
        _cameras.SetActive(false);
        GameManager.Pause();
        Refresh(_slides[_index]);
    }

    public void Next()
    {
        _index++;

        if(_index >= _slides.Length)
        {
            Ended?.Invoke();
            _cam.gameObject.SetActive(false);
            _cameras.SetActive(true);
            GameManager.Unpause();
            enabled = false;
            return;
        }

        Refresh(_slides[_index]);
    }

    private void Refresh(GameObject slide)
    {
        foreach(var sl in _slides)
            sl.SetActive(false);

        slide.SetActive(true);
    }
}
