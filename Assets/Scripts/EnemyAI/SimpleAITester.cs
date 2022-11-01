using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SimpleAITester : MonoBehaviour, IPauseHandler
{
    [SerializeField]
    private PlayerRoot _playerTest;

    [SerializeField]
    private Transform _interactionsRoot;

    [SerializeField]
    private int _spotAmountToCheck;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private NavMeshAgent _agent;

    public event Action GameEnded;

    private MonsterFieldOfViewSmartMesh _fiew;

    private Interaction _currentInteraction;
    private readonly string _isRunningKey = "isRunning";
    private readonly string _screamKey = "Scream";
    private readonly string _turnAroundKey = "TurnAround";

    private readonly float _screamTime = 2f;
    private readonly float _checkOutTime = 6f;

    private const float SPEED_RATIO = 2f;
    private const float MIN_DISTANCE = 0.8f;

    private Interaction[] _interactions;

    private bool _spotted = false;
    private bool _inited = false;

    public void Init(MonsterFieldOfViewSmartMesh fiew)
    {
        _fiew = fiew;
        _inited = true;
        enabled = true;
    }

    public void Unpause()
    {
        SetNewRandomInteraction();
        StartCoroutine(ExecuteInteractionsRoutine());
    }

    public void Pause()
    {
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        if(_inited == false)
        {
            enabled = false;
            return;
        }
        GameManager.Subscribe(this);
        _interactions = _interactionsRoot
          .GetComponentsInChildren<Interaction>()
          .ToArray();

        _fiew.Target = _playerTest;
        _fiew.TargetCollided += OnPlayerSpoted;
    }

    private void OnDisable()
    {
        if (_inited == false)
            return;

        _fiew.TargetCollided -= OnPlayerSpoted;
        StopAllCoroutines();

        GameManager.Unsubscribe(this);
    }

    public void OnGeneratorRepaired(Interaction interaction)
    {
        StartCoroutine(CheckRoom(interaction));
    }

    private IEnumerator CheckRoom(Interaction interaction)
    {
        StopAllCoroutines();
        _currentInteraction = interaction;
        _animator.SetBool(_isRunningKey, true);
        yield return StartCoroutine(ExecuteInteractionsRoutine());
    } 

    private void SetNewRandomInteraction()
    {
        int index;

        if (_interactions.Length < 2)
            throw new InvalidOperationException();
        
        if (_currentInteraction == null)
        {
            index = Random.Range(0, _interactions.Length);
            _currentInteraction = _interactions[index];
            return;
        }

        var interactions = _interactions
            .Where(interaction => interaction != _currentInteraction)
            .ToArray();

        index = Random.Range(0, interactions.Length);
        _currentInteraction = interactions[index];
    } 

    private IEnumerator WalkTo(Transform spot)
    {
        float distance;
        _animator.SetBool(_isRunningKey, true);
        do
        { 
            _agent.SetDestination(spot.position);
            distance = (transform.position - spot.position).magnitude;
            yield return null;
        }
        while (distance > MIN_DISTANCE);
        _animator.SetBool(_isRunningKey, false);
    }

    private IEnumerator ExecuteInteraction(Interaction interaction)
    {
        if (interaction == null)
            throw new NullReferenceException();


        yield return StartCoroutine(WalkTo(interaction.transform));
        var spots = interaction.GetRandomSpotsByAmount(_spotAmountToCheck);

        _animator.SetTrigger(_screamKey);
        yield return new WaitForSeconds(_screamTime);

        foreach (var spot in spots)
        {
            yield return StartCoroutine(WalkTo(spot));
            yield return new WaitForSeconds(_checkOutTime / 2f);
            _animator.SetTrigger(_turnAroundKey);
            yield return new WaitForSeconds(_checkOutTime / 2f);
        }
    }

    private IEnumerator ExecuteInteractionsRoutine()
    {
        while (true)
        {      
            yield return StartCoroutine(ExecuteInteraction(_currentInteraction));
            SetNewRandomInteraction();
        }
    }

    private void OnPlayerSpoted()
    {
        if(_spotted == false)
        {
            StopAllCoroutines();
            StartCoroutine(KillTargetRoutine());
            _spotted = true;
        }
    }

    private IEnumerator KillTargetRoutine()
    {
        _agent.speed *= SPEED_RATIO;

        yield return WalkTo(_playerTest.transform);

        GameEnded?.Invoke();
    }

}
