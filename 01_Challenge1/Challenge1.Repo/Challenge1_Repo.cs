public class Challenge1_Repo
{
    private readonly List<MenuItems> _menuDatabase = new List<MenuItems>();
    private int _count = 0;
    //* Create
    public bool AddMenuItem(MenuItems menuItems)
    {
        if (menuItems != null)
        {
            _count++;
            menuItems.ItemID = _count;
            _menuDatabase.Add(menuItems);
            return true;
        }
        else
        {
            return false;
        }
    }
    //* Read
    public List<MenuItems> SeeAllMenuItems()
    {
        return _menuDatabase;
    }
    public MenuItems GetMenuItemByID(int ID)
    {
        foreach (MenuItems menuItems in _menuDatabase)
        {
            if (menuItems.ItemID==ID)
            {
                return menuItems;
            }
        }
        return null;
    }
    //* Delete
    public bool RemoveMenuItem(int ID)
    {
        var menuItems = GetMenuItemByID(ID);
        if (menuItems != null)
        {
            _menuDatabase.Remove(menuItems);
            return true;
        }
        else
        {
            return false;
        }
    }
}
