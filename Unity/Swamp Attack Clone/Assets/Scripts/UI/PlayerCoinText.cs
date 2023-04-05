using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class PlayerCoinText : TextController
{
    [SerializeField] private Player _player;

    protected override string Text => _player.Money.ToString();
}
