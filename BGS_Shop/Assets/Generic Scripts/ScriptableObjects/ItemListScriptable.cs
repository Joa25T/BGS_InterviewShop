using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemList", fileName = "ScriptableObjects/ItemList")]
public class ItemListScriptable : ScriptableObject
{
    public List<Sprite> _hoods;
    public List<Sprite> _masks;
    public List<Sprite> _torsos;
    public List<Sprite> _pelvis;
    public List<Sprite> _leftElbows;
    public List<Sprite> _rightElbows;
}
