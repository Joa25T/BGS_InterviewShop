using UnityEngine;
using BGS_Shop.UI;

public class ArmorShopping : Interactable
{
    [SerializeField]private CanvasRenderer _armorPanel;

    public override void OnInteract(GameObject caller)
    {
        UIManager.Instance.OpenPanel(_armorPanel);
    }
}

