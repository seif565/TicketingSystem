using MediatR;

namespace TicketingSystem.Application.DTOs.Common
{
    public record PagedRequestDto<TRequestDto>(int PageIndex = 0, int PageSize = 0) : IRequest<TRequestDto>
    {       
    }

    public record RequestBase<T>(T TEntity) : IRequest;    
}
