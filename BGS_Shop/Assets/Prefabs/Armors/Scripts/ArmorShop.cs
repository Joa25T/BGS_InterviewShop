using UnityEngine;
using BGS_Shop.UI;

public class ArmorShop : Interactable
{
    [SerializeField]private CanvasRenderer _armorPanel;

    public override void OnInteract(GameObject caller)
    {
        UIManager.Instance.OpenPanel(_armorPanel);
    }
}

