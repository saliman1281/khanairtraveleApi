using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Entities.DealerModel.DealerInfo;

namespace Services.DealerService.DealerInfoService
{
    public interface IDealerInfoService
    {
        Task<List<DealerInfoResponse>> GetAllDealer(string dealerCNIC);
        Task<DealerInfoResponse> GetDealerInfo(int dealerId);
        Task<string> AddDealerInfo(DealerInfoRequest request);
        Task<string> UpdateDealerInfo(DealerInfoRequest request);
    }
}
