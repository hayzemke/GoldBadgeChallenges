using Xunit;
using System;
using Challenge3.Data;

public class Challenge3_RepoTests
{
    private Challenge3_Repo _badgeRepo;
    private Badge badge;

    [Fact]
    public void CreateNewBadge_ShouldReturnTrue()
    {
        _badgeRepo = new Challenge3_Repo();
        // badge = new Badge("A1, A4");
        _badgeRepo.CreateNewBadge(badge);
        Assert.True(_badgeRepo.CreateNewBadge(badge));
    }

    [Fact]
    public void GetBadgeByID_ShouldNotReturnNull()
    {
        var badge = _badgeRepo.GetBadgeByID(1);
        Assert.Equal(badge, _badgeRepo.GetBadgeByID(1));
    }
    [Fact]
    public void SeeAllBadges_ShouldNotReturnNull()
    {
        var badge = _badgeRepo.SeeAllBadges().Count;
        Assert.Equal(badge, _badgeRepo.SeeAllBadges().Count);
    }

    [Fact]
    public void UpdateExistingBadge_ShouldReturnTrue()
    {
        // var badge = 1;
        // var newBadgeInfo = "2";
        // Assert.True(_badgeRepo.UpdateExistingBadge(1, newBadgeInfo));

    }
    [Fact]
    public void AddDoor_ShouldReturnTrue()
    {
        var door = "1";
        string doorNumber = "A3";
        Assert.True(_badgeRepo.AddDoor(1, doorNumber));


    }
    [Fact]
    public void RemoveDoor_ShouldReturnTrue()
    {
        var door = "1";
        string doorNumber = "A3";
        Assert.True(_badgeRepo.RemoveDoor(1, doorNumber));
    }

}

