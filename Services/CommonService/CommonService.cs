using DBCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Entities.CommonModel.CommonModel;

namespace Services.CommonService
{
    public class CommonService: ICommonService
    {
        private readonly IDBConnection _dbConnectionLogic;
        private readonly IListConverter _listConverter;
        public CommonService(IDBConnection dbConnectionLogic, IListConverter listConverter)
        {
            _dbConnectionLogic = dbConnectionLogic;
            _listConverter = listConverter;
        }
        public async Task<List<DealerDataResponse>> GetCommonData(string custId)
        {
            List<DealerDataResponse> response = new List<DealerDataResponse>();
            string spName = @"SP_PopulateDealer";
            Hashtable Param = new Hashtable
                {
                    { "@Id", custId },
                };
            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.ConvertDataTable<DealerDataResponse>(dataTable);
            }
            return response;
        }
        public async Task<List<RepresentativeResponse>> GetRepresentativeList(int dealerId)
        {
            List<RepresentativeResponse> response = new List<RepresentativeResponse>();
            string spName = @"SP_PopulateRepresevtative";
            Hashtable Param = new Hashtable
                {
                    { "@Id", dealerId },
                };
            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.ConvertDataTable<RepresentativeResponse>(dataTable);
            }
            return response;
        }
        public async Task<string> AddRefInfo(RepresentativeRequest request)
        {
            string response = "";

            string spName = @"SP_AddRefInfo";

            Hashtable Param = new Hashtable
                {
                    { "@dealerId", request.DealerId },
                    { "@representativeName", request.RepName },
                    { "@representativeMobile", "" },
                    { "@modifiedBy", request.modifiedBy!=null?request.modifiedBy:"" },
                };

            string dataTable = await _dbConnectionLogic.IUD(spName, Param);

            if (dataTable != null)
            {
                response = dataTable;
            }

            return response;
        }
        public async Task<string> AddAirLine(AirLineRequest request)
        {
            string response = "";

            string spName = @"SP_AddAirLineInfo";

            Hashtable Param = new Hashtable
                {
                    { "@AirLineFullName", request.AirLineFullName },
                    { "@AirLineABR", request.AirLineABR },
                    { "@modifiedBy", request.modifiedBy!=null?request.modifiedBy:"" },
                };

            string dataTable = await _dbConnectionLogic.IUD(spName, Param);

            if (dataTable != null)
            {
                response = dataTable;
            }

            return response;
        }
        public async Task<List<AirLineResponse>> GetAirLineList()
        {
            List<AirLineResponse> response = new List<AirLineResponse>();
            string spName = @"SP_PopulateAirLineList";
            Hashtable Param = new Hashtable();
            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.ConvertDataTable<AirLineResponse>(dataTable);
            }
            return response;
        }
        public async Task<string> AddTicketType(TicketTypeRequest request)
        {
            string response = "";

            string spName = @"SP_AddTicketTypeInfo";

            Hashtable Param = new Hashtable
                {
                    { "@TicketTypeName", request.TicketTypeName },
                    { "@modifiedBy", request.modifiedBy!=null?request.modifiedBy:"" },
                };

            string dataTable = await _dbConnectionLogic.IUD(spName, Param);

            if (dataTable != null)
            {
                response = dataTable;
            }

            return response;
        }
        public async Task<List<TicketTypeResponse>> GetTicketTypeList()
        {
            List<TicketTypeResponse> response = new List<TicketTypeResponse>();
            string spName = @"SP_PopulateTicketTypeList";
            Hashtable Param = new Hashtable();
            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.ConvertDataTable<TicketTypeResponse>(dataTable);
            }
            return response;
        }
        public async Task<string> AddVisaType(VisaTypeRequest request)
        {
            string response = "";

            string spName = @"SP_AddVisaTypeInfo";

            Hashtable Param = new Hashtable
                {
                    { "@VisaTypeName", request.VisaTypeName },
                    { "@modifiedBy", request.modifiedBy!=null?request.modifiedBy:"" },
                };

            string dataTable = await _dbConnectionLogic.IUD(spName, Param);

            if (dataTable != null)
            {
                response = dataTable;
            }

            return response;
        }
        // GetVisaTypeList
        public async Task<List<VisaTypeResponse>> GetVisaTypeList()
        {
            List<VisaTypeResponse> response = new List<VisaTypeResponse>();
            string spName = @"SP_PopulateVisaTypeList";
            Hashtable Param = new Hashtable();
            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.ConvertDataTable<VisaTypeResponse>(dataTable);
            }
            return response;
        }

        public async Task<string> CreateDBBackUp()
        {

            string response = await _dbConnectionLogic.CreateBackupDB();

            return response;
        }
    }
}
