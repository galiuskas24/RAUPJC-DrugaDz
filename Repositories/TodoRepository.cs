using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using GenericListAndEnumerator;

namespace Repositories
{
    /// <summary>
    /// Class that encapsulates all the logic for accessing TodoTtems.
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        /// <summary>
        /// Repository does not fetch todoItems from the actual database, /// it uses in memory storage for this excersise.
        /// </summary>
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator:
            // _inMemoryTodoDatabase = initialDbState ?? new List<TodoItem>(); // x ?? y -> if x is not null, expression returns x. Else y.
        }



        public void Add(TodoItem todoItem)
        {
            if (todoItem == null) throw new ArgumentNullException();
            if (todoItem.Equals(Get(todoItem.Id)))
                throw new DuplicateTodoItemException();

            _inMemoryTodoDatabase.Add(todoItem);
        }

        public TodoItem Get(Guid todoId)
        {
            //return _inMemoryTodoDatabase.FirstOrDefault(i => i.Id == todoId);
            return _inMemoryTodoDatabase.FirstOrDefault(i => i.Id.Equals(todoId));
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => !i.IsCompleted).ToList();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted).ToList();
        }
      
        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            var temp = Get(todoId);
            if (temp == null) return false;

            temp.MarkAsCompleted();
            return temp.IsCompleted;

        }
   
        public bool Remove(Guid todoId)
        {
            if (Get(todoId) == null) return false;
            return _inMemoryTodoDatabase.Remove(Get(todoId));
        }

        public void Update(TodoItem todoItem)
        {
            var temp = Get(todoItem.Id);

            if (temp != null) temp = todoItem;
            else Add(todoItem);

        }
    }

}

