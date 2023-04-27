using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _shootPoint;

    private Projectile _currentProjectile;
    private PlayerInput _input;

    private void OnEnable()
    {
        if (_input == null)
        {
            _input = GetComponent<PlayerInput>();
        }

        _input.ChargeShot += CreateProjectile;
        _input.ReleaseShot += ReleaseProjectile;
    }

    private void CreateProjectile()
    {
        if (_currentProjectile == null)
        {
            _currentProjectile = Instantiate(_projectile, _shootPoint);
        }
    }

    private void ReleaseProjectile()
    {
        if (_currentProjectile != null)
        {
            _currentProjectile.TryRelease();
            _currentProjectile.transform.SetParent(null);
            _currentProjectile = null;
        }
    }
}