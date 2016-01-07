// This file was generated from the TTL database at 22/10/2007 11:05:00.
using System;
using System.Collections.Generic;
using System.Text;

namespace Nightjar.ToTheLast.Entities
{


    public class Link 
    {
        int linkID;
        string uRL;
        string title;
        string note;
        int sortOrder;

        public Link(int linkID, string uRL, string title, string note, int sortOrder)
        {
            this.linkID = linkID;
            this.uRL = uRL;
            this.title = title;
            this.note = note;
            this.sortOrder = sortOrder;
        }

        #region Link Members


        public int LinkID
        {
            get { return linkID; }
        }

        public string URL
        {
            get { return uRL; }
        }

        public string Title
        {
            get { return title; }
        }

        public string Note
        {
            get { return note; }
        }

        public int SortOrder
        {
            get { return sortOrder; }
        }


        #endregion
    }
}

