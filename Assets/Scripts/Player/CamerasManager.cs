using System.Collections.Generic;
using UnityEngine;


public static class NodeExtension
{
    public static LinkedListNode<T> GetNext<T>(this LinkedListNode<T> current, LinkedList<T> list)
    {
        if (current == list.Last)
            return list.First;

        return current.Next;
    }

    public static LinkedListNode<T> GetPrivious<T>(this LinkedListNode<T> current, LinkedList<T> list)
    {
        if (current == list.First)
            return list.Last;

        return current.Previous;
    }
}

public class CamerasManager : MonoBehaviour
{
    [SerializeField]
    private Camera[] _cameras;

    [SerializeField]
    private ScreenFX _screenFX;

    private LinkedList<Camera> _camerasList;
    private LinkedListNode<Camera> _current;
    public LinkedListNode<Camera> CurrentCameraNode
    {
        get => _current;
        set
        {
            _current = value;
            var data = new ScreenFX.ActionData<Camera>();

            data.OldContext = value.Value;
            data.NewContext = _current.Value;
            data.Changed = OnCameraChanged;

            _screenFX.InvokeNoises(data);
        }
    }

    private void Awake()
    {
        foreach(var cam in _cameras)
            cam.gameObject.SetActive(false);

        _camerasList = new LinkedList<Camera>(_cameras);
        CurrentCameraNode = _camerasList.First;
        CurrentCameraNode.Value.gameObject.SetActive(true);
    }

    public void Next() => CurrentCameraNode = CurrentCameraNode.GetNext(_camerasList);
    public void Previous() => CurrentCameraNode = CurrentCameraNode.GetPrivious(_camerasList);

    private void OnCameraChanged(Camera oldCam, Camera newCam)
    {
        oldCam.gameObject.SetActive(false);
        newCam.gameObject.SetActive(true);
    }
}
