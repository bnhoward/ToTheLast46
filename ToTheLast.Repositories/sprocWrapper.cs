// This file was generated from the TTL database at 16/10/2007 16:21:52.
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Nightjar.ToTheLast.Utility;

namespace Nightjar.ToTheLast.DAL.Sql
{
    #region class SprocWrapper
    public class SprocWrapper : IDisposable
    {
        SqlConnection _connection = null;

        public SprocWrapper()
        {
            this._connection = new SqlConnection(ConfigWrapper.ConnectionString);
            this._connection.Open();
        }

        public void Dispose()
        {
            this._connection.Dispose();
        }

        public bool Gig_Delete(int gigID)
        {
            SqlCommand command = new SqlCommand("dbo.Gig_Delete", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@GigID", gigID));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        public IDataReader Gig_Get_List()
        {
            SqlCommand command = new SqlCommand("dbo.Gig_Get_List", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();

        }

        public IDataReader Gig_GetByGigID(int gigID)
        {
            SqlCommand command = new SqlCommand("dbo.Gig_GetByGigID", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@GigID", gigID));
            return command.ExecuteReader();

        }

        public IDataReader Gig_GetPaged(string whereClause, string orderBy, int pageIndex, int pageSize)
        {
            SqlCommand command = new SqlCommand("dbo.Gig_GetPaged", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@WhereClause", (whereClause == null) ? System.DBNull.Value : (object)whereClause));
            command.Parameters.Add(new SqlParameter("@OrderBy", (orderBy == null) ? System.DBNull.Value : (object)orderBy));
            command.Parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            command.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            return command.ExecuteReader();

        }

        public int Gig_Insert(string description, string venue, DateTime startDateTime)
        {
            SqlCommand command = new SqlCommand("dbo.Gig_Insert", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Description", (description == null) ? System.DBNull.Value : (object)description));
            command.Parameters.Add(new SqlParameter("@Venue", (venue == null) ? System.DBNull.Value : (object)venue));
            command.Parameters.Add(new SqlParameter("@StartDateTime", (startDateTime == DateTime.MinValue) ? System.DBNull.Value : (object)startDateTime));
            SqlParameter outputParameter = null;
            outputParameter = new SqlParameter("@GigID", new int());
            outputParameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(outputParameter);
            command.ExecuteNonQuery();
            return (int)outputParameter.Value;

        }

        public bool Gig_Update(int gigID, string description, string venue, DateTime startDateTime)
        {
            SqlCommand command = new SqlCommand("dbo.Gig_Update", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@GigID", gigID));
            command.Parameters.Add(new SqlParameter("@Description", (description == null) ? System.DBNull.Value : (object)description));
            command.Parameters.Add(new SqlParameter("@Venue", (venue == null) ? System.DBNull.Value : (object)venue));
            command.Parameters.Add(new SqlParameter("@StartDateTime", (startDateTime == DateTime.MinValue) ? System.DBNull.Value : (object)startDateTime));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        public IDataReader Gigs_Get(string whereClause, string orderBy)
        {
            SqlCommand command = new SqlCommand("dbo.Gigs_Get", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@WhereClause", (whereClause == null) ? System.DBNull.Value : (object)whereClause));
            command.Parameters.Add(new SqlParameter("@OrderBy", (orderBy == null) ? System.DBNull.Value : (object)orderBy));
            return command.ExecuteReader();

        }

        public IDataReader Gigs_Get_List()
        {
            SqlCommand command = new SqlCommand("dbo.Gigs_Get_List", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();

        }

        public bool Guestbook_Delete(int guestbookID)
        {
            SqlCommand command = new SqlCommand("dbo.Guestbook_Delete", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@GuestbookID", guestbookID));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        public IDataReader Guestbook_Get_List()
        {
            SqlCommand command = new SqlCommand("dbo.Guestbook_Get_List", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();

        }

        public IDataReader Guestbook_GetByGuestbookID(int guestbookID)
        {
            SqlCommand command = new SqlCommand("dbo.Guestbook_GetByGuestbookID", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@GuestbookID", guestbookID));
            return command.ExecuteReader();

        }

        public IDataReader Guestbook_GetPaged(string whereClause, string orderBy, int pageIndex, int pageSize)
        {
            SqlCommand command = new SqlCommand("dbo.Guestbook_GetPaged", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@WhereClause", (whereClause == null) ? System.DBNull.Value : (object)whereClause));
            command.Parameters.Add(new SqlParameter("@OrderBy", (orderBy == null) ? System.DBNull.Value : (object)orderBy));
            command.Parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            command.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            return command.ExecuteReader();

        }

        public int Guestbook_Insert(string name, string email, string comment, string reply, DateTime dateCreated)
        {
            SqlCommand command = new SqlCommand("dbo.Guestbook_Insert", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Name", (name == null) ? System.DBNull.Value : (object)name));
            command.Parameters.Add(new SqlParameter("@Email", (email == null) ? System.DBNull.Value : (object)email));
            command.Parameters.Add(new SqlParameter("@Comment", (comment == null) ? System.DBNull.Value : (object)comment));
            command.Parameters.Add(new SqlParameter("@Reply", (reply == null) ? System.DBNull.Value : (object)reply));
            command.Parameters.Add(new SqlParameter("@DateCreated", (dateCreated == DateTime.MinValue) ? System.DBNull.Value : (object)dateCreated));
            SqlParameter outputParameter = null;
            outputParameter = new SqlParameter("@GuestbookID", new int());
            outputParameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(outputParameter);
            command.ExecuteNonQuery();
            return (int)outputParameter.Value;

        }

        public bool Guestbook_Update(int guestbookID, string name, string email, string comment, string reply,bool display)
        {
            SqlCommand command = new SqlCommand("dbo.Guestbook_Update", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@GuestbookID", guestbookID));
            command.Parameters.Add(new SqlParameter("@Name", (name == null) ? System.DBNull.Value : (object)name));
            command.Parameters.Add(new SqlParameter("@Email", (email == null) ? System.DBNull.Value : (object)email));
            command.Parameters.Add(new SqlParameter("@Comment", (comment == null) ? System.DBNull.Value : (object)comment));
            command.Parameters.Add(new SqlParameter("@Reply", (reply == null) ? System.DBNull.Value : (object)reply));
            command.Parameters.Add(new SqlParameter("@Display",(object)display));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        public IDataReader GuestbookEntries_Get(string whereClause, string orderBy)
        {
            SqlCommand command = new SqlCommand("dbo.GuestbookEntries_Get", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@WhereClause", (whereClause == null) ? System.DBNull.Value : (object)whereClause));
            command.Parameters.Add(new SqlParameter("@OrderBy", (orderBy == null) ? System.DBNull.Value : (object)orderBy));
            return command.ExecuteReader();

        }

        public IDataReader GuestbookEntries_Get_List()
        {
            SqlCommand command = new SqlCommand("dbo.GuestbookEntries_Get_List", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();

        }

        public bool News_Delete(int newsID)
        {
            SqlCommand command = new SqlCommand("dbo.News_Delete", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@NewsID", newsID));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        public IDataReader News_Get_List()
        {
            SqlCommand command = new SqlCommand("dbo.News_Get_List", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();

        }

        public IDataReader News_GetByNewsID(int newsID)
        {
            SqlCommand command = new SqlCommand("dbo.News_GetByNewsID", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@NewsID", newsID));
            return command.ExecuteReader();

        }

        public IDataReader News_GetPaged(string whereClause, string orderBy, int pageIndex, int pageSize)
        {
            SqlCommand command = new SqlCommand("dbo.News_GetPaged", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@WhereClause", (whereClause == null) ? System.DBNull.Value : (object)whereClause));
            command.Parameters.Add(new SqlParameter("@OrderBy", (orderBy == null) ? System.DBNull.Value : (object)orderBy));
            command.Parameters.Add(new SqlParameter("@PageIndex", pageIndex));
            command.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            return command.ExecuteReader();

        }

        public int News_Insert(string subject, string newsText, DateTime dateCreated)
        {
            SqlCommand command = new SqlCommand("dbo.News_Insert", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Subject", (subject == null) ? System.DBNull.Value : (object)subject));
            command.Parameters.Add(new SqlParameter("@NewsText", (newsText == null) ? System.DBNull.Value : (object)newsText));
            command.Parameters.Add(new SqlParameter("@DateCreated", (dateCreated == DateTime.MinValue) ? System.DBNull.Value : (object)dateCreated));
            SqlParameter outputParameter = null;
            outputParameter = new SqlParameter("@NewsID", new int());
            outputParameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(outputParameter);
            command.ExecuteNonQuery();
            return (int)outputParameter.Value;

        }

        public bool News_Update(int newsID, string subject, string newsText)
        {
            SqlCommand command = new SqlCommand("dbo.News_Update", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@NewsID", newsID));
            command.Parameters.Add(new SqlParameter("@Subject", (subject == null) ? System.DBNull.Value : (object)subject));
            command.Parameters.Add(new SqlParameter("@NewsText", (newsText == null) ? System.DBNull.Value : (object)newsText));
            return Convert.ToBoolean(command.ExecuteNonQuery());

        }

        public IDataReader NewsItems_Get(string whereClause, string orderBy)
        {
            SqlCommand command = new SqlCommand("dbo.NewsItems_Get", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@WhereClause", (whereClause == null) ? System.DBNull.Value : (object)whereClause));
            command.Parameters.Add(new SqlParameter("@OrderBy", (orderBy == null) ? System.DBNull.Value : (object)orderBy));
            return command.ExecuteReader();

        }

        public IDataReader NewsItems_Get_List()
        {
            SqlCommand command = new SqlCommand("dbo.NewsItems_Get_List", this._connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();

        }

    }
    #endregion
}


