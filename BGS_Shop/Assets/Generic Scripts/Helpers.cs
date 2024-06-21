public static class Helpers 
{
    public static int CalculateCost(ChosenItem item)
    {
        int valueModifier = item.PartID + 1;
        int price = (((item.ModelID * 50) + (item.EnchantmentID * 100)) * valueModifier)/2;
        return price;
    }
}
