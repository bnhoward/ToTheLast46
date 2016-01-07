using System;
using System.Collections.Generic;
using System.Text;

namespace Nightjar.ToTheLast.Entities
{
    public interface IGig
    {
        int GigID { get;}
        string Description { get;}
        string Venue { get;}
        DateTime StartDateTime { get;}
    }

    public interface IGuestbook
    {
        int GuestbookID { get;}
        string Name { get;}
        string Email { get;}
        string Comment { get;}
        string Reply { get;}
        bool Display { get;}
        DateTime DateCreated { get;}
    }

    public interface INews
    {
        int NewsID { get;}
        string Subject { get;}
        string NewsText { get;}
        DateTime DateCreated { get;}
    }

    public interface ILink
    {
        int LinkID { get;}
        string URL { get;}
        string Title { get;}
        string Note { get;}
        int SortOrder { get;}
    }

    public interface IImage
    {
        int ImageID { get;}
        string Filename { get;}
        string Title { get;}
        int GalleryID { get;}
    }

    public interface IGallery
    {
        int GalleryID { get;}
        string Name { get;}
        string Description { get;}
        int SortOrder { get;}
        string DisplayImage { get;}
    }

    public interface IProfile
    {
        int ProfileID { get;}
        string Name { get;}
        string ProfileText { get;}
        string ImageName { get;}
        bool ImageExists { get;}
        int SortOrder{ get;}
    }
}
