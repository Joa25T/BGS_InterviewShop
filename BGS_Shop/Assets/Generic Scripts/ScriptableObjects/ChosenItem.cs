using UnityEngine;

public class ChosenItem
{
    public int bodyPiece;
    public int ModelID;
    public int EnchantmentID;

    public ChosenItem(int modelID, int enchantmentID)
    {
        ModelID = modelID;
        EnchantmentID = enchantmentID;
    }
}


