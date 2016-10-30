using System;

namespace Repositories
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException() : base("Item with the same ID already exist!")
        {
        }

    }
}