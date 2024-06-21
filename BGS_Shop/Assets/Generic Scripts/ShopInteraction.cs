using UnityEngine;
using BGS_Shop.UI;

public class ShopInteraction : Interactable
{
    [SerializeField]protected CanvasRenderer _shopPanel;

    public override void CloseUIPanel()
    {
        if (_shopPanel.gameObject.activeSelf)
        {
            UIManager.Instance.ClosePanel(_shopPanel);
        }
    }

    public override void OnInteract(GameObject caller)
    {
        if (!_shopPanel.gameObject.activeSelf)
        {
            UIManager.Instance.OpenPanel(_shopPanel);
        }
    }
}

