using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace JogiQueueTrack
{
    public partial class _Default : Page
    {

#pragma warning disable CS0169 // The field '_Default.t' is never used
        Thread t;
#pragma warning restore CS0169 // The field '_Default.t' is never used

        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueueData();
        }

        protected void gvQueueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void GetQueueData()
        {

            //string conStr = "Data Source= 192.168.29.254, 56121;Integrated Security = false; Initial Catalo=dbSHM_JAH; uid=sa; pwd=Ss.d@2017;";
            //string conStr = @"Data Source=192.168.29.254,56121; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
            //string conStr = @"Data Source=192.168.29.254,1433; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
            //string conStr = @"Data Source=192.168.29.254,1433; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
            //string conStr = @"Data Source=115.246.21.234,1433; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
            string conStr = @"Data Source=115.246.21.234,1433; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
            string sql_query = "";

            //sql_query = "select *, '' as ApproxTime from "
            //          + "(select View_Appointment.ADtmFrom As AppointmentDate, View_Appointment.AFrom, View_Appointment.ATo, View_Appointment.LedgerName, "
            //          + " View_Appointment.ANumber AS QueueNo, View_Appointment.Remark As DocName, View_Appointment.[Status],  "
            //          + " View_Registration.DDInTime, CAST(DATEADD(MINUTE, 8, View_Registration.DDInTime) as time) as ApproxTime   "
            //          + " from View_Appointment "
            //          + " left join View_Registration on View_Appointment.AId = View_Registration.AId "
            //          + " where CAST(View_Appointment.ADtmFrom as date) between '04/18/2024' and '04/18/2024' and "
            //          + " View_Appointment.Remark in('DR. DEVANGI JOGAL') "
            //          + " union all "
            //          + " select ATime1, ATime AS AFrom, '' as ATo, '' As LedgerName, QNo as QueueNo, MiscName As DocName, '' as [Status], '' DDInTime, '' as ApproxTime "
            //          + " from tbl_TimeWiseQueueNumber   "
            //          + " left join tbl_MiscMasterNew on tbl_TimeWiseQueueNumber.DoctorName = tbl_MiscMasterNew.MiscId "
            //          + " where QNo not in (select ANumber from View_Appointment where CAST(ADtmFrom AS date) between '04/19/2024' and '04/19/2024' ) "
            //          + " and CAST(ATime1 as Date) between '04/19/2024' and '04/19/2024' and  tbl_MiscMasterNew.MiscName in('DR. DEVANGI JOGAL')  ) As tblTmp "
            //          + " order by QueueNo ";


            sql_query = "select *, '' as ApproxTime from "
                      + "(select View_Appointment.ADtmFrom As AppointmentDate, View_Appointment.AFrom, View_Appointment.ATo, View_Appointment.LedgerName, "
                      + " View_Appointment.ANumber AS QueueNo, View_Appointment.Remark As DocName, View_Appointment.[Status],  "
                      + " View_Registration.DDInTime, CAST(DATEADD(MINUTE, 8, View_Registration.DDInTime) as time) as ApproxTime   "
                      + " from View_Appointment "
                      + " left join View_Registration on View_Appointment.AId = View_Registration.AId "
                      + " where CAST(View_Appointment.ADtmFrom as date) between '" + DateTime.Now.ToString("MM/dd/yyyy") + "' and '" + DateTime.Now.ToString("MM/dd/yyyy") + "' and "
                      + " View_Appointment.Remark in('DR. DEVANGI JOGAL') "
                      + " union all "
                      + " select ATime1, ATime AS AFrom, '' as ATo, '' As LedgerName, QNo as QueueNo, MiscName As DocName, '' as [Status], '' DDInTime, '' as ApproxTime "
                      + " from tbl_TimeWiseQueueNumber   "
                      + " left join tbl_MiscMasterNew on tbl_TimeWiseQueueNumber.DoctorName = tbl_MiscMasterNew.MiscId "
                      + " where QNo not in (select ANumber from View_Appointment where CAST(ADtmFrom AS date) between '" + DateTime.Now.ToString("MM/dd/yyyy") + "' and '" + DateTime.Now.ToString("MM/dd/yyyy") + "' ) "
                      + " and CAST(ATime1 as Date) between '" + DateTime.Now.ToString("MM/dd/yyyy") + "' and '" + DateTime.Now.ToString("MM/dd/yyyy") + "' and  tbl_MiscMasterNew.MiscName in('DR. DEVANGI JOGAL')  ) As tblTmp "
                      + " order by QueueNo ";

            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sql_query, con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvQueueList.DataSource = dt;
            gvQueueList.DataBind();

        }

    }
}