using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Nightjar.ToTheLast.Entities;
using Nightjar.ToTheLast.DAL.Access;

namespace Nightjar.ToTheLast.DAL
{
    public class GigDAC:IGigDAC
    {
        #region IGigDAC Members

        public IList<IGig> Get(string where, string orderBy, int startIndex, int noRecords, out int totalNoRecords)
        {
            IList<IGig> gigs = new List<IGig>();

            using (SprocWrapper db = new SprocWrapper())
            {
                using (IDataReader reader = db.Gigs_Get(where, orderBy))
                {
                    FillGigCollection(reader, gigs, 0, Int32.MaxValue, out totalNoRecords);
                }
            }

            return gigs;
        }

        public IGig Get(int gigID)
        {
            IList<IGig> gigs;
            int total;
            string where = string.Format("GigID={0}", gigID.ToString());
            gigs=Get(where, null, 0, 1, out total);

            if (gigs.Count == 1)
                return gigs[0];
            else
                return null;
        }

        public int Add(string description, string venue, DateTime startDateTime)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Gig_Insert(description, venue, startDateTime);
            }
        }

        public bool Update(int gigID, string description, string venue, DateTime startDateTime)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Gig_Update(gigID, description, venue, startDateTime);
            }
        }

        public bool Delete(int gigID)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Gig_Delete(gigID);
            }
        }



        #endregion

        public void FillGigCollection(IDataReader reader, IList<IGig> gigs, int startIndex, int noRecords, out int totalNoRecords)
        {
            int gigID;
            string description;
            string venue;
            DateTime startDateTime;

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

                gigID = (Convert.IsDBNull(reader["GigID"])) ? (int)0 : (System.Int32)reader["GigID"];
                description = (Convert.IsDBNull(reader["Description"])) ? string.Empty : (System.String)reader["Description"];
                venue = (Convert.IsDBNull(reader["Venue"])) ? string.Empty : (System.String)reader["Venue"];
                startDateTime = (Convert.IsDBNull(reader["StartDateTime"])) ? DateTime.MinValue : (System.DateTime)reader["StartDateTime"];
                gigs.Add(new Gig(gigID, description, venue, startDateTime));
                noRecords--;
            }

            totalNoRecords = count;
        }

    }
}
