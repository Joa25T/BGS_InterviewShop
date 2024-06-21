using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [Header("Model options")]
    [Tooltip("ID of the armor part: 0 for hood , 1 for mask , 2 for armor")][SerializeField] private int _partID;
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

    private ChosenItem _chosenItem;

    public static Action<ChosenItem> ItemGrabbed;
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
        if (_chosenItem== null) _chosenItem = new ChosenItem(_partID, _modelID, _enchantmentID);
        else _chosenItem.UpdateValues(_partID, _modelID, _enchantmentID);
        _selectionPrice = _chosenItem.Price;
        _priceText.text = _selectionPrice.ToString();
    }

    public void GrabItem()
    {
        ItemGrabbed.Invoke(_chosenItem);
    }
}
