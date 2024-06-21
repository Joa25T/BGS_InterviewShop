using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog", fileName = "ScriptableObject/DialogData")]
public class DialogScriptable : ScriptableObject
{
    public List<string> _dialogs;
}
