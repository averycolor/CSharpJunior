using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class WeaponCard : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Image _iconImage;
    [SerializeField] private Button _buyButton;

    private Weapon _weapon;

    public event UnityAction<Weapon> BuyClick;

    private void Start()
    {
        if (_buyButton != null)
        {
            _buyButton.onClick.AddListener(() => BuyClick.Invoke(_weapon));
        }
    }

    private void Update()
    {
        if (_buyButton != null)
        {
            _buyButton.gameObject.SetActive(_weapon.IsBought == false);
        }
    }

    public void DisplayWeapon(Weapon weapon)
    {
        _weapon = weapon;

        if (_titleText != null)
        {
            _titleText.text = _weapon.Name;
        }
        
        if (_descriptionText != null)
        {
            _descriptionText.text = _weapon.Description;
        }

        if (_priceText != null)
        {
            _priceText.text = _weapon.Price.ToString();
        }

        if (_iconImage != null)
        {
            _iconImage.sprite = _weapon.Icon;
            _iconImage.SetNativeSize();
        }
    }
}
