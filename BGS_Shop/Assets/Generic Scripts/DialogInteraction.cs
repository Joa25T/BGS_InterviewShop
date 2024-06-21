using UnityEngine;
using BGS_Shop.UI;

public class DialogInteraction : ShopInteraction
{
    [SerializeField] private AudioSource _audio;
    
    public override void OnInteract(GameObject caller)
    {
        if (!_shopPanel.gameObject.activeSelf)
        {
            UIManager.Instance.OpenPanel(_shopPanel);
            _audio.Play();
        }
    }
}
