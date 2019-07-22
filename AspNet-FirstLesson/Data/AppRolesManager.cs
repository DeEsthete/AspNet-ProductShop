
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Web;

namespace AspNet_FirstLesson.Data
{
    public class AppRolesManager : RoleManager<IdentityRole>
    {

        public AppRolesManager(IRoleStore<IdentityRole, string> store) : base(store)
        {
        }

        public static AppRolesManager Create(IdentityFactoryOptions<AppRolesManager> options,
                                            IOwinContext context)
        {
            var db = context.Get<ProductContext>();
            var store = new RoleStore<IdentityRole>(db);
            var manager = new AppRolesManager(store);

            return manager;
        }
    }
}