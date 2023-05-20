using System.Security.AccessControl;
using System.Security.Permissions;

namespace VerdonSale.Seeders
{
    public class StaticFileSeeder
    {
        [SecurityPermission(SecurityAction.Demand, ControlThread = true)]
        public void SeedFolder()
        {
            try
            {
                //configure access control
                var folderName = Path.Combine("wwwroot", "StaticFiles");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if(!Directory.Exists(pathToSave))
                {
                    var dir = Directory.CreateDirectory(pathToSave);
                    DirectorySecurity dirSec = dir.GetAccessControl();
                    dirSec.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.Write, AccessControlType.Allow));

                    dirSec.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow));
                    dirSec.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.CreateFiles, AccessControlType.Allow));
                    dir.SetAccessControl(dirSec);
                }
              
                //configure permission
                FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.AllAccess, pathToSave);
                permission.Demand();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
