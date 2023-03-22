using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.Models.ProductModel;

public class BaseProduct
{
    public virtual string Name { get; set; }
    public virtual string CaseSize { get; set; }

    public BaseProduct(string name, string caseSize)
    {
        Name = name;
        CaseSize = caseSize;
    }

    public BaseProduct()
    {
    }
}
