using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingPentagramUI : MonoBehaviour
{
    [Header("Body Renderers")]
    [SerializeField] private Image _hood;
    [SerializeField] private Image _mask;
    [SerializeField] private Image _torso;
    
    [Header("Data References")]
    [SerializeField] private ItemListScriptable _spriteReferences;
    [SerializeField] private List<EnchantmentsScriptable> _enchantmentReferences;

    [SerializeField] private HUDManager _hudManager;

    private void OnEnable()
    {
        // pulling the models from our list of references using the asigned ID
        if (_hudManager.SelectedItems.ContainsKey(0))
        {
            _hood.sprite = _spriteReferences._hoods[_hudManager.SelectedItems[0].ModelID];
            _hood.color = _enchantmentReferences[_hudManager.SelectedItems[0].EnchantmentID].TintColor; 
        }
        else
        {
            _hood.color = Color.clear;
        }
        if (_hudManager.SelectedItems.ContainsKey(1))
        {
            _mask.sprite = _spriteReferences._masks[_hudManager.SelectedItems[1].ModelID];
            _mask.color = Color.white;
        }
        else
        {
            _mask.color = Color.clear;
        }
        if (_hudManager.SelectedItems.ContainsKey(2))
        {
            _torso.sprite = _spriteReferences._torsos[_hudManager.SelectedItems[2].ModelID];
            _torso.color = _enchantmentReferences[_hudManager.SelectedItems[2].EnchantmentID].TintColor; 
        }
        else
        {
            _torso.color = Color.clear;
        }
    }
}
