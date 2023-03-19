using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Wapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;


    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Wapon wapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(wapon);
    }

    private void OnSellButtonClick(Wapon wapon, WeaponView view)
    {
        TrySellWeapon(wapon,view);
    }

    private void TrySellWeapon(Wapon wapon, WeaponView view)
    {
        if (wapon.Price <= _player.Money)
        {
            _player.BuyWeapon(wapon);
            wapon.Buy();
            view.SellButtonClick -= OnSellButtonClick;
        }
    }

}
