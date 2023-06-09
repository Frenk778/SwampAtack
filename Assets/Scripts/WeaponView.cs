using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button  _sellButton;

    private Wapon _wapon;

    public event UnityAction<Wapon,WeaponView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    private void TryLockItem()
    {
        if (_wapon.IsBuyed)
        {
            _sellButton.interactable = false;
        }
    }


    public void Render(Wapon wapon)
    {
        _wapon = wapon;
        _label.text = wapon.Label;
        _price.text = wapon.Price.ToString();
        _icon.sprite = wapon.Icon;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_wapon,this);
    }
}