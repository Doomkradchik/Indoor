using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class Interaction : MonoBehaviour
{
    private Transform[] _spots;
    public IEnumerable<Transform> Spots => _spots;

    private void OnEnable()
    {
        _spots = transform
            .GetComponentsInChildren<Transform>()
            .Skip(1)
            .ToArray();
    }

    public IEnumerable<Transform> GetRandomSpotsByAmount(int amount)
    {

        if (amount > _spots.Length)
            amount = _spots.Length;

        var copy = _spots.ToList();

        for (int i = 0; i < amount; i++)
        {
            var index = Random.Range(0, copy.Count);
            yield return copy[index];
            copy.RemoveAt(index);
        }
    }
}