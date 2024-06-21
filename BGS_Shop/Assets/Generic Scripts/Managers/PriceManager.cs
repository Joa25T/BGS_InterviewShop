using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PriceManager : MonoBehaviour
{
    public static PriceManager Instance;
    private TMP_Text _currencyText;
    private TMP_Text _costText;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    private void OnItemGrab(int cost)
    {
        _costText.text = "-" + cost;
    }
    
}
