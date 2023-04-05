using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : SliderController
{
    [SerializeField] private Player _player;

    protected override float TargetValue => (float)_player.Health / _player.MaxHealth;
}
