using RefereeApp.Entities.Enums;

namespace RefereeApp.Entities;

public class Fixture : Base
{
    public int Id { get; set; }
    public string HomeTeam { get; set; }
    public string AwayTeam { get; set; }
    public DateTime MatchTime { get; set; }
    public Difficulty DifficultyId { get; set; }
    public bool IsDerby { get; set; }
    public int RefereeId { get; set; }
    public Referee Referee { get; set; }
    public ICollection<FixtureClub> FixtureClubs { get; set; }
}