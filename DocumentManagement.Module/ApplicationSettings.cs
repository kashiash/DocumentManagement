using DevExpress.ExpressApp.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagement.Module
{
    public class ApplicationSettings
    {
        public static string ConnectionString => "Integrated Security=SSPI;Pooling=false;Data Source=.;Initial Catalog=DocumentManagement";
    }
}
