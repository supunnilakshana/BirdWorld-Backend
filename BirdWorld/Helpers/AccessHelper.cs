using BirdWorld.Config;

namespace BirdWorld.Helpers
{
    public static class AccessHelper
    {

        public static string anyoneAccess = AppUserRoles.Admin.ToString()+"," + AppUserRoles.GUser.ToString() + ","+ AppUserRoles.Seller.ToString();
        public  static string onlyAdminAccess=AppUserRoles.Admin.ToString();
        public static string sellerAccess = AppUserRoles.Admin.ToString() + "," + AppUserRoles.Seller.ToString();
        public static string guserAccess = AppUserRoles.Admin.ToString() + "," + AppUserRoles.GUser.ToString();






    }
}
