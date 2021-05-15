using Dapper.QX.Abstract;
using Dapper.QX.Attributes;
using Dapper.QX.Interfaces;
using System;
using System.Collections.Generic;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Repository.Queries
{
    public class TimeEntriesQuery : TestableQuery<TimeEntriesView>
    {
        public TimeEntriesQuery() : base(
            @"SELECT * 
            FROM [TimeEntriesView] {where} 
            ORDER BY [DateCreated] DESC")
        {
        }

        [Where("[User]=@user")]
        public int? User { get; set; }

        [Where("CAST(DateCreated As date) = CAST(@selectedDate As date)")]
        public DateTime? SelectedDate { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new TimeEntriesQuery() { User = 1 };
            yield return new TimeEntriesQuery() { SelectedDate = DateTime.Today };
        }
    }
}
