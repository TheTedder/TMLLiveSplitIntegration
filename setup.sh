#!/bin/bash
dotnet restore
dotnet msbuild -t:CopyDlls