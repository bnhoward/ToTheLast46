// This file was generated from the TTL database at 16/10/2007 16:27:47.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace Nightjar.ToTheLast.Entities
{
    public class Profile
    {
        int profileID;
        string name;
        string profileText;
        int sortOrder;

        public Profile(int profileID, string name, string profileText, int sortOrder)
        {
            this.profileID = profileID;
            this.name = name;
            this.profileText = profileText;
            this.sortOrder = sortOrder;
        }

        #region Profile Members


        public int ProfileID
        {
            get { return profileID; }
        }

        public string Name
        {
            get { return name; }
        }

        public string ProfileText
        {
            get { return profileText; }
        }

        public int SortOrder
        {
            get { return sortOrder; }
        }

        public string ImageName
        {
            get { return "profile_" + profileID.ToString() + ".jpg"; }
        }

        public bool ImageExists
        {
            get
            {
                if (File.Exists(HttpContext.Current.Server.MapPath("~/SiteContent/Images/Band/" + ImageName)))
                    return true;
                else
                    return false;
            }
        }



        #endregion
    }
}

