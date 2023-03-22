namespace CNN.Core.Business.Models;

public interface IBaseOutModel
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsActive { get; set; }
}
