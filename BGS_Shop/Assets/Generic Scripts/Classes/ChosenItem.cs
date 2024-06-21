using UnityEngine;

public class ChosenItem
{
    public int PartID;
    public int ModelID;
    public int EnchantmentID;
    public int Price;

    public ChosenItem(int partID, int modelID, int enchantmentID)
    {
        PartID = partID;
        ModelID = modelID;
        EnchantmentID = enchantmentID;
        CalculateCost(this);
    }

    public void UpdateValues(int partID, int modelID, int enchantmentID)
    {
        PartID = partID;
        ModelID = modelID;
        EnchantmentID = enchantmentID;
        CalculateCost(this);
    }
    private void CalculateCost(ChosenItem item)
    {
        int valueModifier = item.PartID + 1;
        Price = (((item.ModelID * 50) + (item.EnchantmentID * 100)) * valueModifier)/2;
    }
}


