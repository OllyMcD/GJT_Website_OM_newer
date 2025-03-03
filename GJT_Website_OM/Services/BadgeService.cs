namespace GJT_Website_OM.Services
{
    public class BadgeService
    {
        private string GetBadgeImage(string badgeLevel)
        {
            return badgeLevel.ToLower() switch
            {
                "bronze" => "/images/bronze.png",
                "silver" => "/images/silver.png",
                "gold" => "/images/gold.png",
                "platinum" => "/images/platinum.png",
                "master" => "/images/master.png",
                "allstar" => "/images/allstar.png",
                _ => "/images/default.png" // default image
            };
        }
    }
}
