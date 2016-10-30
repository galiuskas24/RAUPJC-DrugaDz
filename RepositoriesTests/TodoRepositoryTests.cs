using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Repositories;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Tests
{
    [TestClass]
    public class TodoRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullToDatabaseThrowsException()
        {
            ITodoRepository repository = new TodoRepository();
            repository.Add(null);
        }

        [TestMethod]
        public void AddingItemWillAddToDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddingExistingItemWillThrowException()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);
            repository.Add(todoItem);
        }

        //-------------------------------------------------------



        [TestMethod]
        public void GetItemFromEmptyDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var temp = new TodoItem("Hello!");

            Assert.AreNotEqual(temp, repository.Get(temp.Id));
            Assert.IsNull(repository.Get(temp.Id));
        }

        [TestMethod]
        public void GetItemFromDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var temp = new TodoItem("Hello!");
            repository.Add(temp);

            Assert.AreEqual(temp, repository.Get(temp.Id));
        }


        [TestMethod]
        public void RemoveFromEmptyDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            Assert.IsFalse(repository.Remove(Guid.NewGuid()));
            Assert.AreEqual(0, repository.GetAll().Count);
        }



        [TestMethod]
        public void RemoveFromDatabaseTest()
        {
            ITodoRepository repository = new TodoRepository();
            var item = new TodoItem("Hello!");
            repository.Add(item);

            Assert.AreEqual(1, repository.GetAll().Count);
            repository.Remove(item.Id);

            Assert.AreEqual(0, repository.GetAll().Count);
            Assert.AreNotEqual(item, repository.Get(item.Id));
            Assert.IsNull(repository.Get(item.Id));
        }



        [TestMethod]
        public void GetActiveTest()
        {
            ITodoRepository repository = new TodoRepository();
            var temp1 = new TodoItem("Hello");
            var temp2 = new TodoItem("World!");

            temp2.MarkAsCompleted();
            repository.Add(temp1);
            repository.Add(temp2);

            Assert.AreEqual(1, repository.GetActive().Count);
            repository.Remove(temp1.Id);
            temp1.MarkAsCompleted();
            repository.Add(temp1);
            Assert.AreEqual(0, repository.GetActive().Count);
        }

        [TestMethod]
        public void MarkingAsCompletedTest()
        {
            var temp1 = new TodoItem("Hello");
            var temp2 = new TodoItem("Byyyy!");
            temp1.MarkAsCompleted();

            Assert.IsTrue(temp1.IsCompleted);
            Assert.IsFalse(temp2.IsCompleted);

        }

        [TestMethod]
        public void GetAllTest()
        {
            ITodoRepository repository = new TodoRepository();
            var temp1 = new TodoItem("Hello");
            var temp2 = new TodoItem("It's me");
            var temp3 = new TodoItem("Hay!");

            repository.Add(temp1);
            repository.Add(temp2);
            repository.Add(temp3);

            Assert.AreEqual(3, repository.GetAll().Count);
        }

        [TestMethod]
        public void GetCompletTest()
        {
            ITodoRepository repository = new TodoRepository();
            var temp1 = new TodoItem("Hy");
            var temp2 = new TodoItem("Heey");
            temp1.MarkAsCompleted();

            repository.Add(temp1);
            repository.Add(temp2);
            Assert.AreEqual(1, repository.GetCompleted().Count);
        }

        [TestMethod]
        public void GetFilteredTest()
        {
            ITodoRepository repository = new TodoRepository();
            var temp1 = new TodoItem("Hello");
            var temp2 = new TodoItem("Byyyy!");
            var temp3 = new TodoItem("Hay!");

            repository.Add(temp1);
            repository.Add(temp2);
            repository.Add(temp3);

            Assert.AreEqual(3, repository.GetAll().Count);

            Assert.AreEqual(2, repository.GetFiltered(m => m.Text.Length > 4).Count);
            Assert.AreEqual(1, repository.GetFiltered(m => m.Text.Length <= 4).Count);
            Assert.AreEqual("Hay!", repository.GetFiltered(m => m.Text.Length <= 4).First().Text);

        }


        [TestMethod]
        public void UpdateTest()
        {
            ITodoRepository repository = new TodoRepository();
            var temp = new TodoItem("waaap");

            repository.Add(temp);
            Assert.AreEqual(1, repository.GetAll().Count);
            temp.MarkAsCompleted();
            temp.Text = "new";
            repository.Update(temp);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.AreEqual(temp, repository.GetAll().First());
            repository.Update(new TodoItem("caooo"));
            Assert.AreEqual(2, repository.GetAll().Count);
        }





    }
   
}