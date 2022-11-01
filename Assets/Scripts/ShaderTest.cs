using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTest : MonoBehaviour
{
    //Test
    [SerializeField]
    private Material _material;
    private readonly string _propertyKey = "_noisesPercentage";

    [Range(0f, 1f)]
    public float _noisesPercentage;
    void Update()
    {
        _material.SetFloat(_propertyKey, _noisesPercentage);
    }
}
