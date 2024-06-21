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

    private Dictionary<int, ChosenItem> SelectedItems;
    public static Action<Dictionary<int, ChosenItem>> CallChange;
    
    private void Awake()
    {
        SelectedItems = new Dictionary<int, ChosenItem>();
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
        foreach (ChosenItem item in SelectedItems.Values)
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
        if (SelectedItems.ContainsKey(item.PartID))
        {
            SelectedItems[item.PartID] = item;
        }
        else
        {
            SelectedItems.Add(item.PartID,item);
        }
        CalculateCost();
    }

    public void RemoveAllItems()
    {
        SelectedItems.Clear();
        CalculateCost();
    }
    
    public void OnOutfitAccept()
    {
        CallChange.Invoke(SelectedItems);
        Pay();
    }
}
