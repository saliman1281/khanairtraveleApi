using DBCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Entities.TicketModel.Ticket;

namespace Services.TicketService.TicketInfoService
{
    public class TicketInfoService: ITicketInfoService
    {
        private readonly IDBConnection _dbConnectionLogic;
        private readonly IListConverter _listConverter;
        public TicketInfoService(IDBConnection dbConnectionLogic, IListConverter listConverter)
        {
            _dbConnectionLogic = dbConnectionLogic;
            _listConverter = listConverter;
        }

        public async Task<string> AddticketInfo(TicketInfoRequest ticketInfoRequest)
        {
            string response = "";

            string spName = @"SP_AddticketInfo";

            Hashtable Param = new Hashtable
                {
                    { "@customerId", ticketInfoRequest.customerId },
                    { "@customerCNIC", ticketInfoRequest.customerCNIC },
                    { "@ticketNumber", ticketInfoRequest.ticketNumber },
                    { "@ticketPNR", ticketInfoRequest.ticketPNR },
                    { "@airlineType", ticketInfoRequest.airlineType },
                    { "@fromLocation", ticketInfoRequest.fromLocation },
                    { "@toLocation", ticketInfoRequest.toLocation },
                    { "@bookingDate", ticketInfoRequest.bookingDate },
                    { "@ticketCost", ticketInfoRequest.ticketCost },
                    { "@ticketRetail", ticketInfoRequest.ticketRetail },
                    { "@ticketType", ticketInfoRequest.ticketType },
                    { "@returnFrom", ticketInfoRequest.returnFrom },
                    { "@returnTo", ticketInfoRequest.returnTo },
                    { "@returnDate", ticketInfoRequest.returnDate },
                    { "@passportImage", ticketInfoRequest.passportImage },
                    { "@modifiedBy", ticketInfoRequest.modifiedBy!=null?ticketInfoRequest.modifiedBy:"" }
                };
             
            //if (ticketInfoRequest.returnDate != null && ticketInfoRequest.returnDate != "")
            //    Param.Add("@returnDate", ticketInfoRequest.returnDate);
            //else
            //    Param.Add("@returnDate", DBNull.Value);

            string dataTable = await _dbConnectionLogic.IUD(spName, Param);

            if (dataTable != null)
            {
                response = dataTable;
            }
            return response;
        }

        public async Task<List<TicketInfoResponse>> GetAllTicketOfCustomer(string customerCNIC)
        {
            List<TicketInfoResponse> response = new List<TicketInfoResponse>();

            string spName = @"SP_GetAllTicketOfCustomer";

            Hashtable Param = new Hashtable
                {
                    { "@customerCNIC", customerCNIC },
                };

            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.ConvertDataTable<TicketInfoResponse>(dataTable);
            }

            return response;
        }

        public async Task<TicketInfoResponse> GetTicketInfo(string ticketNmbr)
        {
            TicketInfoResponse response = new TicketInfoResponse();

            string spName = @"SP_GetTicketInfo";

            Hashtable Param = new Hashtable
                {
                    { "@ticketNum", ticketNmbr },
                };

            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.GetItem1<TicketInfoResponse>(dataTable.Rows[0]);
            }

            return response;
        }
    }
}
