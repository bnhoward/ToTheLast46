// This file was generated from the TTL database at 16/10/2007 16:27:47.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nightjar.ToTheLast.Entities
{
    public class News
    {
        int newsID;
        string subject;
        string newsText;
        DateTime dateCreated;

        public News(int newsID, string subject, string newsText, DateTime dateCreated)
        {
            this.newsID = newsID;
            this.subject = subject;
            this.newsText = newsText;
            this.dateCreated = dateCreated;
        }

        #region News Members


        public int NewsID
        {
            get { return newsID; }
        }

        public string Subject
        {
            get { return subject; }
        }

        [DisplayName("Text")]
        public string NewsText
        {
            get { return newsText; }
        }

        [DisplayName("Date Created")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateCreated
        {
            get { return dateCreated; }
        }


        #endregion
    }
}

