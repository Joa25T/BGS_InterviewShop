using System;
using System.Collections.Generic;
using UnityEngine;

public class OutfitAssigner : MonoBehaviour
{
    [Header("Body Renderers")]
    [SerializeField] private SpriteRenderer _hood;
    [SerializeField] private SpriteRenderer _mask;
    [SerializeField] private SpriteRenderer _torso;
    [SerializeField] private SpriteRenderer _pelvis;
    [SerializeField] private SpriteRenderer _leftElbow;
    [SerializeField] private SpriteRenderer _rightElbow;

    [Header("Data References")]
    [SerializeField] private ItemListScriptable _spriteReferences;
    [SerializeField] private List<EnchantmentsScriptable> _enchantmentReferences;

    private void OnEnable()
    {
        HUDManager.CallChange += OutfitChange;
    }

    private void OnDisable()
    {
        HUDManager.CallChange -= OutfitChange;
    }

    private void OutfitChange(Dictionary<int,ChosenItem> selectedItems)
    {
        // pulling the models from our list of references using the asigned ID
        if (selectedItems.ContainsKey(0))
        {
            _hood.sprite = _spriteReferences._hoods[selectedItems[0].ModelID];
            _hood.color = _enchantmentReferences[selectedItems[0].EnchantmentID].TintColor; 
        }

        if (selectedItems.ContainsKey(1))
        {
            _mask.sprite = _spriteReferences._masks[selectedItems[1].ModelID];
        }

        if (selectedItems.ContainsKey(2))
        {
            _torso.sprite = _spriteReferences._torsos[selectedItems[2].ModelID];
            _torso.color = _enchantmentReferences[selectedItems[2].EnchantmentID].TintColor;
            
            _pelvis.sprite = _spriteReferences._pelvis[selectedItems[2].ModelID];
            _pelvis.color = _enchantmentReferences[selectedItems[2].EnchantmentID].TintColor; 
            
            _leftElbow.sprite = _spriteReferences._leftElbows[selectedItems[2].ModelID];
            _leftElbow.color = _enchantmentReferences[selectedItems[2].EnchantmentID].TintColor; 
            
            _rightElbow.sprite = _spriteReferences._rightElbows[selectedItems[2].ModelID];
            _rightElbow.color = _enchantmentReferences[selectedItems[2].EnchantmentID].TintColor; 
        }
    }
}
