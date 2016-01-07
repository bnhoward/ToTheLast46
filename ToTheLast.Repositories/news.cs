using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Nightjar.ToTheLast.DAL.Access;
using Nightjar.ToTheLast.Entities;

namespace Nightjar.ToTheLast.DAL
{
    public class NewsDAC:INewsDAC
    {
        #region INewsDAC Members

        public IList<News> Get(string where, string orderBy, int startIndex, int noRecords, out int totalNoRecords)
        {
            IList<News> news = new List<News>();

            using (SprocWrapper db = new SprocWrapper())
            {
                using (IDataReader reader = db.NewsItems_Get(where, orderBy))
                {
                    FillNewsCollection(reader, news, startIndex, noRecords, out totalNoRecords);
                }
            }

            return news;
        }

        public int Add(string subject, string newsText)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.News_Insert(subject, newsText, DateTime.Now);
            }
        }

        public bool Update(int newsID,string subject, string newsText)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.News_Update(newsID, subject, newsText);
            }
        }

        public bool Delete(int newsID)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.News_Delete(newsID);
            }
        }


        #endregion

        public void FillNewsCollection(IDataReader reader, IList<News> newss, int startIndex, int noRecords, out int totalNoRecords)
        {
            int newsID;
            string subject;
            string newsText;
            DateTime dateCreated;

            int count = 0;

            while (reader.Read())
            {
                if (count < startIndex || noRecords == 0)
                {
                    count++;
                    continue;
                }
                else
                    count++;

                newsID = (Convert.IsDBNull(reader["NewsID"])) ? (int)0 : (System.Int32)reader["NewsID"];
                subject = (Convert.IsDBNull(reader["Subject"])) ? string.Empty : (System.String)reader["Subject"];
                newsText = (Convert.IsDBNull(reader["NewsText"])) ? string.Empty : (System.String)reader["NewsText"];
                dateCreated = (Convert.IsDBNull(reader["DateCreated"])) ? DateTime.MinValue : (System.DateTime)reader["DateCreated"];
                newss.Add(new News(newsID, subject, newsText, dateCreated));
                noRecords--;
            }

            totalNoRecords = count;
        }
    }
}
