using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveNumberText : TextController
{
    [SerializeField] private Spawner _spawner;

    protected override string Text => (_spawner.CurrentWaveIndex + 1).ToString();
}
