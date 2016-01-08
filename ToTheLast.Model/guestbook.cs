// This file was generated from the TTL database at 16/10/2007 16:27:11.
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nightjar.ToTheLast.Entities
{
    public class Guestbook 
    {
        int guestbookID;
        string name;
        string email;
        string comment;
        string reply;
        bool display;
        DateTime dateCreated;

        public Guestbook(int guestbookID, string name, string email, string comment, string reply,bool display, DateTime dateCreated)
        {
            this.guestbookID = guestbookID;
            this.name = name;
            this.email = email;
            this.comment = comment;
            this.reply = reply;
            this.display = display;
            this.dateCreated = dateCreated;
        }

        #region Guestbook Members


        public int GuestbookID
        {
            get { return guestbookID; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Email
        {
            get { return email; }
        }

        public string Comment
        {
            get { return comment; }
        }

        public string Reply
        {
            get { return reply; }
        }

        public bool Display
        {
            get{return display;}
        }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateCreated
        {
            get { return dateCreated; }
        }


        #endregion
    }
}

