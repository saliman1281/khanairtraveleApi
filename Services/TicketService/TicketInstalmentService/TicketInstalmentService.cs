using DBCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Entities.TicketModel.Ticket;
using static Entities.TicketModel.TicketInstalmentModel.TicketInstalment;

namespace Services.TicketService.TicketInstalmentService
{
    public class TicketInstalmentService: ITicketInstalmentService
    {
        private readonly IDBConnection _dbConnectionLogic;
        private readonly IListConverter _listConverter;
        public TicketInstalmentService(IDBConnection dbConnectionLogic, IListConverter listConverter)
        {
            _dbConnectionLogic = dbConnectionLogic;
            _listConverter = listConverter;
        }

        public async Task<String> AddTicketInstalmentDetail(TicketInstalmentRequest ticketInstalmentRequest)
        {
             string response = "";

            string spName = @"SP_AddTicketIntalmentDetail";

            Hashtable Param = new Hashtable
                {
                    {"@ticketInstalmentId", ticketInstalmentRequest.ticketInstalmentId},
                    {"@ticketNumber", ticketInstalmentRequest.ticketNumber},
                    {"@ticketInstalmentAmount", ticketInstalmentRequest.ticketInstalmentAmount},
                    { "@modifiedBy", ticketInstalmentRequest.modifiedBy!=null?ticketInstalmentRequest.modifiedBy:"" },
                    {"@option", ticketInstalmentRequest.option},
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

        public async Task<List<TicketInstalmentResponse>> GetTicketInstalmentDetail(TicketInstalmentRequest ticketInstalmentRequest)
        {
           // string response = "";
            List<TicketInstalmentResponse> response = new List<TicketInstalmentResponse>();

            string spName = @"SP_GetTicketIntalmentDetail";

            Hashtable Param = new Hashtable
                {
                    {"@ticketInstalmentId", ticketInstalmentRequest.ticketInstalmentId},
                    {"@ticketNumber", ticketInstalmentRequest.ticketNumber},
                    {"@ticketInstalmentAmount", ticketInstalmentRequest.ticketInstalmentAmount},
                    { "@modifiedBy", ticketInstalmentRequest.modifiedBy!=null?ticketInstalmentRequest.modifiedBy:"" },
                    {"@option", ticketInstalmentRequest.option},
                };

            //if (ticketInfoRequest.returnDate != null && ticketInfoRequest.returnDate != "")
            //    Param.Add("@returnDate", ticketInfoRequest.returnDate);
            //else
            //    Param.Add("@returnDate", DBNull.Value);
           
            DataTable dataTable = await _dbConnectionLogic.SELECT_QUERY(spName, Param);
            //var a = dataTable.Rows[0].ItemArray;
            //var b = a[0].ToString();

            //if (b== "inserted")
            //{
            //    TicketInstalmentResponse abc = new TicketInstalmentResponse();
            //    abc.ticketNumber = b;
            //    response.Add(abc);
            //}
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                response = _listConverter.ConvertDataTable<TicketInstalmentResponse>(dataTable);
            }
            return response; 
        }

     
    }
}
