using Challenge3.Data;
public class Challenge3_Repo
{
    //* Dictionary of badges
    private readonly Dictionary<int, Badge> _badgeDatabase = new Dictionary<int, Badge>();
    private int _count = 0;

    //* key for dictionary - badgeID
    //* value for dictionary - DoorNames
    public bool CreateNewBadge(Badge badge)
    {
        if (badge == null)
        {
            return false;
        }
        _count++;
        badge.ID = _count;
        _badgeDatabase.Add(badge.ID, badge);
        return true;
    }
    public Badge GetBadgeByID(int userKeyInput)
    {
        foreach (KeyValuePair<int, Badge> badge in _badgeDatabase)
        {
            if (badge.Key == userKeyInput)
            {
                return badge.Value;
            }
        }
        return null;
    }
    public Dictionary<int, Badge> SeeAllBadges()
    {
        return _badgeDatabase;
    }
    public bool UpdateExistingBadge(int userKeyInput, Badge newBadgeInfo)
    {
        var oldBadgeData = GetBadgeByID(userKeyInput);
        if (oldBadgeData != null)
        {
            oldBadgeData.ID = newBadgeInfo.ID;
            oldBadgeData.Doors = newBadgeInfo.Doors;
            return true;
        }
        return false;
    }
    public bool AddDoor(int ID, string doorNumber)
    {
        var badge = GetBadgeByID(ID);
        if (badge == null)
        {
            return false;
        }
        else
        {
            badge.Doors.Add(doorNumber);
            return true;
        }
    }
    public bool RemoveDoor(int ID, string doorNumber)
    {
        var badge = GetBadgeByID(ID);
        if (badge == null)
        {
            return false;
        }
        foreach (var door in badge.Doors)
        {
            if (door == doorNumber)
            {
                badge.Doors.Remove(door);
                return true;
            }
        }
        return false;
    }
}