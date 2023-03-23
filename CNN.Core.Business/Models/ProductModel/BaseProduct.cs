using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.ProductModel;

public class BaseProduct
{
    public virtual string Name { get; set; } = string.Empty;
    public virtual string CaseSize { get; set; } = string.Empty;

    public BaseProduct(string name, string caseSize)
    {
        Name = name;
        CaseSize = caseSize;
    }

    public BaseProduct()
    {
    }
}
