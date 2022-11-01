using UnityEngine;

public interface IMovable
{
    void Move(Vector2 input);
    bool Freeze { get; set; }
}
public class MovementSystem : IMovable
{
    public MovementSystem(Transform target, CamerasManager cameraManager, Rigidbody rigidbody,
        Animator animator, float unitsPerSecond)
    {
        this.target = target;
        this.cameraManager = cameraManager;
        this.rigidbody = rigidbody;
        this.animator = animator;
        this.unitsPerSecond = unitsPerSecond;
    }

    private readonly Transform target;
    private readonly CamerasManager cameraManager;
    private readonly Rigidbody rigidbody;
    private readonly Animator animator;
    private readonly float unitsPerSecond;

    private float _angleVelocity;
    private readonly float _smoothTime = 0.1f;
    private readonly string _runMotionKey = "isRunning";

    public bool Freeze { get; set; } = false;

    public void Move(Vector2 input)
    {
        if (Freeze)
        {
            SoundAudioManager.Instance
             .StopSound(SoundAudioManager.AudioData.Kind.Movement);

            return;
        }

        if (cameraManager.CurrentCameraNode == null)
            return;


        var camera = cameraManager.CurrentCameraNode.Value.transform;
        var _direction = camera.right * input.x +
            camera.forward * input.y;

        var plane = new Vector3(_direction.x, 0f, _direction.z).normalized;

        if (plane == Vector3.zero)
        {
            animator.SetBool(_runMotionKey, false);

            SoundAudioManager.Instance
              .StopSound(SoundAudioManager.AudioData.Kind.Movement);
            return;
        }

        animator.SetBool(_runMotionKey, true);

        var targetAngle = Mathf.Atan2(plane.x, plane.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(target.eulerAngles.y, 
            targetAngle, ref _angleVelocity, _smoothTime);

        var offset = plane * unitsPerSecond * Time.fixedDeltaTime;

        rigidbody.MovePosition(rigidbody.position + offset);
        target.rotation = Quaternion.Euler(0f, angle, 0f);

        SoundAudioManager.Instance
            .PlaySound(SoundAudioManager.AudioData.Kind.Movement);
    }

}
