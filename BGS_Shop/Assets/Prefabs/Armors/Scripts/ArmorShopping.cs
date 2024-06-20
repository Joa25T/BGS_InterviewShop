using System;
using UnityEngine;
using BGS_Shop.UI;

public class ArmorShopping : MonoBehaviour , IInteractable
{
    [SerializeField]private CanvasRenderer _armorPanel;

    public void OnInteract(GameObject caller)
    {
        UIManager.Instance.OpenPanel(_armorPanel);
    }
}

