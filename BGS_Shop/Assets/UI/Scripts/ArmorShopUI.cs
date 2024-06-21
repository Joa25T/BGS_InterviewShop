using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArmorShopUI : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [Header("Model options")]
    [SerializeField] private List<Sprite> _models;
    [SerializeField] private Image _image;
    private int _modelID = 0;

    [Header("Enchantments")] 
    [SerializeField] private TMP_Text _enchantmentText;
    [SerializeField] private TMP_Text _enchantmentDescription;
    [SerializeField] private int _totalEnchantments = 3;
    private int _enchantmentID = 0;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnchantmentUp()
    {
        _enchantmentID++;
        if (_enchantmentID > _totalEnchantments - 1) _enchantmentID = 0;
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
        switch(_enchantmentID)
        {
            case(0):
                _image.color = Color.white;
                _enchantmentText.text = "Normal";
                _enchantmentDescription.text = "A normal set of armor";
                break;
            case (1):
                _image.color = new Color(1, .3f, .3f, 1);
                _enchantmentText.text = "Bloodied";
                _enchantmentDescription.text = "Blood is harder to notice on a red armor";
                break;
            case(2):
                _image.color = new Color(.2f, .5f, 1, 1);
                _enchantmentText.text = "Silent";
                _enchantmentDescription.text = "Sneak by with this super silent armor";
                break;
        }
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
    }
}
