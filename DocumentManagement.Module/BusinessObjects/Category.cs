using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagement.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Category : BaseObject
    {
        public Category(Session session) : base(session) { }

        private string name;
        [Size(100)]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

        [Association("Category-Subcategories")]
        public XPCollection<Subcategory> Subcategories => GetCollection<Subcategory>(nameof(Subcategories));

        [Association("Category-Documents")]
        public XPCollection<Document> Documents => GetCollection<Document>(nameof(Documents));
    }
}
