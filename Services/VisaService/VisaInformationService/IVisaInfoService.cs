using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Entities.VisaModel.VisaInformation;

namespace Services.VisaService.VisaInformationService
{
    public interface IVisaInfoService
    {
        Task<String> AddVisaDetail(VisaInfoRequest visaInfoRequest);
        Task<List<VisaInfoResponse>> GetVisaDetail(VisaInfoRequest visaInfoRequest);
        Task<VisaInfoResponse> GetVisaInfo(string visaNmbr);
    }
}
