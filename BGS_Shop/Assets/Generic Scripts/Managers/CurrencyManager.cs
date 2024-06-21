using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    [Header("Currency")]
    [SerializeField] private TMP_Text _currencyText;
    [SerializeField] private int _initialCurrency;
    
    [Header("Costs")]
    [SerializeField]private TMP_Text _costText;

    private Dictionary<int, ChosenItem> SelectedItems;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
        SelectedItems = new Dictionary<int, ChosenItem>();
    }

    private void OnItemGrab(int cost)
    {
        _costText.text = "-" + cost;
    }

    public void GrabItem(ChosenItem item)
    {
        
    }
    
    
}
