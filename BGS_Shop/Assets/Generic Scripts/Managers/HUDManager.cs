using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [Header("Currency")]
    //[SerializeField] private TMP_Text _currencyText;
    [SerializeField] private TMP_Text _currencyText2;
    [SerializeField] private int _initialCurrency;
    
    [Header("Costs")]
    //[SerializeField]private TMP_Text _costText;
    [SerializeField]private TMP_Text _costText2;
    [SerializeField]private int _totalCost = 0;

    private Dictionary<int, ChosenItem> SelectedItems;
    
    private void Awake()
    {
        SelectedItems = new Dictionary<int, ChosenItem>();
    }

    private void OnEnable()
    {
        ShopUI.ItemGrabbed += GrabItem;
        _currencyText2.text = _initialCurrency.ToString();
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
            _costText2.text = "";
            return;
        }
        _costText2.text = $"-{_totalCost}";
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
}
