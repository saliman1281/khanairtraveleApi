using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Entities.VisaModel.VisaInstalment;

namespace Services.VisaService.VisaInstalmentService
{
    public interface IVisaInstalmentService
    {
        Task<String> AddVisaInstalment(VisaInstalmentRequest visaInstalmentRequest);
        Task<List<VisaInstalmentResponse>> GetVisaInstalment(VisaInstalmentRequest request);
    }
}
