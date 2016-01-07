using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Nightjar.ToTheLast.Entities;
using Nightjar.ToTheLast.DAL.Access;

namespace Nightjar.ToTheLast.DAL
{
    public class ProfileDAC : IProfileDAC
    {
        #region IProfileDAC Members

        public IList<Profile> GetAll()
        {
            IList<Profile> galleries = new List<Profile>();

            using (SprocWrapper db = new SprocWrapper())
            {
                using (IDataReader reader = db.Profile_Get())
                {
                    int total;
                    FillProfileCollection(reader, galleries, 0, Int32.MaxValue, out total);
                }
            }

            return galleries;
        }

        public Profile GetProfile(int profileID)
        {
            IList<Profile> galleries = new List<Profile>();

            using (SprocWrapper db = new SprocWrapper())
            {
                using (IDataReader reader = db.Profile_Get(profileID))
                {
                    int total;
                    FillProfileCollection(reader, galleries, 0, Int32.MaxValue, out total);
                }
            }

            if (galleries.Count == 1)
                return galleries[0];
            else
                return null;
        }

        public int Add(string name, string profileText, int sortOrder)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Profile_Insert(name, profileText, sortOrder);
            }
        }

        public bool Update(int profileID, string name, string profileText, int sortOrder)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Profile_Update(profileID, name, profileText, sortOrder);
            }
        }

        public bool Delete(int profileID)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Profile_Delete(profileID);
            }
        }

        #endregion

        public void FillProfileCollection(IDataReader reader, IList<Profile> profiles, int startIndex, int noRecords, out int totalNoRecords)
        {
            int profileID;
            string name;
            string profileText;
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

                profileID = (Convert.IsDBNull(reader["ProfileID"])) ? (int)0 : (System.Int32)reader["ProfileID"];
                name = (Convert.IsDBNull(reader["Name"])) ? string.Empty : (System.String)reader["Name"];
                profileText = (Convert.IsDBNull(reader["ProfileText"])) ? null : (System.String)reader["ProfileText"];
                sortOrder = (Convert.IsDBNull(reader["SortOrder"])) ? (int)0 : (System.Int32)reader["SortOrder"];
                profiles.Add(new Profile(profileID, name, profileText, sortOrder));
                noRecords--;
            }

            totalNoRecords = count;
        }
    }
}
