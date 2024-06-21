using UnityEngine;

public class ChosenItem
{
    public int PartID;
    public int ModelID;
    public int EnchantmentID;

    public ChosenItem(int partID, int modelID, int enchantmentID)
    {
        PartID = partID;
        ModelID = modelID;
        EnchantmentID = enchantmentID;
    }

    public void UpdateValues(int partID, int modelID, int enchantmentID)
    {
        PartID = partID;
        ModelID = modelID;
        EnchantmentID = enchantmentID;
    }
}


