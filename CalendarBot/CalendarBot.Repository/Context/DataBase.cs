using System;
using System.Collections.Generic;
using CalendarBot.Domain.Entities;

namespace CalendarBot.Repository.Context
{
    public class DataBase
    {
        public Dictionary<string, CalendarOfEvents> Storage;

        public DataBase()
        {
            if (Storage != null)
            {
                return;
            }

            Storage = new Dictionary<string, CalendarOfEvents>();

            if (Storage.ContainsKey("System-Holiday"))
            {
                return;
            }

            var holidayCalendar = new CalendarOfEvents
            {
                Events = new List<EventScheduled>
                {
                    new EventScheduled
                    {
                        Id = 0,
                        Title = "Tiradentes",
                        StartDate = new DateTime(2018, 4, 21, 00, 00, 00),
                        EndDate = new DateTime(2018, 4, 21, 23, 59, 00),
                    },
                    new EventScheduled
                    {
                        Id = 1,
                        Title = "Descobrimento do Brasil",
                        StartDate = new DateTime(2018, 4, 22, 00, 00, 00),
                        EndDate = new DateTime(2018, 4, 22, 23, 59, 00),
                    },
                    new EventScheduled
                    {
                        Id = 2,
                        Title = "Dia do Trabalhador",
                        StartDate = new DateTime(2018, 5, 1, 00, 00, 00),
                        EndDate = new DateTime(2018, 5, 1, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 3,
                        Title = "Dia das Mães",
                        StartDate = new DateTime(2018, 5, 13, 00, 00, 00),
                        EndDate = new DateTime(2018, 5, 13, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 4,
                        Title = "Corpus Christi",
                        StartDate = new DateTime(2018, 5, 31, 00, 00, 00),
                        EndDate = new DateTime(2018, 5, 31, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 5,
                        Title = "Corpus Christi",
                        StartDate = new DateTime(2018, 5, 31, 00, 00, 00),
                        EndDate = new DateTime(2018, 5, 31, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 6,
                        Title = "Dia dos Namorados",
                        StartDate = new DateTime(2018, 6, 12, 00, 00, 00),
                        EndDate = new DateTime(2018, 6, 12, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 7,
                        Title = "Dia de São João",
                        StartDate = new DateTime(2018, 6, 24, 00, 00, 00),
                        EndDate = new DateTime(2018, 6, 24, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 8,
                        Title = "Dia do Amigo e Internacional da Amizade",
                        StartDate = new DateTime(2018, 7, 24, 00, 00, 00),
                        EndDate = new DateTime(2018, 7, 24, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 9,
                        Title = "Dia dos Pais",
                        StartDate = new DateTime(2018, 8, 12, 00, 00, 00),
                        EndDate = new DateTime(2018, 8, 12, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 10,
                        Title = "Dia da Independência do Brasil - 7 de Setembro",
                        StartDate = new DateTime(2018, 9, 7, 00, 00, 00),
                        EndDate = new DateTime(2018, 9, 7, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 11,
                        Title = "Dia das Crianças",
                        StartDate = new DateTime(2018, 10, 12, 00, 00, 00),
                        EndDate = new DateTime(2018, 10, 12, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 12,
                        Title = "Dia do Professor",
                        StartDate = new DateTime(2018, 10, 15, 00, 00, 00),
                        EndDate = new DateTime(2018, 10, 15, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 13,
                        Title = "Finados",
                        StartDate = new DateTime(2018, 11, 2, 00, 00, 00),
                        EndDate = new DateTime(2018, 11, 2, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 14,
                        Title = "Proclamação da República",
                        StartDate = new DateTime(2018, 11, 15, 00, 00, 00),
                        EndDate = new DateTime(2018, 11, 15, 23, 59, 00),
                    },
                    new EventScheduled()
                    {
                        Id = 15,
                        Title = "Natal",
                        StartDate = new DateTime(2018, 12, 25, 00, 00, 00),
                        EndDate = new DateTime(2018, 12, 25, 23, 59, 00),
                    }

                },
                OwnerUserName = "System-Holiday",
                AlarmSetUp = false,
            };
            Storage.Add("System-Holiday", holidayCalendar);
        }
    }
}
