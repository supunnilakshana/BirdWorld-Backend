using BirdWorld.Config;

namespace BirdWorld.Helpers
{
    public static class AccessHelper
    {

        public const string anyoneAccess = AppUserRolesConst.Admin +"," + AppUserRolesConst.GUser + ","+ AppUserRolesConst.Seller;
        public const string onlyAdminAccess=AppUserRolesConst.Admin;
        public const string sellerAccess = AppUserRolesConst.Admin + "," + AppUserRolesConst.Seller;
        public const string guserAccess = AppUserRolesConst.Admin + "," + AppUserRolesConst.GUser;






    }
}
