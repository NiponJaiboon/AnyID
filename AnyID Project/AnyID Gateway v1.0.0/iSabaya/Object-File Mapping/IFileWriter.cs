using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public interface IFileWriter
    {
        string ExportFilePath { get; set; }
        int CurrentRowNo { get; set; }
        void ClearLineBuffer();
        void Append(object value);
        object WriteLine();
        void Close();
    }
}
