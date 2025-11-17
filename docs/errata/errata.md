**Errata** (2 items)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/cs14net10/issues) or email me at markjprice (at) gmail.com.

> **Warning!** Avoid copying and pasting links that break over multiple lines and include hyphens or dashes because your PDF reader might remove a hyphen thinking that it being helpful but break the link! Just click on the links and they will work. Or carefully check that your PDF reader has not removed a hyphen after pasting into your web browser address bar. [See an example of this issue here](https://github.com/markjprice/cs13net9/issues/77).

- [Page 521 - Managing the Northwind sample database with SQLiteStudio, Page 628 - Creating the Northwind database](#page-521---managing-the-northwind-sample-database-with-sqlitestudio-page-628---creating-the-northwind-database)
- [Appendix B - Setting Up Your Development Environment](#appendix-b---setting-up-your-development-environment)
  - [Page 833 - Creating the Northwind sample database locally](#page-833---creating-the-northwind-sample-database-locally)


# Page 521 - Managing the Northwind sample database with SQLiteStudio, Page 628 - Creating the Northwind database

> Thanks to [Amar Jamal](https://github.com/amarjamal) for raising [this issue on November 4, 2025](https://github.com/markjprice/cs13net9/issues/80).

On page 521, in Step 6, I wrote, "You will see the 10 tables..." but there are only 8 tables. For many editions there were 10, but recently I simplified the script to only create 8 tables by removing the unneeded `Territories` and `EmployeeTerritories` tables. 

On page 628, I wrote, "The script for SQLite is a simplified version that only creates 10 tables..." Again, this should be 8 tables. 

# Appendix B - Setting Up Your Development Environment

## Page 833 - Creating the Northwind sample database locally

> Thanks to José Luis García for emailing me about this on November 16, 2025.

In Step 7, `Northwind4SQLServer.sql` should be `Northwind4SqlServerLocal.sql`.
