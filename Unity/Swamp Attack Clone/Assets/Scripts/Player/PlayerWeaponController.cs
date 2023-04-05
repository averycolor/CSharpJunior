using UnityEngine;
using UnityEditor;
using Unity;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Linq;

class PlayerWeaponController: MonoBehaviour
{
    [SerializeField] private int _startingWeaponIndex;
    [SerializeField] private List<Weapon> _weaponPrefabs;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private WeaponCard _currentWeaponCard;
    [SerializeField] private Shop _shop;

    private int _currentWeaponIndex;
    private Weapon _currentWeapon;
    private List<Weapon> _weapons = new List<Weapon>();

    public int WeaponCount => _weapons.Count;

    public event UnityAction WeaponsInitialized;

    private void OnEnable()
    {
        _shop.Purchase += ReorderWeapons;
    }

    private void OnDisable()
    {
        _shop.Purchase -= ReorderWeapons;
    }

    private void Start()
    {
        _weapons = new List<Weapon>();

        foreach (Weapon weaponPrefab in _weaponPrefabs)
        {
            Weapon weaponInstance = Instantiate(weaponPrefab, transform);
            weaponInstance.Init(_shootPoint);
            _weapons.Add(weaponInstance);
        }

        SetWeapon(_startingWeaponIndex);
        ReorderWeapons();

        WeaponsInitialized?.Invoke();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _currentWeapon.StartShooting();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _currentWeapon.StopShooting();
            }
            if (Input.GetMouseButton(0))
            {
                _currentWeapon.Shoot();
            }
        }

        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && i < _weapons.Count)
            {
                Weapon weapon = _weapons[i];

                if (weapon.IsBought)
                {
                    SetWeapon(i);
                }
            }
        }
    }

    public void SelectNextWeapon()
    {
        int newIndex = AdjustWeaponIndex(_currentWeaponIndex + 1);

        if (_weapons[newIndex].IsBought)
        {
            SetWeapon(newIndex);
        }
    }

    public void SelectPreviousWeapon()
    {
        int newIndex = AdjustWeaponIndex(_currentWeaponIndex - 1);

        if (_weapons[newIndex].IsBought)
        {
            SetWeapon(newIndex);
        }
    }

    public bool TryGetWeaponAt(int index, out Weapon result)
    {
        if (index < _weapons.Count)
        {
            result = _weapons[index];
            return true;
        }

        result = null;
        return false;
    }

    private void ReorderWeapons()
    {
        _weapons = _weapons.OrderBy(weapon => weapon.IsBought).ToList();
    }

    private int AdjustWeaponIndex(int index)
    {
        if (index >= _weapons.Count)
        {
            return index % _weapons.Count;
        }
        else if (index < 0)
        {
            return _weapons.Count - 1 + index;
        }
        else
        {
            return index;
        }
    }

    private void SetWeapon(int newIndex)
    {
        _currentWeaponIndex = newIndex;
        _currentWeapon = _weapons[_currentWeaponIndex];
        _currentWeaponCard.DisplayWeapon(_currentWeapon);
    }
}