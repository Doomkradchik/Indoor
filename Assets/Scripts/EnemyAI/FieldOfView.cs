using System;
using UnityEngine;

public class MonsterFieldOfViewSmartMesh
{
    public MonsterFieldOfViewSmartMesh(MeshFilter filter, Properties properties)
    {
        _startingAngle = 0f;
        _origin = Vector3.zero;

        _viewField = new Mesh();
        filter.mesh = _viewField;

        _vertices = new Vector3[properties._rayCount + 2];
        _triangles = new int[properties._rayCount * 3];
        _properties = properties;
    }
    public event Action TargetCollided;

    private Vector3 _origin;
    private Vector3[] _vertices;
    private int[] _triangles;
    private float _startingAngle;
    private Mesh _viewField;
    private readonly Properties _properties;

    public MonoBehaviour Target { get; set; }

    public MonsterFieldOfViewSmartMesh SetAngleByDirection(Vector3 dir)
    {
        dir = dir.normalized;
        var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        if (angle < 0f)
            angle += 360f;

        _startingAngle = angle - _properties._angleOfView * 0.5f;
        return this;
    }
    public MonsterFieldOfViewSmartMesh SetOrigin(Vector3 origin)
    {
        _origin = origin;
        return this;
    }

    public void GenerateMesh()
    {
        _vertices[0] = _origin;
        var ti = 0;
        var vi = 1;
        var angle = _startingAngle;
        var distance = _properties._viewDistance;

        for (int i = 0; i < _properties._rayCount + 1; i++)
        {      
            var ray = new Ray(_origin, GetDirectionFromAngle(angle));

            var rayVelocity = Physics.Raycast(ray, out RaycastHit hit, distance, _properties._layerMask)
                ? CheckCollider(hit)
                : ray.origin + ray.direction * distance;


            _vertices[vi] = rayVelocity;
            angle -= _properties.DeltaAngle;

            if (i > 0)
            {
                _triangles[ti] = 0;
                _triangles[ti + 1] = vi - 1;
                _triangles[ti + 2] = vi;
                ti += 3;
            }

            vi++;
        }
    }

    public void ApplyModifications()
    {
        _viewField.vertices = _vertices;
        _viewField.triangles = _triangles;

        _viewField.RecalculateNormals();
    }

    private Vector3 CheckCollider(RaycastHit hit)
    {
        if (Target != null && hit.collider.gameObject == Target.gameObject)
            TargetCollided?.Invoke();

        return hit.point;
    }

    private Vector3 ConvertToTopDown(Vector2 xy_plane)
    {
        return new Vector3(xy_plane.x, 0f , xy_plane.y);
    }

    private Vector3 GetDirectionFromAngle(float angle)
    {
        var rad = angle * (Mathf.PI / 180f);
        var direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        return ConvertToTopDown(direction);
    }

    [Serializable]
    public class Properties
    {
        public float _angleOfView;
        public int _rayCount;
        public float _viewDistance;
        public LayerMask _layerMask;
        public float DeltaAngle => _angleOfView / _rayCount;
    }
}
