using UnityEngine;

[CreateAssetMenu(menuName = "Enchantment", fileName = "ScriptableObjects/Enchantments")]
public class EnchantmentsScriptable : ScriptableObject
{
    public string EnchantmentName;
    public string Description;
    public Color TintColor;
}
