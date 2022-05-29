using SampleSourceKT.Application.DTO.Requests.Users;
using SampleSourceKT.Application.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSourceKT.Application.ServiceContracts.Users
{
    public interface IUserServices
    {
        Task<ApiResult<string>> Authenticate(LoginRequestDto model);
        Task<ApiResult<bool>> Register(RegisterRequestDto model);
    }
}
