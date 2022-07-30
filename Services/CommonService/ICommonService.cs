using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Entities.CommonModel.CommonModel;

namespace Services.CommonService
{
    public interface ICommonService
    {
        Task<List<DealerDataResponse>> GetCommonData(string custId);
        Task<List<RepresentativeResponse>> GetRepresentativeList(int dealerId);
        Task<string> AddRefInfo(RepresentativeRequest request);
        Task<string> AddAirLine(AirLineRequest request);
        Task<List<AirLineResponse>> GetAirLineList();
        Task<string> AddTicketType(TicketTypeRequest request);
        Task<List<TicketTypeResponse>> GetTicketTypeList();
        Task<string> AddVisaType(VisaTypeRequest request);
        Task<List<VisaTypeResponse>> GetVisaTypeList();
        Task<string> CreateDBBackUp();
    }
}
