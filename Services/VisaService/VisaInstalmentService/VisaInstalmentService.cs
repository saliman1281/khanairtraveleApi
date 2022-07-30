using DBCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Entities.VisaModel.VisaInstalment;

namespace Services.VisaService.VisaInstalmentService
{
    public class VisaInstalmentService: IVisaInstalmentService
    {
        private readonly IDBConnection _dbConnectionLogic;
        private readonly IListConverter _listConverter;
        public VisaInstalmentService(IDBConnection dbConnectionLogic, IListConverter listConverter)
        {
            _dbConnectionLogic = dbConnectionLogic;
            _listConverter = listConverter;
        }
        public async Task<String> AddVisaInstalment(VisaInstalmentRequest visaInstalmentRequest)
        {
            string response = "";

            string spName = @"SP_SP_AddUpdateDelete_VisaInstalment";

            Hashtable Param = new Hashtable
                {
                    {"@visaInstalmentId",visaInstalmentRequest.visaInstalmentId},
                    {"@visaNumber", visaInstalmentRequest.visaNumber},
                    {"@visaInstalmentAmount", visaInstalmentRequest.visaInstalmentAmount},
                    {"@modifiedBy",visaInstalmentRequest.modifiedBy},
                    {"@option", visaInstalmentRequest.option},
                };
            string dataTable = await _dbConnectionLogic.IUD(spName, Param);

            if (dataTable != null)
            {
                response = dataTable;
            }

            return response;
        }

        public async Task<List<VisaInstalmentResponse>> GetVisaInstalment(VisaInstalmentRequest request)
        {
            // string response = "";
            List<VisaInstalmentResponse> response = new List<VisaInstalmentResponse>();

            string spName = @"SP_GetVisaInstalmentDetail";

            Hashtable Param = new Hashtable
                {
                    {"@visaNumber",request.visaNumber},
                   
                };
            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.ConvertDataTable<VisaInstalmentResponse>(dataTable);
            }
            return response;
        }
    }
}
