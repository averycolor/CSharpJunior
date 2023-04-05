using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    [SerializeField] private Transform _cardContainer;
    [SerializeField] private WeaponCard _cardTemplate;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerWeaponController _playerWeaponController;

    private List<WeaponCard> _cards = new List<WeaponCard>();

    public event UnityAction Purchase;

    private void OnEnable()
    {
        _playerWeaponController.WeaponsInitialized += UpdateWeaponCards;
    }

    public void OnBuyClick(Weapon weapon)
    {
        if (_player.AttemptPurchase(weapon.Price))
        {
            weapon.Buy();
            Purchase?.Invoke();
        }
    }

    private void UpdateWeaponCards()
    {
        int countDifference = _playerWeaponController.WeaponCount - _cards.Count;

        if (countDifference > 0)
        {
            for (int i = 0; i < countDifference; i++)
            {
                WeaponCard newCard = Instantiate(_cardTemplate, _cardContainer);
                _cards.Add(newCard);
            }
        } else if (countDifference < 0)
        {
            for (int i = 0; i < countDifference; i++)
            {
                _cards.RemoveAt(i);
                Destroy(_cards[i].gameObject);
            }
        }

        for (int i = 0; i < _cards.Count; i++)
        {
            if (_playerWeaponController.TryGetWeaponAt(i, out Weapon weapon))
            {
                WeaponCard card = _cards[i];
                card.DisplayWeapon(weapon);
                card.BuyClick += OnBuyClick;
            }
        }
    }
}
