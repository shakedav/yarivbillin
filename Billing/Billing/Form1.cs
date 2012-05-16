using System;
   using System.Collections.Generic;
   using System.ComponentModel;
   using System.Data;
   using System.Drawing;
   using System.Text;
   using System.Windows.Forms;
   using System.Data.OleDb;
   using System.IO;

namespace Billing
   {
       public partial class Form1 : Form
       {
           public Form1()
           {
               InitializeComponent();
           }
   
           private void Form1_Load(object sender, EventArgs e)
           {
               try
               {
                   String Path = Directory.GetCurrentDirectory();
                   String DB_Path = Path + "\\Sample_XLSDB.XLS";
                   string Con_Str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DB_Path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
                   OleDbConnection con = new OleDbConnection(Con_Str);

                   String qry = "SELECT * FROM [sheet1$] where PR_MiddleName = PR_FirstName ";
                   OleDbDataAdapter odp = new OleDbDataAdapter(qry, con);
                   DataSet ds = new DataSet();
                   odp.Fill(ds);
   
                   dataGridView1.DataSource = ds.Tables[0];
                   dataGridView1.Update();
               }
               catch (Exception ex)
               {
                   String aa = ex.GetBaseException().ToString();
                   aa = "";
               }
           }
       }
   }