using Tree.Domain.Models;

namespace Tree.Application.Models;
public class BaseResponse<TBase> where TBase : Base {
    public Guid Id { get; }

    public BaseResponse(TBase model) {
        Id = model.Id;
    }
}
