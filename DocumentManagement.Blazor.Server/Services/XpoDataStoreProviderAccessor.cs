using System;
using DevExpress.ExpressApp.Xpo;

namespace DocumentManagement.Blazor.Server.Services {
    public class XpoDataStoreProviderAccessor {
        public IXpoDataStoreProvider DataStoreProvider { get; set; }
    }
}
