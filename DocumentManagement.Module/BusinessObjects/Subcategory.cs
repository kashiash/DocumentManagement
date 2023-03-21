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
    public class Subcategory : BaseObject
    {
        public Subcategory(Session session) : base(session) { }

        private string name;
        [Size(100)]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

        private Category category;
        [Association("Category-Subcategories")]
        public Category Category
        {
            get { return category; }
            set { SetPropertyValue(nameof(Category), ref category, value); }
        }

        [Association("Subcategory-Documents")]
        public XPCollection<Document> Documents => GetCollection<Document>(nameof(Documents));
    }
}
