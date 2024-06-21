using System;
using BGS_Shop.UI;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField] private CanvasRenderer _canvasRenderer;

    [SerializeField] private DialogScriptable _dialogScriptable;
    private int _dialogReference;

    public void OnEnable()
    {
        FirstDialog();
    }

    public void FirstDialog()
    {
        _dialogReference = 0;
        _dialogText.text = _dialogScriptable._dialogs[_dialogReference];
    }
    public void NextDialog()
    {
        _dialogReference++;
        if (_dialogReference > _dialogScriptable._dialogs.Count -1)
        {
            UIManager.Instance.ClosePanel(_canvasRenderer);
            return;
        }
        _dialogText.text = _dialogScriptable._dialogs[_dialogReference];
    }
}
