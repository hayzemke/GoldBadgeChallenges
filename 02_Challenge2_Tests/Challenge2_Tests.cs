using System;
using Xunit;

public class Challenge2_Tests
{
    private Challenge2_Repo _Repo;
    private ClaimItem claimItem;

    public Challenge2_Tests()
    {
        _Repo = new Challenge2_Repo();
        claimItem = new ClaimItem(Challenge2.Data.ClaimType.Car, "???", 600d,new DateTime(2022,02,24), new DateTime(2022,02,02), false);
        _Repo.EnterNewClaim(claimItem);
    }
    [Fact]
    public void AddClaimToQueue_ShouldReturnTrue()
    {
        Assert.True(_Repo.EnterNewClaim(claimItem));
    }
    [Fact]
    public void SeeAllClaims()
    {
        var itemsCount = 1;
        Assert.Equal(itemsCount, _Repo.SeeAllClaims().Count);
    }
    [Fact]
    public void NextClaim()
    {
        Assert.Equal(claimItem, _Repo.NextClaim());
    }
    [Fact]
    public void HandleClaim()
    {
        Assert.True(_Repo.HandleClaim());
    }
}