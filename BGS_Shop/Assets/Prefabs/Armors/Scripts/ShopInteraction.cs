using UnityEngine;
using BGS_Shop.UI;

public class ShopInteraction : Interactable
{
    [SerializeField]private CanvasRenderer _shopPanel;

    public override void CloseUIPanel()
    {
        UIManager.Instance.ClosePanel(_shopPanel);
    }

    public override void OnInteract(GameObject caller)
    {
        UIManager.Instance.OpenPanel(_shopPanel);
    }
    
}

