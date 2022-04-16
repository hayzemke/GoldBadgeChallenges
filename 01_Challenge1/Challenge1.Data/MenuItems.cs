public class MenuItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ItemID { get; set; }
    public string Ingredients { get; set; }
    public double Price { get; set; }

    public MenuItem(){}

    public MenuItem(string name, string description, string ingredients, double price)
    {
        Name = name;
        Description = description;
        Ingredients = ingredients;
        Price = price;

    }

}
