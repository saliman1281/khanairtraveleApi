using DBCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Entities.DealerModel.DealerInfo;

namespace Services.DealerService.DealerInfoService
{
    public class DealerInfoService: IDealerInfoService
    {
        private readonly IDBConnection _dbConnectionLogic;
        private readonly IListConverter _listConverter;
        public DealerInfoService(IDBConnection dbConnectionLogic, IListConverter listConverter)
        {
            _dbConnectionLogic = dbConnectionLogic;
            _listConverter = listConverter;
        }

        public async Task<List<DealerInfoResponse>> GetAllDealer(string dealerCNIC)
        {
            List<DealerInfoResponse> response = new List<DealerInfoResponse>();

            string spName = @"SP_GetAllDealer";
            // var _customerCNIC = Convert.ToInt64(customerCNIC);

            Hashtable Param = new Hashtable
                {
                    { "@dealerCNIC", dealerCNIC },
                };

            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.ConvertDataTable<DealerInfoResponse>(dataTable);
            }

            return response;
        }

        public async Task<DealerInfoResponse> GetDealerInfo(int dealerId)
        {
            DealerInfoResponse response = new DealerInfoResponse();

            string spName = @"SP_GetDealerInfo";
            // var _customerCNIC = Convert.ToInt64(customerCNIC);

            Hashtable Param = new Hashtable
                {
                    { "@Id", dealerId },
                };

            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.GetItem1<DealerInfoResponse>(dataTable.Rows[0]);
            }

            return response;
        }

        public async Task<string> AddDealerInfo(DealerInfoRequest request)
        {
            string response = "";

            string spName = @"SP_AddDealerInfo";

            Hashtable Param = new Hashtable
                {
                    { "@dealerCNIC", request.dealerCNIC },
                    { "@dealerName", request.dealerName },
                    { "@dealerMobile", request.dealerMobile },
                    { "@dealerAddress", request.dealerAddress },
                    { "@modifiedBy", request.modifiedBy!=null?request.modifiedBy:"" },
                };

            string dataTable = await _dbConnectionLogic.IUD(spName, Param);

            if (dataTable != null)
            {
                response = dataTable;
            }

            return response;
        }

        public async Task<string> UpdateDealerInfo(DealerInfoRequest request)
        {
            string response = "";

            string spName = @"SP_UpdateDealerInfo";

            Hashtable Param = new Hashtable
                {
                    { "@dealerId", request.dealerId },
                    { "@dealerCNIC", request.dealerCNIC },
                    { "@dealerName", request.dealerName },
                    { "@dealerMobile", request.dealerMobile },
                    { "@dealerAddress", request.dealerAddress },
                };

            string dataTable = await _dbConnectionLogic.IUD(spName, Param);

            if (dataTable != null)
            {
                response = dataTable;
            }

            return response;
        }
    }
}
