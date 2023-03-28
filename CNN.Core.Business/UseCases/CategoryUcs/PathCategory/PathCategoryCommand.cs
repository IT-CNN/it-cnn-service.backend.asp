using CNN.Core.Business.Models.CategoryModel;
using CNN.Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNN.Core.Business.UseCases.CategoryUcs.PathCategory;

public class PathCategoryCommand: IRequest<CategoryOutModel>
{
    public JsonPatchDocument<Category> PatchDocument { get; set; }
    public Guid Id { get; set; }

    public PathCategoryCommand(JsonPatchDocument<Category> patchDocument, Guid id)
    {
        PatchDocument = patchDocument;
        Id = id;
    }
}
