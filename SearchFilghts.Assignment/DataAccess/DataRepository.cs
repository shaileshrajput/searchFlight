using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace SearchFilghts.Assignment.DataAccess
{
    public class DataRepository : IDataRepository
    {
        /// <summary>
        /// This method read the provider data 
        /// </summary>
        /// <param name="FileName">Name of file where data is stored</param>
        /// <param name="separater">Separater used in the file</param>
        /// <returns>provider data as DataTable</returns>
        public DataTable ReadDataFromProvider(string ProviderName, char separater)
        {
            DataTable dtProviderData = new DataTable();
            List<string> lstRow = new List<string>();
            using (StreamReader sr = new StreamReader(this.getPath(@"/" + ProviderName)))
            {
                while (sr.Peek() >= 0)
                {
                    //Using readline method to read text file.
                    lstRow.Add(sr.ReadLine());
                }
            }
            //Add column header into the tables by extractting the fist line (title line).
            string[] strFirsline = lstRow[0].Split(separater);
            dtProviderData.Columns.Add(new DataColumn(strFirsline[0], typeof(string)));
            dtProviderData.Columns.Add(new DataColumn(strFirsline[1], typeof(DateTime)));
            dtProviderData.Columns.Add(new DataColumn(strFirsline[2], typeof(string)));
            dtProviderData.Columns.Add(new DataColumn(strFirsline[3], typeof(DateTime)));
            dtProviderData.Columns.Add(new DataColumn(strFirsline[4], typeof(float)));
            //Ignore the fist line (title line).
            for (int colCount = 1; colCount < lstRow.Count; colCount++)
            {
                //using string.split() method to split the string.
                string[] strRowVal = lstRow[colCount].Split(separater);
                strRowVal[4] = strRowVal[4].TrimStart('$');
                dtProviderData.Rows.Add(strRowVal);
            }
            return dtProviderData;
        }
        /// <summary>
        /// get the full path of file while running application and performing Unit tesing 
        /// </summary>
        /// <param name="filePath">file name to read</param>
        /// <returns>get the full path of file while running application and performing Unit tesing</returns>
        private string getPath(string filePath)
        {
            string hostingRoot=string.Empty;
            if (System.Web.Hosting.HostingEnvironment.IsHosted)
            {
                hostingRoot= System.Web.Hosting.HostingEnvironment.MapPath("~/");
            }
            else
            {
                hostingRoot= AppDomain.CurrentDomain.BaseDirectory;
            }
            return Path.Combine(hostingRoot, filePath.Substring(1).Replace('/', '\\'));
        }
    }
}