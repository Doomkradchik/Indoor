using System;
using UnityEngine;

public class GeneratorCompositeRoot : MonoBehaviour
{
    [SerializeField]
    private Generator[] _generators;

    [SerializeField]
    private SimpleAITester _tester;
    private int _count = 0;

    public event Action AllGeneratorsRepaired;
    private int RepairedCount
    {
        get => _count;
        set
        {
            _count = value;
            if (_count >= _generators.Length)
                AllGeneratorsRepaired?.Invoke();
        }
    }


    private void OnEnable()
    {
        foreach (var generator in _generators)
        {
            generator.Repaired += _tester.OnGeneratorRepaired;
            generator.Repaired += (interaction) => RepairedCount++;
        }
    }
}
