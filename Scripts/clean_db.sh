#!/bin/bash
rm storywriter.db
rm -r Migrations
dotnet ef migrations add InitialCreate
dotnet ef database update