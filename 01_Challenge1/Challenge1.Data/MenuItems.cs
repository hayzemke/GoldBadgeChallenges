public class MenuItems
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ItemID { get; set; }
    public string Ingredients { get; set; }
    public double Price { get; set; }

    public MenuItems(string name, string description, string ingredients, double price)
    {
        name = Name;
        description = Description;
        ingredients = Ingredients;
        price = Price;

    }

}
