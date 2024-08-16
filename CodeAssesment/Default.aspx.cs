using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeAssesment
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataGrids();
            }
        }
        private void BindDataGrids()
        {
            // Map Path to locate and return the csv file to the appropriate path.
            string filePath = Server.MapPath("~/MyData/DataForTest.csv");
            DataTable dtData = GetMyData(filePath);

            // Binds the data to the grid with all the data
            myDataGrid.DataSource = dtData;
            myDataGrid.DataBind();

            // Filtering data by element types
            DataTable fireData = FilterDataByType(dtData, "fire");
            DataTable waterData = FilterDataByType(dtData, "water");

            // Data Binding to their own grids
            fireDataGrid.DataSource = fireData;
            fireDataGrid.DataBind();

            waterDataGrid.DataSource = waterData;
            waterDataGrid.DataBind();

        }

        private DataTable GetMyData(string filePath)
        {
            DataTable dtMyDataSet = new DataTable();
            using (StreamReader fileRead = new StreamReader(filePath))
            {
                string line;
                int row = 0;
                //Reads the line from the file if it is not null
                while ((line = fileRead.ReadLine()) != null)
                {
                    Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    string[] x = CSVParser.Split(line);
                
                    if (row == 0)
                    {
                        foreach (string header in x)
                        {
                            dtMyDataSet.Columns.Add(header);
                        }
                    }
                    else
                    {
                        DataRow dRow = dtMyDataSet.NewRow();
                        for (int i = 0; i < x.Length; i++)
                        {
                            dRow[i] = x[i];
                        }
                        dtMyDataSet.Rows.Add(dRow);
                    }
                    row++;
                }
            }
            return dtMyDataSet;
        }

        private DataTable FilterDataByType(DataTable dataTable, string type)
        {
            //Clone the table with only the column names and their data types to set it up
            DataTable filteredData = dataTable.Clone();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Type"].ToString().Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    //Make an import of the entire row when the type matches type passed
                    filteredData.ImportRow(row);
                }
            }

            return filteredData;
        }
    }
}
