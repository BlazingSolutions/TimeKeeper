CREATE VIEW [dbo].[TimeEntriesView]
	AS SELECT TimeEntries.Id, TimeEntries.[User], TimeEntries.[Hours], TimeEntries.Notes, TimeEntries.DateCreated, Clients.[Name] AS ClientName, Categories.[Name] AS CategoryName
	FROM TimeEntries
	INNER JOIN Clients ON Clients.Id = TimeEntries.Client
	INNER JOIN Categories ON Categories.Id = TimeEntries.Category
