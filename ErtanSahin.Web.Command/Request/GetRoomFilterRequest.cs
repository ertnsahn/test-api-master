using System.Collections.Generic;
using ErtanSahin.Web.Command.Model;
using MediatR;

namespace ErtanSahin.Web.Command.Request
{
    public class GetRoomFilterRequest : IRequest<List<RoomModel>>
    {

    }
}
