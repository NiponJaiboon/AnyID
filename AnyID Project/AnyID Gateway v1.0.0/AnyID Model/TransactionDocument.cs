using System;
using System.Collections.Generic;
using System.Drawing;
using iSabaya;
using System.IO;

namespace AnyIDModel
{
    public class TransactionDocument : PersistentEntity
    {
        public virtual byte[] DocumentContent { get; set; }
        public virtual string DocumentFileName { get; set; }
        public virtual string DocumentFormat { get; set; }
        /// <summary>
        /// member of Configuration.DocumentTypes
        /// </summary>
        public virtual string DocumentType { get; set; }
        public virtual ProxyTransaction Transaction { get; set; }
        public virtual UserAction UploadAction { get; set; }
    }
}
