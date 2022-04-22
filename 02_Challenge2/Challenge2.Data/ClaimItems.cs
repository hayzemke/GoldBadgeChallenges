using Challenge2.Data;

public class ClaimItem
{
    public int ClaimID { get; set; }
    public ClaimType ClaimType { get; set; }
    public string Description { get; set; }
    public double ClaimAmount { get; set; }
    public DateTime DateOfIncident { get; set; }
    public DateTime DateOfClaim { get; set; }
    public bool IsValid { get; set; }

    public ClaimItem() { }

    public ClaimItem(ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
    {
        ClaimType = claimType;
        Description = description;
        ClaimAmount = claimAmount;
        DateOfIncident = dateOfIncident;
        DateOfClaim = dateOfClaim;
        IsValid = isValid;
    }
}
