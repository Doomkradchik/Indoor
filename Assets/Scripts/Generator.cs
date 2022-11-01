using System;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private Interaction _interaction;

    [SerializeField]
    private GameObject _brokenPrefab;

    [SerializeField]
    private GameObject _newPrefab;

    [SerializeField]
    private float _reparationTime;

    public float ReparationTime => _reparationTime;

    public event Action<Interaction> Repaired;
    public bool isRepaired { get; private set; } = false;

    private void OnEnable()
    {
        _brokenPrefab.SetActive(true);
        _newPrefab.SetActive(false);
    }

    public void Repair()
    {
        isRepaired = true;
        Repaired?.Invoke(_interaction);
        UpdateState();
    }

    private void UpdateState()
    {
        _brokenPrefab.SetActive(false);
        _newPrefab.SetActive(true);
    }
}
