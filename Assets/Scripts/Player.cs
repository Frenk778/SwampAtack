using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Wapon> _wapons;
    [SerializeField] private Transform _shotPoint;

    private Wapon _currentWapon;
    private int _currentHealth;
    private Animator _animator;    
    
    public int Money { get; private set; }

    private void Start()
    {
        _currentWapon = _wapons[0];
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWapon.Shoot(_shotPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    private void OnEnemyDied(int reward)
    {
        Money += reward;
    }


    public void AddMoney(int money)
    {
        Money += money;
    }
}
