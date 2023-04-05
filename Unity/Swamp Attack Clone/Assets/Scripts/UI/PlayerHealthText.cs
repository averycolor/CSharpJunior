using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthText : TextController
{
    [SerializeField] private Player _player;

    protected override string Text => _player.Health.ToString();
}
