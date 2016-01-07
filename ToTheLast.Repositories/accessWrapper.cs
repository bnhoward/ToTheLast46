// This file was generated from the TTL database at 16/10/2007 16:21:52.
using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Text;
using Nightjar.ToTheLast.Utility;

namespace Nightjar.ToTheLast.DAL.Access
{
    #region class SprocWrapper
    public class SprocWrapper : IDisposable
    {
        OleDbConnection _connection = null;

        public SprocWrapper()
        {
            this._connection = new OleDbConnection(ConfigWrapper.ConnectionString);
            this._connection.Open();
        }

        public void Dispose()
        {
            this._connection.Dispose();
        }

        public bool Image_Delete(int imageID)
        {
            OleDbCommand command = new OleDbCommand("Image_Delete", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@ImageID", imageID));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        public IDataReader Image_Get(string whereClause, string orderBy)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM [Image]");
            if (!string.IsNullOrEmpty(whereClause))
                sb.Append(" WHERE " + whereClause);

            if (!string.IsNullOrEmpty(orderBy))
                sb.Append(" ORDER BY " + orderBy);

            OleDbCommand command = new OleDbCommand(sb.ToString(), this._connection);
            command.CommandType = CommandType.Text;
            return command.ExecuteReader();
        }


		public void Image_Insert(string filename, string title, int galleryID,int sortOrder)
		{
			OleDbCommand command = new OleDbCommand("Image_Insert", this._connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new OleDbParameter("@Filename", (filename == null) ? System.DBNull.Value : (object) filename));
			command.Parameters.Add(new OleDbParameter("@Title", (title == null) ? System.DBNull.Value : (object) title));
            command.Parameters.Add(new OleDbParameter("@GalleryID", galleryID));
            command.Parameters.Add(new OleDbParameter("@SortOrder", galleryID));
			command.ExecuteNonQuery();			
		}
		
		public bool Image_Update(int imageID, string title,int sortOrder)
		{
			OleDbCommand command = new OleDbCommand("Image_Update", this._connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new OleDbParameter("@Title", (title == null) ? System.DBNull.Value : (object) title));
			command.Parameters.Add(new OleDbParameter("@SortOrder", (title == null) ? System.DBNull.Value : (object) sortOrder));
            command.Parameters.Add(new OleDbParameter("@ImageID", imageID));
			return Convert.ToBoolean(command.ExecuteNonQuery());
			
		}

        public bool Gallery_Delete(int galleryID)
        {
            OleDbCommand command = new OleDbCommand("Gallery_Delete", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@GalleryID", galleryID));
            return Convert.ToBoolean(command.ExecuteNonQuery());
        }

        public IDataReader Gallery_Get(string whereClause, string orderBy)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Gallery");
            if (!string.IsNullOrEmpty(whereClause))
                sb.Append(" WHERE " + whereClause);

            if (!string.IsNullOrEmpty(orderBy))
                sb.Append(" ORDER BY " + orderBy);

            OleDbCommand command = new OleDbCommand(sb.ToString(), this._connection);
            command.CommandType = CommandType.Text;
            return command.ExecuteReader();
        }

        public void Gallery_Insert(string name, string description, int sortOrder)
        {
            OleDbCommand command = new OleDbCommand("Gallery_Insert", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@Name", (name == null) ? System.DBNull.Value : (object)name));
            command.Parameters.Add(new OleDbParameter("@Description", (description == null) ? System.DBNull.Value : (object)description));
            command.Parameters.Add(new OleDbParameter("@SortOrder", sortOrder));
            command.ExecuteNonQuery();

        }

        public bool Gallery_Update(int galleryID, string name, string description, int sortOrder, string displayImage)
        {
            OleDbCommand command = new OleDbCommand("Gallery_Update", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@Name", (name == null) ? System.DBNull.Value : (object)name));
            command.Parameters.Add(new OleDbParameter("@Description", (description == null) ? System.DBNull.Value : (object)description));
            command.Parameters.Add(new OleDbParameter("@SortOrder", sortOrder));
            command.Parameters.Add(new OleDbParameter("@DisplayImage", (displayImage == null) ? System.DBNull.Value : (object)displayImage));
            command.Parameters.Add(new OleDbParameter("@GalleryID", (object)galleryID));
            return Convert.ToBoolean(command.ExecuteNonQuery());
        }

        public bool Gig_Delete(int gigID)
        {
            OleDbCommand command = new OleDbCommand("Gig_Delete", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@GigID", gigID));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        //public IDataReader Gig_Get_List()
        //{
        //    OleDbCommand command = new OleDbCommand("Gig_Get_List", this._connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    return command.ExecuteReader();

        //}

        //public IDataReader Gig_GetByGigID(int gigID)
        //{
        //    OleDbCommand command = new OleDbCommand("Gig_GetByGigID", this._connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.Add(new OleDbParameter("@GigID", gigID));
        //    return command.ExecuteReader();

        //}

        //public IDataReader Gig_GetPaged(string whereClause, string orderBy, int pageIndex, int pageSize)
        //{
        //    OleDbCommand command = new OleDbCommand("Gig_GetPaged", this._connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.Add(new OleDbParameter("@WhereClause", (whereClause == null) ? System.DBNull.Value : (object)whereClause));
        //    command.Parameters.Add(new OleDbParameter("@OrderBy", (orderBy == null) ? System.DBNull.Value : (object)orderBy));
        //    command.Parameters.Add(new OleDbParameter("@PageIndex", pageIndex));
        //    command.Parameters.Add(new OleDbParameter("@PageSize", pageSize));
        //    return command.ExecuteReader();

        //}

        public int Gig_Insert(string description, string venue, DateTime startDateTime)
        {
            OleDbCommand command = new OleDbCommand("Gig_Insert", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@Description", (description == null) ? System.DBNull.Value : (object)description));
            command.Parameters.Add(new OleDbParameter("@Venue", (venue == null) ? System.DBNull.Value : (object)venue));
            command.Parameters.Add(new OleDbParameter("@StartDateTime", (startDateTime == DateTime.MinValue) ? System.DBNull.Value : (object)startDateTime));
            command.ExecuteNonQuery();
            return 1;//just returning 1 as presently not using GigID

        }

        public bool Gig_Update(int gigID, string description, string venue, DateTime startDateTime)
        {
            OleDbCommand command = new OleDbCommand("Gig_Update", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@Description", (description == null) ? System.DBNull.Value : (object)description));
            command.Parameters.Add(new OleDbParameter("@Venue", (venue == null) ? System.DBNull.Value : (object)venue));
            command.Parameters.Add(new OleDbParameter("@StartDateTime", (startDateTime == DateTime.MinValue) ? System.DBNull.Value : (object)startDateTime));
            command.Parameters.Add(new OleDbParameter("@GigID", gigID));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        public IDataReader Gigs_Get(string whereClause, string orderBy)
        {
            StringBuilder sb=new StringBuilder();
            sb.Append("SELECT * FROM Gig");
            if (!string.IsNullOrEmpty(whereClause))
                sb.Append(" WHERE " + whereClause);

            if (!string.IsNullOrEmpty(orderBy))
                sb.Append(" ORDER BY " + orderBy);

            OleDbCommand command = new OleDbCommand(sb.ToString(), this._connection);
            command.CommandType = CommandType.Text;
            return command.ExecuteReader();

        }

        //public IDataReader Gigs_Get_List()
        //{
        //    OleDbCommand command = new OleDbCommand("Gigs_Get_List", this._connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    return command.ExecuteReader();

        //}

        public bool Guestbook_Delete(int guestbookID)
        {
            OleDbCommand command = new OleDbCommand("Guestbook_Delete", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@GuestbookID", guestbookID));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        //public IDataReader Guestbook_Get_List()
        //{
        //    OleDbCommand command = new OleDbCommand("Guestbook_Get_List", this._connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    return command.ExecuteReader();

        //}

        //public IDataReader Guestbook_GetByGuestbookID(int guestbookID)
        //{
        //    OleDbCommand command = new OleDbCommand("Guestbook_GetByGuestbookID", this._connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.Add(new OleDbParameter("@GuestbookID", guestbookID));
        //    return command.ExecuteReader();

        //}

        //public IDataReader Guestbook_GetPaged(string whereClause, string orderBy, int pageIndex, int pageSize)
        //{
        //    OleDbCommand command = new OleDbCommand("Guestbook_GetPaged", this._connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.Add(new OleDbParameter("@WhereClause", (whereClause == null) ? System.DBNull.Value : (object)whereClause));
        //    command.Parameters.Add(new OleDbParameter("@OrderBy", (orderBy == null) ? System.DBNull.Value : (object)orderBy));
        //    command.Parameters.Add(new OleDbParameter("@PageIndex", pageIndex));
        //    command.Parameters.Add(new OleDbParameter("@PageSize", pageSize));
        //    return command.ExecuteReader();

        //}

        public int Guestbook_Insert(string name, string email, string comment, string reply)
        {
            OleDbCommand command = new OleDbCommand("Guestbook_Insert", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@Name", (name == null) ? System.DBNull.Value : (object)name));
            command.Parameters.Add(new OleDbParameter("@Email", (email == null) ? System.DBNull.Value : (object)email));
            command.Parameters.Add(new OleDbParameter("@Comment", (comment == null) ? System.DBNull.Value : (object)comment));
            command.Parameters.Add(new OleDbParameter("@Reply", (reply == null) ? System.DBNull.Value : (object)reply));
            command.ExecuteNonQuery();
            return 1;

        }

        public bool Guestbook_Update(int guestbookID, string name, string email, string comment, string reply, bool display)
        {
            OleDbCommand command = new OleDbCommand("Guestbook_Update", this._connection);
            command.Parameters.Add(new OleDbParameter("@Name", (name == null) ? System.DBNull.Value : (object)name));
            command.Parameters.Add(new OleDbParameter("@Email", (email == null) ? System.DBNull.Value : (object)email));
            command.Parameters.Add(new OleDbParameter("@Comment", (comment == null) ? System.DBNull.Value : (object)comment));
            command.Parameters.Add(new OleDbParameter("@Reply", (reply == null) ? System.DBNull.Value : (object)reply));
            command.Parameters.Add(new OleDbParameter("@Display", (object)display));
            command.Parameters.Add(new OleDbParameter("@GuestbookID", guestbookID));
            command.CommandType = CommandType.StoredProcedure;
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        public IDataReader GuestbookEntries_Get(string whereClause, string orderBy)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Guestbook");
            if (!string.IsNullOrEmpty(whereClause))
                sb.Append(" WHERE " + whereClause);

            if (!string.IsNullOrEmpty(orderBy))
                sb.Append(" ORDER BY " + orderBy);

            OleDbCommand command = new OleDbCommand(sb.ToString(), this._connection);
            command.CommandType = CommandType.Text;
            return command.ExecuteReader();
        }

        public IDataReader Links_Get(string whereClause, string orderBy)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Link");
            if (!string.IsNullOrEmpty(whereClause))
                sb.Append(" WHERE " + whereClause);

            if (!string.IsNullOrEmpty(orderBy))
                sb.Append(" ORDER BY " + orderBy);

            OleDbCommand command = new OleDbCommand(sb.ToString(), this._connection);
            command.CommandType = CommandType.Text;
            return command.ExecuteReader();

        }

        public int Link_Insert(string uRL, string title, string note, int sortOrder)
        {
            OleDbCommand command = new OleDbCommand("Link_Insert", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@URL", (uRL == null) ? System.DBNull.Value : (object)uRL));
            command.Parameters.Add(new OleDbParameter("@Title", (title == null) ? System.DBNull.Value : (object)title));
            command.Parameters.Add(new OleDbParameter("@Note", (note == null) ? System.DBNull.Value : (object)note));
            command.Parameters.Add(new OleDbParameter("@SortOrder", sortOrder));
            command.ExecuteNonQuery();
            return 1;

        }

        public bool Link_Delete(int linkID)
        {
            OleDbCommand command = new OleDbCommand("Link_Delete", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@LinkID", linkID));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        public bool Link_Update(int linkID, string uRL, string title, string note, int sortOrder)
        {
            OleDbCommand command = new OleDbCommand("Link_Update", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@URL", (uRL == null) ? System.DBNull.Value : (object)uRL));
            command.Parameters.Add(new OleDbParameter("@Title", (title == null) ? System.DBNull.Value : (object)title));
            command.Parameters.Add(new OleDbParameter("@Note", (note == null) ? System.DBNull.Value : (object)note));
            command.Parameters.Add(new OleDbParameter("@SortOrder", sortOrder));
            command.Parameters.Add(new OleDbParameter("@LinkID", linkID));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }


        public bool News_Delete(int newsID)
        {
            OleDbCommand command = new OleDbCommand("News_Delete", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@NewsID", newsID));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        //public IDataReader News_Get_List()
        //{
        //    OleDbCommand command = new OleDbCommand("News_Get_List", this._connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    return command.ExecuteReader();

        //}

        //public IDataReader News_GetByNewsID(int newsID)
        //{
        //    OleDbCommand command = new OleDbCommand("News_GetByNewsID", this._connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.Add(new OleDbParameter("@NewsID", newsID));
        //    return command.ExecuteReader();

        //}

        //public IDataReader News_GetPaged(string whereClause, string orderBy, int pageIndex, int pageSize)
        //{
        //    OleDbCommand command = new OleDbCommand("News_GetPaged", this._connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.Add(new OleDbParameter("@WhereClause", (whereClause == null) ? System.DBNull.Value : (object)whereClause));
        //    command.Parameters.Add(new OleDbParameter("@OrderBy", (orderBy == null) ? System.DBNull.Value : (object)orderBy));
        //    command.Parameters.Add(new OleDbParameter("@PageIndex", pageIndex));
        //    command.Parameters.Add(new OleDbParameter("@PageSize", pageSize));
        //    return command.ExecuteReader();

        //}

        public int News_Insert(string subject, string newsText, DateTime dateCreated)
        {
            OleDbCommand command = new OleDbCommand("News_Insert", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@Subject", (subject == null) ? System.DBNull.Value : (object)subject));
            command.Parameters.Add(new OleDbParameter("@NewsText", (newsText == null) ? System.DBNull.Value : (object)newsText));
            //command.Parameters.Add(new OleDbParameter("@DateCreated", (dateCreated == DateTime.MinValue) ? System.DBNull.Value : (object)dateCreated));
            command.ExecuteNonQuery();
            
            //get identity
            OleDbCommand identityCommand = new OleDbCommand("SELECT @@IDENTITY",this._connection);
            command.CommandType = CommandType.Text;
            return (int)identityCommand.ExecuteScalar();

        }

        public bool News_Update(int newsID, string subject, string newsText)
        {
            OleDbCommand command = new OleDbCommand("News_Update", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@Subject", (subject == null) ? System.DBNull.Value : (object)subject));
            command.Parameters.Add(new OleDbParameter("@NewsText", (newsText == null) ? System.DBNull.Value : (object)newsText));
            command.Parameters.Add(new OleDbParameter("@NewsID", newsID));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        public IDataReader NewsItems_Get(string whereClause, string orderBy)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM News");
            if (!string.IsNullOrEmpty(whereClause))
                sb.Append(" WHERE " + whereClause);

            if (!string.IsNullOrEmpty(orderBy))
                sb.Append(" ORDER BY " + orderBy);

            OleDbCommand command = new OleDbCommand(sb.ToString(), this._connection);
            command.CommandType = CommandType.Text;
            return command.ExecuteReader();
        }

        public bool Profile_Delete(int profileID)
        {
            OleDbCommand command = new OleDbCommand("Profile_Delete", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@ProfileID", profileID));
            return Convert.ToBoolean(command.ExecuteNonQuery());
        }

        public IDataReader Profile_Get()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Profile ORDER BY SortOrder");

            OleDbCommand command = new OleDbCommand(sb.ToString(), this._connection);
            command.CommandType = CommandType.Text;
            return command.ExecuteReader();
        }

        public IDataReader Profile_Get(int profileID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Profile WHERE ProfileID="+profileID.ToString());

            OleDbCommand command = new OleDbCommand(sb.ToString(), this._connection);
            command.CommandType = CommandType.Text;
            return command.ExecuteReader();
        }

        public int Profile_Insert(string name, string profileText, int sortOrder)
        {
            OleDbCommand command = new OleDbCommand("Profile_Insert", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@Name", (name == null) ? System.DBNull.Value : (object)name));
            command.Parameters.Add(new OleDbParameter("@ProfileText", (profileText == null) ? System.DBNull.Value : (object)profileText));
            command.Parameters.Add(new OleDbParameter("@SortOrder", sortOrder));
            command.ExecuteNonQuery();

            //get identity
            OleDbCommand identityCommand = new OleDbCommand("SELECT @@IDENTITY", this._connection);
            command.CommandType = CommandType.Text;
            return (int)identityCommand.ExecuteScalar();

        }

        public bool Profile_Update(int profileID, string name, string profileText, int sortOrder)
        {
            OleDbCommand command = new OleDbCommand("Profile_Update", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new OleDbParameter("@Name", (name == null) ? System.DBNull.Value : (object)name));
            command.Parameters.Add(new OleDbParameter("@ProfileText", (profileText == null) ? System.DBNull.Value : (object)profileText));
            command.Parameters.Add(new OleDbParameter("@SortOrder", sortOrder));
            command.Parameters.Add(new OleDbParameter("@ProfileID", (object)profileID));
            return Convert.ToBoolean(command.ExecuteNonQuery());
        }


        //public IDataReader NewsItems_Get_List()
        //{
        //    OleDbCommand command = new OleDbCommand("NewsItems_Get_List", this._connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    return command.ExecuteReader();

        //}

    }
    #endregion
}


