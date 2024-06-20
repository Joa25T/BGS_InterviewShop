using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorShopUI : MonoBehaviour
{
    [SerializeField] private List<Sprite> _models;
    [SerializeField] private Image _image;
    [SerializeField] private Animator _animator;

    private int _modelID = 0;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
