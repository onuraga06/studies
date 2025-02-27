﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperApp.Library1.Models;

namespace DapperApp.Library1.Queries
{
    public class PersonQueries : ConnectionFactory, IPersonQueries
    {
        public List<Person> GetPersons()
        {
            List<Person> persons = null;

            RunCommand((connection) =>
            {
                persons = connection.Query<Person>("select * from Persons").ToList();
            });

            return persons;
        }

        public void CreatePerson(Person person)
        {
            RunCommand((connection) =>
            {
                var insertedId = connection.ExecuteScalar<int>(@"insert into Persons values (@name,@surname) select SCOPE_IDENTITY()",
                    new
                    {
                        name = person.Name,
                        surname = person.Surname
                    });

                person.Id = insertedId;
            });
        }

        public Person Get(int id)
        {
            Person person = null;
            RunCommand((connection) =>
            {
                person = connection.QueryFirstOrDefault<Person>("select * from Persons where Id = @id", new { id });
            });

            return person;
        }

        public void Delete(int id)
        {
            //Check used modules
            RunCommand((connection) =>
            {
                connection.Execute("delete from Persons where Id = @id", new { id });
            });
        }
        public void UpdatePerson(Person person)
        {
            RunCommand((connection) =>
            {
                connection.Execute("UPDATE Persons SET Name=@Name,SurName=@Surname Where Id=@Id", person);
            });



        }

        public List<Person> Filter(string filter)
        {
            List<Person> persons = null;
            RunCommand((connection) =>
            {
                persons = connection.Query<Person>("select * from Persons  where Name LIKE CONCAT('%',@name,'%')", new { @name = filter }).ToList();
            });
            return persons;
        }
    }
}
