using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Nightjar.ToTheLast.Entities;
using Nightjar.ToTheLast.DAL.Access;

namespace Nightjar.ToTheLast.DAL
{
    public class GuestbookDAC:IGuestbookDAC
    {
        #region IGuestbookDAC Members

        public IList<Guestbook> Get(string where, string orderBy, int startIndex, int noRecords, out int totalNoRecords)
        {
            IList<Guestbook> guestbookEntries = new List<Guestbook>();

            using (SprocWrapper db = new SprocWrapper())
            {
                using (IDataReader reader = db.GuestbookEntries_Get(where, orderBy))
                {
                    FillGuestbookCollection(reader, guestbookEntries, startIndex, noRecords, out totalNoRecords);
                }
            }

            return guestbookEntries;
        }

        public Guestbook Get(int guestbookID)
        {
            int total;
            IList<Guestbook> guestbookEntries = new List<Guestbook>();

            guestbookEntries = Get("GuestbookID=" + guestbookID.ToString(), null, 0, 1, out total);

            if (guestbookEntries.Count == 1)
                return guestbookEntries[0];
            else
                return null;
        }

        public int Add(string name, string email, string comment)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Guestbook_Insert(name, email, comment, null);
            }
        }

        public bool Update(int guestbookID, string reply)
        {
            Guestbook guestbook=Get(guestbookID);

            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Guestbook_Update(guestbookID, guestbook.Name, guestbook.Email, guestbook.Comment, reply,guestbook.Display);
            }
        }

        public bool Update(int guestbookID, bool display)
        {
            Guestbook guestbook = Get(guestbookID);

            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Guestbook_Update(guestbookID, guestbook.Name, guestbook.Email, guestbook.Comment, guestbook.Reply, display);
            }
        }

        public bool Delete(int guestbookID)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Guestbook_Delete(guestbookID);
            }
        }

        #endregion

        public void FillGuestbookCollection(IDataReader reader, IList<Guestbook> guestbooks, int startIndex, int noRecords, out int totalNoRecords)
        {
            int guestbookID;
            string name;
            string email;
            string comment;
            string reply;
            bool display;
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

                guestbookID = (Convert.IsDBNull(reader["GuestbookID"])) ? (int)0 : (System.Int32)reader["GuestbookID"];
                name = (Convert.IsDBNull(reader["Name"])) ? string.Empty : (System.String)reader["Name"];
                email = (Convert.IsDBNull(reader["Email"])) ? null : (System.String)reader["Email"];
                comment = (Convert.IsDBNull(reader["Comment"])) ? string.Empty : (System.String)reader["Comment"];
                reply = (Convert.IsDBNull(reader["Reply"])) ? null : (System.String)reader["Reply"];
                display = (System.Boolean)reader["Display"];
                dateCreated = (Convert.IsDBNull(reader["DateCreated"])) ? DateTime.MinValue : (System.DateTime)reader["DateCreated"];
                guestbooks.Add(new Guestbook(guestbookID, name, email, comment, reply,display, dateCreated));
                noRecords--;
            }

            totalNoRecords = count;
        }
    }
}
