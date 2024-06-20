using BGS_Shop.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Interactable : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        UIManager.Instance.OpenInteractPopUp();
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        UIManager.Instance.CloseInteractPopUp();
    }

    public abstract void OnInteract(GameObject caller);
}
