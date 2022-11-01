using UnityEngine;

public class FieldViewManager : MonoBehaviour
{
    [SerializeField]
    private SimpleAITester _target;

    [SerializeField]
    private MonsterFieldOfViewSmartMesh.Properties _properties;

    private MonsterFieldOfViewSmartMesh _mosterFiew;

    private void Awake()
    {
        _mosterFiew = new MonsterFieldOfViewSmartMesh(GetComponent<MeshFilter>(), _properties);
        _target.Init(_mosterFiew);
    }

    private void Update()
    {
        _mosterFiew
            .SetOrigin(_target.transform.position)
            .SetAngleByDirection(-_target.transform.right);

        _mosterFiew.GenerateMesh();
        _mosterFiew.ApplyModifications();
    }
}
