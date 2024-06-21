public static class Helpers 
{
    public static int CalculateCost(ChosenItem item)
    {
        int price = (item.ModelID * 50) + (item.EnchantmentID * 100);
        return price;
    }
}
