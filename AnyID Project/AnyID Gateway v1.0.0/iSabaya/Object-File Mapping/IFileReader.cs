using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public interface IFileReader
    {
        String ImportFilePath { get; set; }
        object ReadLine();
        void UndoReadLine();
        void Close();
    }
}
