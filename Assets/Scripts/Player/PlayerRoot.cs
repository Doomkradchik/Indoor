using UnityEngine;

public class PlayerRoot : MonoBehaviour, IPauseHandler
{
    [SerializeField]
    private CamerasManager _cameraManager;

    [SerializeField]
    private float _unitsPerSecond;
    public IMovable Movement { get; private set; }

    private GeneratorInteraction _current;
    private Animator _animator;

    private readonly string _repairMotionKey = "isRepairing";

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        Movement = new MovementSystem(transform, _cameraManager, GetComponent<Rigidbody>(),
            _animator, _unitsPerSecond);

        GameManager.Subscribe(this);
    }

    private void OnDisable()
    {
        GameManager.Unsubscribe(this);
    }

    public void Unpause()
    {
        Movement.Freeze = false;
    }

    public void Pause()
    {
        Movement.Freeze = true;
    }

    public void TryDoInteraction()
    {
        if (_current == null)
            return;

        if (_current.isEnabled == false)
            return;

        Movement.Freeze = true;

        _current.SetRotationToGenerator(transform);
        _current.SetPosition(transform);

        _animator.SetBool(_repairMotionKey, true);
        _current.Execute(TryCancelIntercation);
    }

    public void TryCancelIntercation()
    {
        if (_current == null)
            return;

        _animator.SetBool(_repairMotionKey, false);
        Movement.Freeze = false;
        _current.Undo();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GeneratorInteraction gInteraction))
        {
            _current = gInteraction;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out GeneratorInteraction gInteraction))
        {
            TryCancelIntercation();
            _current = null;
        }
    }

}

