using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveProgressBar : SliderController
{
    [SerializeField] private Spawner _spawner;

    protected override float TargetValue { get => _spawner.CurrentWaveProgress; }
}
