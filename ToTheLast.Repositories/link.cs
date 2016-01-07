using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Nightjar.ToTheLast.Entities;
using Nightjar.ToTheLast.DAL.Access;

namespace Nightjar.ToTheLast.DAL
{
    public class LinkDAC:ILinkDAC
    {
        #region ILinkDAC Members

        public IList<ILink> Get(string where, string orderBy, int startIndex, int noRecords, out int totalNoRecords)
        {
            IList<ILink> links = new List<ILink>();

            using (SprocWrapper db = new SprocWrapper())
            {
                using (IDataReader reader = db.Links_Get(where, orderBy))
                {
                    FillLinkCollection(reader, links, 0, Int32.MaxValue, out totalNoRecords);
                }
            }

            return links;
        }

        public ILink Get(int linkID)
        {
            IList<ILink> links;
            int total;
            string where = string.Format("LinkID={0}", linkID.ToString());
            links = Get(where, null, 0, 1, out total);

            if (links.Count == 1)
                return links[0];
            else
                return null;
        }

        public int Add(string url, string title, string note, int sortOrder)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Link_Insert(url, title, note, sortOrder);
            }
        }

        public bool Update(int linkID, string url, string title, string note, int sortOrder)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Link_Update(linkID, url, title, note, sortOrder);
            }
        }

        public bool Delete(int linkID)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Link_Delete(linkID);
            }
        }

        #endregion

        public void FillLinkCollection(IDataReader reader, IList<ILink> links, int startIndex, int noRecords, out int totalNoRecords)
        {
            int linkID;
            string url;
            string title;
            string note;
            int sortOrder;

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

                linkID = (Convert.IsDBNull(reader["LinkID"])) ? (int)0 : (System.Int32)reader["LinkID"];
                url = (Convert.IsDBNull(reader["URL"])) ? string.Empty : (System.String)reader["URL"];
                title = (Convert.IsDBNull(reader["Title"])) ? string.Empty : (System.String)reader["Title"];
                note = (Convert.IsDBNull(reader["Note"])) ? null : (System.String)reader["Note"];
                sortOrder = (Convert.IsDBNull(reader["SortOrder"])) ? (int)0 : (System.Int32)reader["SortOrder"];
                links.Add(new Link(linkID, url, title, note, sortOrder));
                noRecords--;
            }

            totalNoRecords = count;
        }
    }
}
