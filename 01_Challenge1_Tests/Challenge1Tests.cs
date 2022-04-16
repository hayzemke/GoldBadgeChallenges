using Xunit;
public class Challenge1Tests
{
    [Fact]
    public void AddMenuItem_ShouldNotGetNull()
    {
        MenuItem menuItems = new MenuItem();
        menuItems.Name = "Americano";
        Challenge1_Repo repo = new Challenge1_Repo();

        repo.AddMenuItem(menuItems);
        MenuItem itemsFromDatabase = repo.AddMenuItem("Americano");

        Assert.DoesNotContain(itemsFromDatabase);
    }

    public void SeeAllMenuItems_ShouldReturnAllItems()
    {
        MenuItem menuItems = new MenuItem();


    }


}