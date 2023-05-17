using System;

namespace MasterBlogger.Domain.ArticleCategoryAgg.Exceptions
{
    public class AlreadyRecordExistException : Exception
    {
        public AlreadyRecordExistException()
        {

        }

        public AlreadyRecordExistException(string message) : base(message)
        {

        }
    }
}
