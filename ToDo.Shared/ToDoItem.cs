using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public class ToDoItem
    {
        public ToDoItem(string name)
        {
            Name = name;
        }

        public bool Done { get; set; }
        public string Name { get; }
    }
}
