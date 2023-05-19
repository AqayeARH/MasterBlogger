using System;

namespace _01.Framework.Domain
{
    public class BaseDomain<TKey>
    {
        public TKey Id { get; private set; }
        public DateTime CreationDate { get; private set; }

        public BaseDomain()
        {
            CreationDate = DateTime.Now;
        }
    }
}
