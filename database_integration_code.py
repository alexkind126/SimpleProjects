# pentru al doulea test. am utilizat, chat GPT. unealta mea preferata, that I use for my daily activities. 
# nu am reusit sa testez

import sqlite3
from datetime import datetime, timedelta

# Connect to the database
conn = sqlite3.connect('database.db')
c = conn.cursor()

# Calculate the start and end dates for last year
today = datetime.today()
last_year_end = datetime(today.year - 1, 12, 31)
last_year_start = last_year_end - timedelta(days=365)

# Execute the query to retrieve valid votes and person information, grouped by location and person
c.execute('SELECT p.Locatie, p.First_Name, p.Last_Name, COUNT(v.quality) AS quality_count, strftime("%m", v.voting_date) AS month, ((strftime("%m", v.voting_date) - 1) / 3) + 1 AS quarter FROM votes v JOIN persons p ON v.chosen_person = p.ID WHERE v.valid = "true" AND v.voting_date BETWEEN ? AND ? GROUP BY p.Locatie, p.First_Name, p.Last_Name, month, quarter', (last_year_start, last_year_end))

# Retrieve the query results
results = c.fetchall()

# Print the report by month
print('Location\tFirst Name\tLast Name\tMonth\tQuality Count')
for row in results:
    print(f'{row[0]}\t{row[1]}\t\t{row[2]}\t\t{row[4]}\t{row[3]}')

# Print the report by quarter
print('\nLocation\tFirst Name\tLast Name\tQuarter\tQuality Count')
for row in results:
    print(f'{row[0]}\t{row[1]}\t\t{row[2]}\t\t{row[5]}\t{row[3]}')

# Calculate the total quality count for last year
total_count = sum(row[3] for row in results)

# Print the total quality count for last year
print(f'\nTotal last year quality count: {total_count}')

# Close the database connection
conn.close()
