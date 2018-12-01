CREATE TABLE [dbo].[Table]
(
	[user_id] INT NOT NULL PRIMARY KEY, 
    [symbol] VARCHAR(30) NOT NULL, 
    [last_price] VARCHAR(30) NOT NULL, 
    [change] VARCHAR(30) NOT NULL, 
    [percent_change] VARCHAR(30) NOT NULL, 
    [currency] VARCHAR(30) NOT NULL, 
    [market_time] VARCHAR(30) NOT NULL, 
    [volume] VARCHAR(30) NOT NULL, 
    [avg_volume] VARCHAR(30) NOT NULL, 
    [scrape_time] DATETIME NOT NULL
)
