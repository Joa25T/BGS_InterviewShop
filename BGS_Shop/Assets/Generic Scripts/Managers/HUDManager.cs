using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [Header("Currency")]
    [SerializeField] private TMP_Text _currencyText;
    [SerializeField] private int _initialCurrency;
    private int _currentCurrency;
    
    [Header("Costs")]
    [SerializeField]private TMP_Text _costText;
    private int _totalCost = 0;

    private Dictionary<int, ChosenItem> _selectedItems;
    public static Action<Dictionary<int, ChosenItem>> CallChange;

    public Dictionary<int, ChosenItem> SelectedItems => _selectedItems;
    private void Awake()
    {
        _selectedItems = new Dictionary<int, ChosenItem>();
        _currentCurrency = _initialCurrency;
    }

    private void OnEnable()
    {
        ShopUI.ItemGrabbed += GrabItem;
        _currencyText.text = _currentCurrency.ToString();
    }

    private void OnDisable()
    {
        ShopUI.ItemGrabbed -= GrabItem;
    }

    private void CalculateCost()
    {
        _totalCost =0;
        foreach (ChosenItem item in _selectedItems.Values)
        {
            _totalCost += item.Price;
        }
        if (_totalCost == 0)
        {
            _costText.text = "";
            return;
        }
        _costText.text = $"-{_totalCost}";
    }

    public void Pay()
    {
        _currentCurrency -= _totalCost;
        _currencyText.text = _currentCurrency.ToString();
        RemoveAllItems();
    }
    
    public void GrabItem(ChosenItem item)
    {
        if (_selectedItems.ContainsKey(item.PartID))
        {
            _selectedItems[item.PartID] = item;
        }
        else
        {
            _selectedItems.Add(item.PartID,item);
        }
        CalculateCost();
    }

    public void RemoveAllItems()
    {
        _selectedItems.Clear();
        CalculateCost();
    }
    
    public void OnOutfitAccept()
    {
        CallChange.Invoke(_selectedItems);
        Pay();
    }
}
