#!/bin/bash
if [ "$1" == "" ]; then
    echo "Please provide a migration name"
    exit 1
fi
dotnet ef migrations add $1
dotnet ef database update