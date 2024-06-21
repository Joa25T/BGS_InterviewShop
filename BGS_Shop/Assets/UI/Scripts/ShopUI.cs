using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [Header("Model options")]
    [SerializeField] private List<Sprite> _models;
    [SerializeField] private Image _image;
    private int _modelID = 0;

    [Header("Enchantments")] 
    [SerializeField] private TMP_Text _enchantmentText;
    [SerializeField] private TMP_Text _enchantmentDescription;
    [SerializeField] private List<EnchantmentsScriptable> _enchantments;
    private int _enchantmentID = 0;

    [Header("Price")] 
    [SerializeField] private TMP_Text _priceText;
    private int _selectionPrice;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void EnchantmentUp()
    {
        _enchantmentID++;
        if (_enchantmentID > _enchantments.Count - 1) _enchantmentID = 0;
        ChangeEnchantment();
    }

    public void EnchantmentDown()
    {
        _enchantmentID--;
        if (_enchantmentID < 0) _enchantmentID = 2;
        ChangeEnchantment();
    }

    private void ChangeEnchantment()
    {
        _image.color = _enchantments[_enchantmentID].TintColor;
        _enchantmentText.text = _enchantments[_enchantmentID].EnchantmentName;
        _enchantmentDescription.text = _enchantments[_enchantmentID].Description;
        CallForPrice();
    }

    public void ModelSwapAnimation(float id)
    {
        _modelID = (int)id;
        _animator.SetTrigger("ArmorSwapped");
    }
    
    
    public void ChangeModel()
    {
        //if (_modelID > _models.Count) return;
        //if (_image == null) return;
        _image.sprite = _models[_modelID];
        CallForPrice();
    }

    private void CallForPrice()
    {
        ChosenItem item = new ChosenItem(_modelID, _enchantmentID);
        _selectionPrice = Helpers.CalculateCost(item);
        _priceText.text = _selectionPrice.ToString();
    }
}
