public class Challenge2_Repo
{
    private readonly Queue<ClaimItem> _claimQueue = new Queue<ClaimItem>();
    private int _count = 0;

    //* Add Claim To Queue
    public bool EnterNewClaim(ClaimItem claimItem)
    {
        if (claimItem != null)
        {
            _count++;
            claimItem.ClaimID = _count;
            _claimQueue.Enqueue(claimItem);
            return true;
        }
        return false;
    }
    //* Take Care of Next Claim(Queue)
    public Queue<ClaimItem> SeeAllClaims()
    {
        return _claimQueue;
    }
    public ClaimItem NextClaim()
    {
        if (_claimQueue.Count >0)
        {
            var claimItem = _claimQueue.Peek();
            return claimItem;
        }
        return null;
    }
    public bool HandleClaim()
    {
        if (_claimQueue.Count >0)
        {
            _claimQueue.Dequeue();
            return true;
        }
        return false;
    }
}
