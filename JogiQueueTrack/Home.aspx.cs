using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace JogiQueueTrack
{
    public partial class Home : System.Web.UI.Page
    {
        public void GetQueueData(string param_dates, string ledgerId)
        
        {

            try
            {
                //string conStr = "Data Source= 192.168.29.254, 56121;Integrated Security = false; Initial Catalo=dbSHM_JAH; uid=sa; pwd=Ss.d@2017;";
                //string conStr = @"Data Source=192.168.29.254,56121; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
                //string conStr = @"Data Source=192.168.29.254,1433; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
                //string conStr = @"Data Source=115.246.21.234,1433; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
                string conStr = @"Data Source=192.168.29.254,1433; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
                //string conStr = @"Data Source=192.168.29.236,1433; Integrated Security=false;Initial Catalog=dbSHM_JAH_latest;uid=sa; Password=jah@2024;";
                string sql_query = "";


                //////sql_query = "SELECT   dbo.tbl_Registration.QueueNo, tbl_LedgerMaster.LedgerName, "
                //////          + " ISNULL(dbo.tbl_Registration.DoctorId, 0) AS DoctorId, ISNULL(dbo.tbl_UserMaster.UserName, '') AS UserName, '' as AproxTime, tbl_AppointmentMaster.ADtmFrom, tbl_AppointmentMaster.Remark "
                //////          + " FROM dbo.tbl_Registration INNER JOIN "
                //////          + " dbo.tbl_LedgerMaster ON dbo.tbl_Registration.LedgerId = dbo.tbl_LedgerMaster.LedgerId  "
                //////          + " LEFT OUTER JOIN dbo.tbl_UserMaster ON dbo.tbl_Registration.DoctorId = dbo.tbl_UserMaster.UserId "
                //////          + " left join tbl_AppointmentMaster ON tbl_Registration.AId = tbl_AppointmentMaster.AId "
                //////          + " where cast(tbl_Registration.EntryDtm As Date) = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and DDExitTime is null and QueueNo > 0 order by QueueNo ";

                string tmpdate = param_dates;

                /* 01072024
                 * 
                 * 
                 * if (DateTime.Now.ToString("yyyy-MM-dd") != Convert.ToDateTime(param_dates).ToString("yyyy-MM-dd"))
                {
                    Expired.Visible = true;
                    lblPatientName.Visible = false;
                    lblQueueNo.Visible = false;
                    lblAppoTime.Visible = false;
                    lblAprroxTime.Visible = false;
                    lblCurrentQueue.Visible = false;
                    lblCurrentQueue1.Visible = false;

                    return;
                }
                 * 
                 */

                //Sone Mahesh
                //////sql_query = "SELECT   dbo.tbl_Registration.QueueNo, tbl_LedgerMaster.LedgerName, "
                //////          + " ISNULL(dbo.tbl_Registration.DoctorId, 0) AS DoctorId, ISNULL(dbo.tbl_UserMaster.UserName, '') AS UserName, '' as AproxTime, tbl_AppointmentMaster.ADtmFrom, tbl_AppointmentMaster.Remark, tbl_Registration.DDExitTime "
                //////          + " FROM dbo.tbl_Registration INNER JOIN "
                //////          + " dbo.tbl_LedgerMaster ON dbo.tbl_Registration.LedgerId = dbo.tbl_LedgerMaster.LedgerId  "
                //////          + " LEFT OUTER JOIN dbo.tbl_UserMaster ON dbo.tbl_Registration.DoctorId = dbo.tbl_UserMaster.UserId "
                //////          + " left join tbl_AppointmentMaster ON tbl_Registration.AId = tbl_AppointmentMaster.AId "
                //////          + " where cast(tbl_AppointmentMaster.ADtmFrom As Date) = '" + Convert.ToDateTime(param_dates).ToString("yyyy-MM-dd") + "' and "
                //////          + " tbl_LedgerMaster.ledgerId = " + Convert.ToInt32(ledgerId) + " "
                //////          + " and tbl_AppointmentMaster.remark = 'DR. DEVANGI JOGAL' order by QueueNo ";


                sql_query = " SELECT   dbo.tbl_AppointmentMaster .anumber as QueueNo, tbl_LedgerMaster.LedgerName, "
                          + " ISNULL(dbo.tbl_Registration.DoctorId, 0) AS DoctorId, ISNULL(dbo.tbl_UserMaster.UserName, '') AS UserName, '' as AproxTime, tbl_AppointmentMaster.ADtmFrom, tbl_AppointmentMaster.Remark, tbl_Registration.DDExitTime, tbl_Registration.DDInTime, tbl_LedgerMaster.LedgerId "
                          + " FROM dbo.tbl_AppointmentMaster INNER JOIN "
                          + " dbo.tbl_LedgerMaster ON dbo.tbl_AppointmentMaster.LedgerId = dbo.tbl_LedgerMaster.LedgerId  "
                          + " left join tbl_Registration ON tbl_AppointmentMaster.AId = tbl_Registration.AId "
                          + " LEFT OUTER JOIN dbo.tbl_UserMaster ON dbo.tbl_Registration.DoctorId = dbo.tbl_UserMaster.UserId "
                          + " where cast(tbl_AppointmentMaster.ADtmFrom As Date) = '" + Convert.ToDateTime(param_dates).ToString("yyyy-MM-dd") + "' "
                          ////+ " tbl_LedgerMaster.ledgerId = " + Convert.ToInt32(ledgerId) + " "
                          + " and tbl_AppointmentMaster.remark = 'DR. DEVANGI JOGAL' order by cast(tbl_AppointmentMaster.AdtmFrom as time) asc";

                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(sql_query, con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();


                //Current Queue
                sql_query = " select top (3) tbl_AppointmentMaster.Anumber as QueueNo, tbl_Registration.DDinTime "
                          + " FROM dbo.tbl_AppointmentMaster "
                          + " INNER JOIN  dbo.tbl_LedgerMaster ON dbo.tbl_AppointmentMaster.LedgerId = dbo.tbl_LedgerMaster.LedgerId  "
                          + " left join tbl_Registration ON tbl_AppointmentMaster.AId = tbl_Registration.AId  "
                          + " LEFT OUTER JOIN dbo.tbl_UserMaster ON dbo.tbl_Registration.DoctorId = dbo.tbl_UserMaster.UserId "
                          + " where cast(tbl_AppointmentMaster.ADtmFrom As Date) = '" + Convert.ToDateTime(param_dates).ToString("yyyy-MM-dd") + "'  and tbl_AppointmentMaster.remark = 'DR. DEVANGI JOGAL' "
                          + " order by row_number() over(order by tbl_Registration.DdinTime desc)";
                //+ " tbl_LedgerMaster.ledgerId = " + Convert.ToInt32(ledgerId) + " "
                //+ " and tbl_AppointmentMaster.remark = 'DR. DEVANGI JOGAL' order by cast(tbl_AppointmentMaster.AdtmFrom as time) asc";

                con = new SqlConnection(conStr);
                cmd = new SqlCommand(sql_query, con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                }
                da = new SqlDataAdapter(cmd);
                DataTable dtCurrentQueue = new DataTable();
                da.Fill(dtCurrentQueue);

                con.Close();


                DataRow drPetient;
                DateTime startDtm;
                if (dt.Rows.Count > 0)
                {
                    drPetient = dt.Select("LedgerId = " + Convert.ToInt64(ledgerId.ToString())).FirstOrDefault();
                    int queueNo = Convert.ToInt32(drPetient["QueueNo"]);
                    int cntPatient = 0;

                Label:
                    foreach (DataRow dr in  dt.Rows)
                    {

                        if (dr["DDInTime"] != null && queueNo > Convert.ToInt32(dr["QueueNo"]))
                        {
                            dr.Delete();
                            dt.AcceptChanges();
                            goto Label;
                        }
                        else
                        {
                            cntPatient += 1;
                        }

                    }

                    lblRemainToken.Text += Convert.ToString(cntPatient);
                    /*
                    if (dt.Rows[0]["ADtmFrom"] != DBNull.Value)
                    {
                        startDtm = Convert.ToDateTime(dt.Rows[0]["ADtmFrom"]);

                    }
                    else
                    {
                        startDtm = DateTime.Now;
                    }

                    int cntAddMin = 0;
                    Label:
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        dt.Rows[i]["AproxTime"] = Convert.ToString(Convert.ToDateTime(startDtm).AddMinutes(cntAddMin).ToString("hh:mm tt"));

                        //Remove Consulted Patient
                        if (dt.Rows[i]["DDInTime"] != null)
                        {
                            dt.Rows[i].Delete();
                            dt.AcceptChanges();
                            goto Label;
                        }

                        // Add Approx 8 minutes of Avarage Cons. time for Doctor
                        //cntAddMin += 8;
                    }
                    */

                    /* 01072024
                     * 
                     * lblPatientName.Visible = true;
                    lblQueueNo.Visible = true;
                    lblAppoTime.Visible = true;
                    lblAprroxTime.Visible = true;
                    lblCurrentQueue.Visible = true;
                    lblCurrentQueue.Visible = true;

                    drPetient = dt.Select("LedgerId = " + Convert.ToInt64(ledgerId.ToString())).FirstOrDefault();
                    lblPatientName.Text += drPetient["LedgerName"].ToString();
                    lblQueueNo.Text += drPetient["QueueNo"].ToString();
                    lblAppoTime.Text += Convert.ToDateTime(drPetient["ADtmFrom"]).ToString("hh:mm tt");
                    lblAprroxTime.Text += Convert.ToDateTime(drPetient["AproxTime"]).ToString("hh:mm tt");
                     * 
                     */
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    //if (dr["LedgerID"].ToString() = Convert.ToInt32(ledgerId))
                    //    //{

                    //    //}
                    //    ////lblPatientName.Text += dr["LedgerName"].ToString();
                    //    ////lblQueueNo.Text += dr["QueueNo"].ToString();
                    //    ////lblAppoTime.Text += Convert.ToDateTime(dr["ADtmFrom"]).ToString("hh:mm tt");
                    //}

                    string strTest = "";
                    //DataView dataView = new DataView(dtCurrentQueue);
                    //dataView.Sort = "QueueNo ASC";
                    //dtCurrentQueue.Clear();
                    //dtCurrentQueue = dataView.ToTable();

                    /* 01072024
                     * 
                     *  Label1:
                     foreach (DataRow dr in dtCurrentQueue.Rows)
                     {
                         strTest = "";
                         // Remove Consulted Patient
                         if (dr["DDinTime"] != null)
                         {
                             goto Label1;
                         }

                         if (lblCurrentQueue1.Text == strTest)
                         {
                             lblCurrentQueue1.Text += " " + dr["QueueNo"].ToString();
                         }
                         else
                         {
                             lblCurrentQueue1.Text += ", " + dr["QueueNo"].ToString();
                         }
                     }
                     * 
                     */

                }

                //////if (dt.Rows[0]["ADtmFrom"] != DBNull.Value)
                //////{
                //////    startDtm = Convert.ToDateTime(dt.Rows[0]["ADtmFrom"]);

                //////}
                //////else
                //////{
                //////    startDtm = DateTime.Now;
                //////}

                //gvQueue.DataSource = dt;
                //gvQueue.DataBind();

            }
            catch (Exception e)
            {

            }
        }


        public void GetQueueData(string param_dates)
        {

            try
            {
                //string conStr = "Data Source= 192.168.29.254, 56121;Integrated Security = false; Initial Catalo=dbSHM_JAH; uid=sa; pwd=Ss.d@2017;";
                //string conStr = @"Data Source=192.168.29.254,56121; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
                //string conStr = @"Data Source=192.168.29.254,1433; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
                string conStr = @"Data Source=192.168.29.254,1433; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
                //string conStr = @"Data Source=115.246.21.234,1433; Integrated Security=false;Initial Catalog=dbSHM_JAH;uid=sa; Password=Ss.d@2017;";
                string sql_query = "";


                //////sql_query = "SELECT   dbo.tbl_Registration.QueueNo, tbl_LedgerMaster.LedgerName, "
                //////          + " ISNULL(dbo.tbl_Registration.DoctorId, 0) AS DoctorId, ISNULL(dbo.tbl_UserMaster.UserName, '') AS UserName, '' as AproxTime, tbl_AppointmentMaster.ADtmFrom, tbl_AppointmentMaster.Remark "
                //////          + " FROM dbo.tbl_Registration INNER JOIN "
                //////          + " dbo.tbl_LedgerMaster ON dbo.tbl_Registration.LedgerId = dbo.tbl_LedgerMaster.LedgerId  "
                //////          + " LEFT OUTER JOIN dbo.tbl_UserMaster ON dbo.tbl_Registration.DoctorId = dbo.tbl_UserMaster.UserId "
                //////          + " left join tbl_AppointmentMaster ON tbl_Registration.AId = tbl_AppointmentMaster.AId "
                //////          + " where cast(tbl_Registration.EntryDtm As Date) = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and DDExitTime is null and QueueNo > 0 order by QueueNo ";

                string tmpdate = param_dates;

                if (DateTime.Now.ToString("yyyy-MM-dd") != Convert.ToDateTime(param_dates).ToString("yyyy-MM-dd"))
                {
                    Expired.Visible = true;
                    return;
                }


                //Sone Mahesh
                ////sql_query = "SELECT   dbo.tbl_Registration.QueueNo, tbl_LedgerMaster.LedgerName, "
                ////          + " ISNULL(dbo.tbl_Registration.DoctorId, 0) AS DoctorId, ISNULL(dbo.tbl_UserMaster.UserName, '') AS UserName, '' as AproxTime, tbl_AppointmentMaster.ADtmFrom, tbl_AppointmentMaster.Remark, tbl_Registration.DDExitTime "
                ////          + " FROM dbo.tbl_Registration INNER JOIN "
                ////          + " dbo.tbl_LedgerMaster ON dbo.tbl_Registration.LedgerId = dbo.tbl_LedgerMaster.LedgerId  "
                ////          + " LEFT OUTER JOIN dbo.tbl_UserMaster ON dbo.tbl_Registration.DoctorId = dbo.tbl_UserMaster.UserId "
                ////          + " left join tbl_AppointmentMaster ON tbl_Registration.AId = tbl_AppointmentMaster.AId "
                ////          + " where cast(tbl_AppointmentMaster.ADtmFrom As Date) = '" + Convert.ToDateTime(param_dates).ToString("yyyy-MM-dd") + "' "
                ////          + " and tbl_AppointmentMaster.remark = 'DR. DEVANGI JOGAL' order by QueueNo ";


                sql_query = " SELECT   dbo.tbl_AppointmentMaster .anumber as QueueNo, tbl_LedgerMaster.LedgerName, "
          + " ISNULL(dbo.tbl_Registration.DoctorId, 0) AS DoctorId, ISNULL(dbo.tbl_UserMaster.UserName, '') AS UserName, '' as AproxTime, tbl_AppointmentMaster.ADtmFrom, tbl_AppointmentMaster.Remark, tbl_Registration.DDExitTime,  "
          + " FROM dbo.tbl_AppointmentMaster INNER JOIN "
          + " dbo.tbl_LedgerMaster ON dbo.tbl_AppointmentMaster.LedgerId = dbo.tbl_LedgerMaster.LedgerId  "
          + " left join tbl_Registration ON tbl_AppointmentMaster.AId = tbl_Registration.AId "
          + " LEFT OUTER JOIN dbo.tbl_UserMaster ON dbo.tbl_Registration.DoctorId = dbo.tbl_UserMaster.UserId "
          + " where cast(tbl_AppointmentMaster.ADtmFrom As Date) = '" + Convert.ToDateTime(param_dates).ToString("yyyy-MM-dd") + "' "
          //+ " tbl_LedgerMaster.ledgerId = " + Convert.ToInt32(ledgerId) + " "
          + " and tbl_AppointmentMaster.remark = 'DR. DEVANGI JOGAL' order by cast(tbl_AppointmentMaster.AdtmFrom as time) asc";

                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(sql_query, con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                con.Close();

                DateTime startDtm;

                //DateTime dtCreate = Convert.ToDateTime(dt.Rows[0]["ADtmFrom"]).AddDays(2);
                //DateTime dtCreate = Convert.ToDateTime(dt.Rows[0]["ADtmFrom"]);
                //DateTime dtNow = DateTime.Now;
                //DateTime dtExp = Convert.ToDateTime(dt.Rows[0]["ADtmFrom"]);
                //if (Convert.ToDateTime(dtCreate.ToString("yyyy-MM-dd")) != Convert.ToDateTime(dtNow.ToString("yyyy-MM-dd")))
                //{
                //    Expired.Visible = true;
                //    return;
                //}

                //if (dt.Rows.Count <= 0)
                //{
                //    Expired.Visible = true;
                //    return;
                //}
                //else
                //{
                //    Expired.Visible = false;
                //}


                if (dt.Rows[0]["ADtmFrom"] != DBNull.Value)
                {
                    startDtm = Convert.ToDateTime(dt.Rows[0]["ADtmFrom"]);

                }
                else
                {
                    startDtm = DateTime.Now;
                }

                int cntAddMin = 0;
            Label:
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows[i]["DDExitTime"] != DBNull.Value || dt.Rows[i]["DDInTime"] != DBNull.Value)
                    {
                        dt.Rows[i].Delete();
                        dt.AcceptChanges();
                        goto Label;
                    }

                    dt.Rows[i]["AproxTime"] = Convert.ToString(Convert.ToDateTime(startDtm).AddMinutes(cntAddMin).ToString("hh:mm tt"));
                    // Add Approx 8 minutes of Avarage Cons. time for Doctor
                    cntAddMin += 8;
                }
                gvQueue.DataSource = dt;
                gvQueue.DataBind();

                con.Close();

                // Code for Link Expiration

                //sql_query = "Select GetDate()";
                //con = new SqlConnection(conStr);
                //cmd = new SqlCommand(sql_query, con);
                //dtCreate  = Convert.ToDateTime(cmd.ExecuteNonQuery());

                //////DateTime dtCreate = DateTime.Now;
                ////DateTime dtNow = Convert.ToDateTime(dtCreate);
                ////DateTime dtExp = dtCreate.AddMinutes(2.5);
                ////if (dtNow > dtExp)
                ////{
                ////    Expired.Visible = true;
                ////}
            }
            catch (Exception e)
            {

            }
        }

        string strQSDate = "";
        string ledgerId = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["cd"] != null && Request.QueryString["cd"] != string.Empty)
                    strQSDate = Request.QueryString["cd"];

                if (Request.QueryString["li"] != null && Request.QueryString["li"] != string.Empty)
                    ledgerId = Request.QueryString["li"];
            }

            GetQueueData(strQSDate, ledgerId);
            //GetQueueData(strQSDate);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}