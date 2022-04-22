using System.Collections.Generic;
using Xunit;
public class Challenge1Tests
{
    private Challenge1_Repo _Repo;
    private MenuItem menuItem;

    public Challenge1Tests()
    {
        _Repo = new Challenge1_Repo();
        menuItem = new MenuItem("??", "???", "????", 1.99d);
        _Repo.AddMenuItem(menuItem);
        var item = new MenuItem("Terrys item", "??", "???", 1_000_000d);
        var item2 = new MenuItem("Hailys item", "??", "???", 1_000_000d);
        var item3 = new MenuItem("Steve item", "??", "???", 1_000_000d);
        var item4 = new MenuItem("Jareds item", "??", "???", 1_000_000d);
        _Repo.AddMultipleItems(new List<MenuItem> { item, item2, item3, item4 });
    }
    [Fact]
    public void GetMenuItemByID()
    {
        var item = _Repo.GetMenuItemByID(3);
        Assert.Equal(item, _Repo.GetMenuItemByID(3));
    }
    [Fact]
    public void AddMenuItem()
    {
        var item = new MenuItem("Terrys item", "??", "???", 1_000_000d);
        Assert.True(_Repo.AddMenuItem(item));
    }
    [Fact]
    public void SeeAllMenuItems()
    {
        var stuff = _Repo.SeeAllMenuItems();
        Assert.Equal(5, _Repo.SeeAllMenuItems().Count);
    }
    [Fact]
    public void RemoveMenuItem()
    {
        var item = _Repo.RemoveMenuItem(3);
        Assert.Equal(3,3);
    }
}