using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [Header("Currency")]
    [SerializeField] private TMP_Text _currencyText;
    [SerializeField] private int _initialCurrency;
    
    [Header("Costs")]
    [SerializeField]private TMP_Text _costText;
    private int _totalCost = 0;

    private Dictionary<int, ChosenItem> SelectedItems;
    
    private void Awake()
    {
        SelectedItems = new Dictionary<int, ChosenItem>();
    }

    private void OnEnable()
    {
        ShopUI.ItemGrabbed += GrabItem;
        _currencyText.text = _initialCurrency.ToString();
    }

    private void AddToCost(int cost)
    {
        _totalCost += cost;
        _costText.text = $"-{_totalCost}";
    }

    private void ReduceCost(int cost)
    {
        
    }

    public void GrabItem(ChosenItem item)
    {
        AddToCost(item.Price);
        if (SelectedItems.ContainsKey(item.PartID))
        {
            SelectedItems[item.PartID] = item;
        }
        else
        {
            SelectedItems.Add(item.PartID, item);
        }
    }
    
    
}
