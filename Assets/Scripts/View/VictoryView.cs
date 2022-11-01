using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryView : MonoBehaviour
{
    [SerializeField]
    private Camera _victoryPreview;

    [SerializeField]
    private GeneratorCompositeRoot _generatorComRoot;

    private void OnEnable()
    {
        _generatorComRoot.AllGeneratorsRepaired += Perform;
    }

    private void Perform()
    {
        GameManager.Pause();

        _victoryPreview.gameObject.SetActive(true);
    }
}
