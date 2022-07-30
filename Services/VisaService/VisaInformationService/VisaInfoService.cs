using DBCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Entities.VisaModel.VisaInformation;

namespace Services.VisaService.VisaInformationService
{
    public class VisaInfoService: IVisaInfoService
    {
        private readonly IDBConnection _dbConnectionLogic;
        private readonly IListConverter _listConverter;
        public VisaInfoService(IDBConnection dbConnectionLogic, IListConverter listConverter)
        {
            _dbConnectionLogic = dbConnectionLogic;
            _listConverter = listConverter;
        }
        public async Task<String> AddVisaDetail(VisaInfoRequest visaInfoRequest)
        {
            string response = "";

            string spName = @"SP_AddUpdateDelete_VisaInformation";

            Hashtable Param = new Hashtable
                {
                    {"@visaNumber",visaInfoRequest.visaNumber},
                    {"@customerCnic", visaInfoRequest.customerCnic},
                    {"@dealerId", visaInfoRequest.dealerId},
                    {"@representId", visaInfoRequest.representId},
                    {"@visaTypeId", visaInfoRequest.visaTypeId},
                    {"@visaCountry", visaInfoRequest.visaCountry},
                    {"@visaCostPrice", visaInfoRequest.visaCostPrice},
                    {"@visaRetailPrice", visaInfoRequest.visaRetailPrice},
                    {"@visaPaidAmount",visaInfoRequest.visaPaidAmount},
                    {"@modifiedBy",visaInfoRequest.modifiedBy},
                    {"@option", visaInfoRequest.option},
                };
            string dataTable = await _dbConnectionLogic.IUD(spName, Param);

            if (dataTable != null)
            {
                response = dataTable;
            }

            return response;
        }

        public async Task<List<VisaInfoResponse>> GetVisaDetail(VisaInfoRequest visaInfoRequest)
        {
            // string response = "";
            List<VisaInfoResponse> response = new List<VisaInfoResponse>();

            string spName = @"SP_GetVisaDetail";

            Hashtable Param = new Hashtable
                {
                    {"@visaNumber",visaInfoRequest.visaNumber},
                    {"@customerCnic", visaInfoRequest.customerCnic},
                    {"@visaTypeId", visaInfoRequest.visaTypeId},
                    {"@visaCountry", visaInfoRequest.visaCountry},
                    {"@visaCostPrice", visaInfoRequest.visaCostPrice},
                    {"@visaRetailPrice", visaInfoRequest.visaRetailPrice},
                    {"@visaPaidAmount",visaInfoRequest.visaPaidAmount},
                    {"@modifiedBy",visaInfoRequest.modifiedBy},
                    {"@option", visaInfoRequest.option},
                };
            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.ConvertDataTable<VisaInfoResponse>(dataTable);
            }
            return response;
        }
        public async Task<VisaInfoResponse> GetVisaInfo(string visaNmbr)
        {
            VisaInfoResponse response = new VisaInfoResponse();

            string spName = @"SP_GetVisaInfo";
            // var _customerCNIC = Convert.ToInt64(customerCNIC);

            Hashtable Param = new Hashtable
                {
                    { "@visaNumber", visaNmbr },
                };

            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.GetItem1<VisaInfoResponse>(dataTable.Rows[0]);
            }

            return response;
        }

    }
}
