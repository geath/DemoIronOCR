using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoIronOcr
{
    public enum ErrorLogCodeNo
    {
        PageDescrepancy,
        ConvertImageFailed,
        SplitImageFailed,
        OCRFailed,
        CanNotImportFileInImageCollection,
        SortingArrayFailed,
        MergeFailed
    }
}
