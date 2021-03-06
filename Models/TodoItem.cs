﻿using System;
using System.Collections.Generic;

namespace Models
{



    public class TodoItem
    {

        //public Guid Id { get; set; }
        public readonly Guid Id;


        public string Text { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

      

        
        public TodoItem(string text)
        {
            Id = Guid.NewGuid(); 
            Text = text;
            IsCompleted = false;
            DateCreated = DateTime.Now;
        }


        public void MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                DateCompleted = DateTime.Now;
            }

        }


       
        public override bool Equals(object obj)
        {
            var newObj = obj as TodoItem;

            if (newObj == null)
            {
                return false;
            }
            else
            {
                return Id.Equals(newObj.Id);
            }
            
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
