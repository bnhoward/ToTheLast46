// This file was generated from the TTL database at 16/10/2007 16:26:19.
using System;
using System.Collections.Generic;
using System.Text;

namespace Nightjar.ToTheLast.Entities
{
    public class Gig : IGig
    {
        int gigID;
        string description;
        string venue;
        DateTime startDateTime;

        public Gig(int gigID, string description, string venue, DateTime startDateTime)
        {
            this.gigID = gigID;
            this.description = description;
            this.venue = venue;
            this.startDateTime = startDateTime;
        }

        #region IGig Members


        public int GigID
        {
            get { return gigID; }
        }

        public string Description
        {
            get { return description; }
        }

        public string Venue
        {
            get { return venue; }
        }

        public DateTime StartDateTime
        {
            get { return startDateTime; }
        }


        #endregion
    }
}

