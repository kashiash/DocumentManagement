
    using System;
    using DevExpress.Xpo;
    using DevExpress.Persistent.Base;
    using DevExpress.Persistent.BaseImpl;

    namespace DocumentManagement.Module.BusinessObjects
    {
        [DefaultClassOptions]
        public class Document : FileAttachmentBase
        {
            public Document(Session session) : base(session) { }

            private string title;
            [Size(200)]
            public string Title
            {
                get { return title; }
                set { SetPropertyValue(nameof(Title), ref title, value); }
            }

            private DateTime creationDate;
            public DateTime CreationDate
            {
                get { return creationDate; }
                set { SetPropertyValue(nameof(CreationDate), ref creationDate, value); }
            }

            private DateTime lastModifiedDate;
            public DateTime LastModifiedDate
            {
                get { return lastModifiedDate; }
                set { SetPropertyValue(nameof(LastModifiedDate), ref lastModifiedDate, value); }
            }

            private Category category;
            [Association("Category-Documents")]
            public Category Category
            {
                get { return category; }
                set { SetPropertyValue(nameof(Category), ref category, value); }
            }

            private Subcategory subcategory;
            [Association("Subcategory-Documents")]
            public Subcategory Subcategory
            {
                get { return subcategory; }
                set { SetPropertyValue(nameof(Subcategory), ref subcategory, value); }
            }

            public override void AfterConstruction()
            {
                base.AfterConstruction();
                CreationDate = DateTime.UtcNow;
                LastModifiedDate = DateTime.UtcNow;
            }


        [Size(SizeAttribute.Unlimited), Delayed(true)]
        [ImageEditor]
        public byte[] Image
        {
            get => GetDelayedPropertyValue<byte[]>(nameof(Image));
            set => SetDelayedPropertyValue(nameof(Image), value);
        }
    }

    }


