﻿using DapperApp.Library1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperApp.Library1.Queries
{
    public interface IPersonQueries
    {
        List<Person> GetPersons();
        void CreatePerson(Person person);
        Person Get(int id);
        void Delete(int id);
        void UpdatePerson(Person person);
        List<Person> Filter(string filter);
    }
}
