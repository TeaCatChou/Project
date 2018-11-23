using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Project.Models
{
    public class ProjectDataContext
    {
        
        public static bool memberLogin(Members members)
        {
            ProjectEntities db = new ProjectEntities();
            var q = db.Members.Where(n => n.MemberID == members.MemberID).Count();
            return q == 1;
        }
    }
}