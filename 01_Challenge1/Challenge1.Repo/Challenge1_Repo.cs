public class Challenge1_Repo
{
    private readonly List<MenuItem> _menuDatabase = new List<MenuItem>();
    private int _count = 0;
    //* Create
    public bool AddMenuItem(MenuItem menuItems)
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
    public bool AddMultipleItems(List<MenuItem> items)
    {
        if (items != null)
        {
            foreach (var item in items)
            {
                _count++;
                item.ItemID = _count;
            }
            _menuDatabase.AddRange(items);
            return true;
        }
        return false;
    }
    //* Read
    public List<MenuItem> SeeAllMenuItems()
    {
        return _menuDatabase;
    }
    public MenuItem GetMenuItemByID(int ID)
    {
        foreach (MenuItem menuItems in _menuDatabase)
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
