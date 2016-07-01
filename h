[33mcommit 20832ec4425bcd2f4bb7d09d764d63aa1994a992[m
Author: Hristo Dobrev <hristo.nankov1@gmail.com>
Date:   Tue Feb 2 00:10:59 2016 +0200

    Uploading latest homeworks and exercises

[1mdiff --git a/High Quality Code/Homeworks/15. SOLID Principles.zip b/High Quality Code/Homeworks/15. SOLID Principles.zip[m
[1mnew file mode 100644[m
[1mindex 0000000..3f3e8a2[m
Binary files /dev/null and b/High Quality Code/Homeworks/15. SOLID Principles.zip differ
[1mdiff --git a/High Quality Code/Homeworks/17. Refactoring/Matrica.cs b/High Quality Code/Homeworks/17. Refactoring/Matrica.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..d00c999[m
[1m--- /dev/null[m
[1m+++ b/High Quality Code/Homeworks/17. Refactoring/Matrica.cs[m	
[36m@@ -0,0 +1,178 @@[m
[32m+[m[32m﻿namespace GameFifteen[m
[32m+[m[32m{[m
[32m+[m[32m    using System;[m
[32m+[m[32m    using System.IO;[m
[32m+[m[32m    using System.Text;[m
[32m+[m
[32m+[m[32m    class Matrix[m
[32m+[m[32m    {[m
[32m+[m[32m        static void Main(string[] args)[m
[32m+[m[32m        {[m
[32m+[m[32m            int size = GetInput();[m
[32m+[m
[32m+[m[32m            int[,] matrix = new int[size, size];[m
[32m+[m[32m            int value = 1;[m
[32m+[m[32m            int y = 0;[m
[32m+[m[32m            int x = 0;[m
[32m+[m[32m            int directionX = 1;[m
[32m+[m[32m            int directionY = 1;[m
[32m+[m
[32m+[m[32m            IterateMatrix(matrix, y, x, ref value, directionX, size, directionY);[m
[32m+[m
[32m+[m[32m            value++;[m
[32m+[m[32m            FindCell(matrix, out y, out x);[m
[32m+[m
[32m+[m[32m            // Swap sides of matrix when the right side is filled[m
[32m+[m[32m            if (x != 0 && y != 0)[m
[32m+[m[32m            {[m
[32m+[m[32m                directionX = 1;[m
[32m+[m[32m                directionY = 1;[m
[32m+[m[32m                IterateMatrix(matrix, y, x, ref value, directionX, size, directionY);[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            string result = GetResult(matrix);[m
[32m+[m[32m            Console.WriteLine(result);[m
[32m+[m
[32m+[m[32m            WriteTestsOnFile(size, result);[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public static void WriteTestsOnFile(int input, string output)[m
[32m+[m[32m        {[m
[32m+[m[32m            using (var writer = new StreamWriter("../../tests.txt", true))[m
[32m+[m[32m            {[m
[32m+[m[32m                writer.WriteLine("Input: " + input);[m
[32m+[m[32m                writer.WriteLine("Output:");[m
[32m+[m[32m                writer.WriteLine(output);[m
[32m+[m[32m                writer.WriteLine(new string('-', 30));[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public static int GetInput()[m
[32m+[m[32m        {[m
[32m+[m[32m            Console.WriteLine("Enter a positive number ");[m
[32m+[m[32m            string input = Console.ReadLine();[m
[32m+[m
[32m+[m[32m            int result = 0;[m
[32m+[m[32m            while (!int.TryParse(input, out result) || result < 0 || result > 100)[m
[32m+[m[32m            {[m
[32m+[m[32m                Console.WriteLine("You haven't entered a correct positive number");[m
[32m+[m[32m                input = Console.ReadLine();[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            return result;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        public static string GetResult(int[,] matrix)[m
[32m+[m[32m        {[m
[32m+[m[32m            StringBuilder result = new StringBuilder();[m
[32m+[m[32m            int size = matrix.GetLength(0);[m
[32m+[m[32m            for (int row = 0; row < size; row++)[m
[32m+[m[32m            {[m
[32m+[m[32m                for (int col = 0; col < size; col++)[m
[32m+[m[32m                {[m
[32m+[m[32m                    result.AppendFormat("{0,3}", matrix[row, col]);[m
[32m+[m[32m                }[m
[32m+[m[32m                result.AppendLine();[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            return result.ToString();[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        private static void IterateMatrix(int[,] matrix, int y, int x, ref int value, int directionX, int n, int directionY)[m
[32m+[m[32m        {[m
[32m+[m[32m            while (true)[m
[32m+[m[32m            {[m
[32m+[m[32m                matrix[y, x] = value;[m
[32m+[m
[32m+[m[32m                if (!Check(matrix, y, x))[m
[32m+[m[32m                {[m
[32m+[m[32m                    break;[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                if (y + directionX >= n || y + directionX < 0 || x + directionY >= n || x + directionY < 0 ||[m
[32m+[m[32m                    matrix[y + directionX, x + directionY] != 0)[m
[32m+[m[32m                {[m
[32m+[m[32m                    while (y + directionX >= n || y + directionX < 0 || x + directionY >= n || x + directionY < 0 ||[m
[32m+[m[32m                           matrix[y + directionX, x + directionY] != 0)[m
[32m+[m[32m                    {[m
[32m+[m[32m                        ChangeDirection(matrix, ref directionY, ref directionX);[m
[32m+[m[32m                    }[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                y += directionX;[m
[32m+[m[32m                x += directionY;[m
[32m+[m[32m                value++;[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        private static void ChangeDirection(int[,] matrix, ref int dy, ref int dx)[m
[32m+[m[32m        {[m
[32m+[m[32m            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };[m
[32m+[m[32m            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };[m
[32m+[m
[32m+[m[32m            int cd = 0;[m
[32m+[m[32m            for (int count = 0; count < 8; count++)[m
[32m+[m[32m            {[m
[32m+[m[32m                if (dirY[count] == dy && dirX[count] == dx)[m
[32m+[m[32m                {[m
[32m+[m[32m                    cd = count;[m
[32m+[m[32m                    break;[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            if (cd == 7)[m
[32m+[m[32m            {[m
[32m+[m[32m                dy = dirY[0];[m
[32m+[m[32m                dx = dirX[0];[m
[32m+[m[32m                return;[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            dy = dirY[cd + 1];[m
[32m+[m[32m            dx = dirX[cd + 1];[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        private static bool Check(int[,] arr, int y, int x)[m
[32m+[m[32m        {[m
[32m+[m[32m            int[] dirY = { 1, 1, 1, 0, -1, -1, -1, 0 };[m
[32m+[m[32m            int[] dirX = { 1, 0, -1, -1, -1, 0, 1, 1 };[m
[32m+[m
[32m+[m[32m            for (int i = 0; i < 8; i++)[m
[32m+[m[32m            {[m
[32m+[m[32m                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)[m
[32m+[m[32m                {[m
[32m+[m[32m                    dirY[i] = 0;[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)[m
[32m+[m[32m                {[m
[32m+[m[32m                    dirX[i] = 0;[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                if (arr[y + dirY[i], x + dirX[i]] == 0)[m
[32m+[m[32m                {[m
[32m+[m[32m                    return true;[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            return false;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        private static void FindCell(int[,] arr, out int y, out int x)[m
[32m+[m[32m        {[m
[32m+[m[32m            x = 0;[m
[32m+[m[32m            y = 0;[m
[32m+[m[32m            for (int currentY = 0; currentY < arr.GetLength(0); currentY++)[m
[32m+[m[32m            {[m
[32m+[m[32m                for (int currentX = 0; currentX < arr.GetLength(0); currentX++)[m
[32m+[m[32m                {[m
[32m+[m[32m                    if (arr[currentY, currentX] == 0)[m
[32m+[m[32m                    {[m
[32m+[m[32m                        y = currentY;[m
[32m+[m[32m                        x = currentX;[m
[32m+[m[32m                        return;[m
[32m+[m[32m                    }[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[1mdiff --git a/High Quality Code/Homeworks/17. Refactoring/Matrica.csproj b/High Quality Code/Homeworks/17. Refactoring/Matrica.csproj[m
[1mnew file mode 100644[m
[1mindex 0000000..2156300[m
[1m--- /dev/null[m
[1m+++ b/High Quality Code/Homeworks/17. Refactoring/Matrica.csproj[m	
[36m@@ -0,0 +1,50 @@[m
[32m+[m[32m﻿<?xml version="1.0" encoding="utf-8"?>[m
[32m+[m[32m<Project ToolsVersion="4.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">[m
[32m+[m[32m  <PropertyGroup>[m
[32m+[m[32m    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>[m
[32m+[m[32m    <Platform Condition=" '$(Platform)' == '' ">x86</Platform>[m
[32m+[m[32m    <ProductVersion>8.0.30703</ProductVersion>[m
[32m+[m[32m    <SchemaVersion>2.0</SchemaVersion>[m
[32m+[m[32m    <ProjectGuid>{4D520899-7061-4EAA-B67E-D14EE8B30462}</ProjectGuid>[m
[32m+[m[32m    <OutputType>Exe</OutputType>[m
[32m+[m[32m    <RootNamespace>GameFifteen</RootNamespace>[m
[32m+[m[32m    <AssemblyName>GameFifteen</AssemblyName>[m
[32m+[m[32m    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>[m
[32m+[m[32m    <TargetFrameworkProfile>Client</TargetFrameworkProfile>[m
[32m+[m[32m    <FileAlignment>512</FileAlignment>[m
[32m+[m[32m  </PropertyGroup>[m
[32m+[m[32m  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|x86' ">[m
[32m+[m[32m    <PlatformTarget>x86</PlatformTarget>[m
[32m+[m[32m    <DebugSymbols>true</DebugSymbols>[m
[32m+[m[32m    <DebugType>full</DebugType>[m
[32m+[m[32m    <Optimize>false</Optimize>[m
[32m+[m[32m    <OutputPath>bin\Debug\</OutputPath>[m
[32m+[m[32m    <DefineConstants>DEBUG;TRACE</DefineConstants>[m
[32m+[m[32m    <ErrorReport>prompt</ErrorReport>[m
[32m+[m[32m    <WarningLevel>4</WarningLevel>[m
[32m+[m[32m  </PropertyGroup>[m
[32m+[m[32m  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|x86' ">[m
[32m+[m[32m    <PlatformTarget>x86</PlatformTarget>[m
[32m+[m[32m    <DebugType>pdbonly</DebugType>[m
[32m+[m[32m    <Optimize>true</Optimize>[m
[32m+[m[32m    <OutputPath>bin\Release\</OutputPath>[m
[32m+[m[32m    <DefineConstants>TRACE</DefineConstants>[m
[32m+[m[32m    <ErrorReport>prompt</ErrorReport>[m
[32m+[m[32m    <WarningLevel>4</WarningLevel>[m
[32m+[m[32m  </PropertyGroup>[m
[32m+[m[32m  <ItemGroup>[m
[32m+[m[32m    <Reference Include="System" />[m
[32m+[m[32m    <Reference Include="System.Core" />[m
[32m+[m[32m  </ItemGroup>[m
[32m+[m[32m  <ItemGroup>[m
[32m+[m[32m    <Compile Include="Matrica.cs" />[m
[32m+[m[32m  </ItemGroup>[m
[32m+[m[32m  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />[m
[32m+[m[32m  <!-- To modify your build process, add your task inside one of the targets below and uncomment it.[m[41m [m
[32m+[m[32m       Other similar extension points exist, see Microsoft.Common.targets.[m
[32m+[m[32m  <Target Name="BeforeBuild">[m
[32m+[m[32m  </Target>[m
[32m+[m[32m  <Target Name="AfterBuild">[m
[32m+[m[32m  </Target>[m
[32m+[m[32m  -->[m
[32m+[m[32m</Project>[m
\ No newline at end of file[m
[1mdiff --git a/High Quality Code/Homeworks/17. Refactoring/Matrica.sln b/High Quality Code/Homeworks/17. Refactoring/Matrica.sln[m
[1mnew file mode 100644[m
[1mindex 0000000..fde680e[m
[1m--- /dev/null[m
[1m+++ b/High Quality Code/Homeworks/17. Refactoring/Matrica.sln[m	
[36m@@ -0,0 +1,20 @@[m
[32m+[m[32m﻿[m
[32m+[m[32mMicrosoft Visual Studio Solution File, Format Version 12.00[m
[32m+[m[32m# Visual Studio 2012[m
[32m+[m[32mProject("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "Matrica", "Matrica.csproj", "{4D520899-7061-4EAA-B67E-D14EE8B30462}"[m
[32m+[m[32mEndProject[m
[32m+[m[32mGlobal[m
[32m+[m	[32mGlobalSection(SolutionConfigurationPlatforms) = preSolution[m
[32m+[m		[32mDebug|x86 = Debug|x86[m
[32m+[m		[32mRelease|x86 = Release|x86[m
[32m+[m	[32mEndGlobalSection[m
[32m+[m	[32mGlobalSection(ProjectConfigurationPlatforms) = postSolution[m
[32m+[m		[32m{4D520899-7061-4EAA-B67E-D14EE8B30462}.Debug|x86.ActiveCfg = Debug|x86[m
[32m+[m		[32m{4D520899-7061-4EAA-B67E-D14EE8B30462}.Debug|x86.Build.0 = Debug|x86[m
[32m+[m		[32m{4D520899-7061-4EAA-B67E-D14EE8B30462}.Release|x86.ActiveCfg = Release|x86[m
[32m+[m		[32m{4D520899-7061-4EAA-B67E-D14EE8B30462}.Release|x86.Build.0 = Release|x86[m
[32m+[m	[32mEndGlobalSection[m
[32m+[m	[32mGlobalSection(SolutionProperties) = preSolution[m
[32m+[m		[32mHideSolutionNode = FALSE[m
[32m+[m	[32mEndGlobalSection[m
[32m+[m[32mEndGlobal[m
[1mdiff --git a/High Quality Code/Homeworks/17. Refactoring/Matrix.cs b/High Quality Code/Homeworks/17. Refactoring/Matrix.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..74e02ee[m
[1m--- /dev/null[m
[1m+++ b/High Quality Code/Homeworks/17. Refactoring/Matrix.cs[m	
[36m@@ -0,0 +1,165 @@[m
[32m+[m[32m﻿using System;[m
[32m+[m
[32m+[m[32mnamespace Task3[m
[32m+[m[32m{[m
[32m+[m[32m    internal class Matrix[m
[32m+[m[32m    {[m
[32m+[m[32m        private static void Change(ref int dX, ref int dY)[m
[32m+[m[32m        {[m
[32m+[m[32m            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };[m
[32m+[m[32m            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };[m
[32m+[m[32m            int cd = 0;[m
[32m+[m[32m            for (int count = 0; count < 8; count++)[m
[32m+[m[32m            {[m
[32m+[m[32m                if (directionsX[count] == dX && directionsY[count] == dY)[m
[32m+[m[32m                {[m
[32m+[m[32m                    cd = count;[m
[32m+[m[32m                    break;[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            if (cd == 7)[m
[32m+[m[32m            {[m
[32m+[m[32m                dX = directionsX[0];[m
[32m+[m[32m                dY = directionsY[0];[m
[32m+[m[32m                return;[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            dX = directionsX[cd + 1];[m
[32m+[m[32m            dY = directionsY[cd + 1];[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        private static bool CheckCell(int[,] arr, int x, int y)[m
[32m+[m[32m        {[m
[32m+[m[32m            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };[m
[32m+[m[32m            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };[m
[32m+[m[32m            for (int i = 0; i < 8; i++)[m
[32m+[m[32m            {[m
[32m+[m[32m                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)[m
[32m+[m[32m                {[m
[32m+[m[32m                    dirX[i] = 0;[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)[m
[32m+[m[32m                {[m
[32m+[m[32m                    dirY[i] = 0;[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            for (int i = 0; i < 8; i++)[m
[32m+[m[32m            {[m
[32m+[m[32m                if (arr[x + dirX[i], y + dirY[i]] == 0)[m
[32m+[m[32m                {[m
[32m+[m[32m                    return true;[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            return false;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        private static void FindCell(int[,] arr, out int x, out int y)[m
[32m+[m[32m        {[m
[32m+[m[32m            x = 0;[m
[32m+[m[32m            y = 0;[m
[32m+[m[32m            for (int row = 0; row < arr.GetLength(0); row++)[m
[32m+[m[32m            {[m
[32m+[m[32m                for (int col = 0; col < arr.GetLength(0); col++)[m
[32m+[m[32m                {[m
[32m+[m[32m                    if (arr[row, col] == 0)[m
[32m+[m[32m                    {[m
[32m+[m[32m                        x = row;[m
[32m+[m[32m                        y = col;[m
[32m+[m[32m                        return;[m
[32m+[m[32m                    }[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        private static void Main(string[] args)[m
[32m+[m[32m        {[m
[32m+[m[32m            Console.WriteLine("Enter a positive number ");[m
[32m+[m[32m            string input = Console.ReadLine();[m
[32m+[m[32m            int number;[m
[32m+[m[32m            while (!int.TryParse(input, out number) || number < 0 || number > 100)[m
[32m+[m[32m            {[m
[32m+[m[32m                Console.WriteLine("You haven't entered a correct positive number");[m
[32m+[m[32m                input = Console.ReadLine();[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            int[,] matrix = new int[number, number];[m
[32m+[m[32m            int step = number;[m
[32m+[m[32m            int value = 1;[m
[32m+[m[32m            int row = 0;[m
[32m+[m[32m            int col = 0;[m
[32m+[m[32m            int directionX = 1;[m
[32m+[m[32m            int directionY = 1;[m
[32m+[m[32m            while (true)[m
[32m+[m[32m            {[m
[32m+[m[32m                // malko e kofti tova uslovie, no break-a raboti 100% : )[m
[32m+[m[32m                matrix[row, col] = value;[m
[32m+[m
[32m+[m[32m                if (!CheckCell(matrix, row, col))[m
[32m+[m[32m                {[m
[32m+[m[32m                    break;[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                // prekusvame ako sme se zadunili[m
[32m+[m[32m                bool outOfBoundaries =[m[41m [m
[32m+[m[32m                    row + directionX >= number ||  // out from right side[m
[32m+[m[32m                    row + directionX < 0 ||        // out from left side[m
[32m+[m[32m                    col + directionY >= number ||  // out from top side[m
[32m+[m[32m                    col + directionY < 0 ||        // out from bottom side[m
[32m+[m[32m                    matrix[row + directionX, col + directionY] != 0;[m
[32m+[m
[32m+[m[32m                while (row + directionX >= number || row + directionX < 0 || col + directionY >= number || col + directionY < 0 || matrix[row + directionX, col + directionY] != 0)[m
[32m+[m[32m                {[m
[32m+[m[32m                    Change(ref directionX, ref directionY);[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                row += directionX;[m
[32m+[m[32m                col += directionY;[m
[32m+[m[32m                value++;[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            FindCell(matrix, out row, out col);[m
[32m+[m[32m            if (row != 0 && col != 0)[m
[32m+[m[32m            {[m
[32m+[m[32m                // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite[m
[32m+[m[32m                directionX = 1;[m
[32m+[m[32m                directionY = 1;[m
[32m+[m
[32m+[m[32m                while (true)[m
[32m+[m[32m                {[m
[32m+[m[32m                    // malko e kofti tova uslovie, no break-a raboti 100% : )[m
[32m+[m[32m                    matrix[row, col] = value;[m
[32m+[m[32m                    if (!CheckCell(matrix, row, col))[m
[32m+[m[32m                    {[m
[32m+[m[32m                        break;[m
[32m+[m[32m                    }[m
[32m+[m[32m                    // prekusvame ako sme se zadunili[m
[32m+[m[32m                    if (row + directionX >= number || row + directionX < 0 || col + directionY >= number || col + directionY < 0 || matrix[row + directionX, col + directionY] != 0)[m
[32m+[m[32m                    {[m
[32m+[m[32m                        while (row + directionX >= number || row + directionX < 0 || col + directionY >= number || col + directionY < 0 || matrix[row + directionX, col + directionY] != 0)[m
[32m+[m[32m                        {[m
[32m+[m[32m                            Change(ref directionX, ref directionY);[m
[32m+[m[32m                        }[m
[32m+[m[32m                    }[m
[32m+[m
[32m+[m[32m                    row += directionX;[m
[32m+[m[32m                    col += directionY;[m
[32m+[m[32m                    value++;[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            for (int pp = 0; pp < number; pp++)[m
[32m+[m[32m            {[m
[32m+[m[32m                for (int qq = 0; qq < number; qq++)[m
[32m+[m[32m                {[m
[32m+[m[32m                    Console.Write("{0,3}", matrix[pp, qq]);[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                Console.WriteLine();[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/High Quality Code/Homeworks/17. Refactoring/tests.txt b/High Quality Code/Homeworks/17. Refactoring/tests.txt[m
[1mnew file mode 100644[m
[1mindex 0000000..d584864[m
[1m--- /dev/null[m
[1m+++ b/High Quality Code/Homeworks/17. Refactoring/tests.txt[m	
[36m@@ -0,0 +1,95 @@[m
[32m+[m[32mInput: 1[m
[32m+[m[32mOutput:[m
[32m+[m[32m  1[m
[32m+[m
[32m+[m[32m------------------------------[m
[32m+[m[32mInput: 2[m
[32m+[m[32mOutput:[m
[32m+[m[32m  1  4[m
[32m+[m[32m  3  2[m
[32m+[m
[32m+[m[32m------------------------------[m
[32m+[m[32mInput: 3[m
[32m+[m[32mOutput:[m
[32m+[m[32m  1  7  8[m
[32m+[m[32m  6  2  9[m
[32m+[m[32m  5  4  3[m
[32m+[m
[32m+[m[32m------------------------------[m
[32m+[m[32mInput: 4[m
[32m+[m[32mOutput:[m
[32m+[m[32m  1 10 11 12[m
[32m+[m[32m  9  2 15 13[m
[32m+[m[32m  8 16  3 14[m
[32m+[m[32m  7  6  5  4[m
[32m+[m
[32m+[m[32m------------------------------[m
[32m+[m[32mInput: 5[m
[32m+[m[32mOutput:[m
[32m+[m[32m  1 13 14 15 16[m
[32m+[m[32m 12  2 21 22 17[m
[32m+[m[32m 11 23  3 20 18[m
[32m+[m[32m 10 25 24  4 19[m
[32m+[m[32m  9  8  7  6  5[m
[32m+[m
[32m+[m[32m------------------------------[m
[32m+[m[32mInput: 6[m
[32m+[m[32mOutput:[m
[32m+[m[32m  1 16 17 18 19 20[m
[32m+[m[32m 15  2 27 28 29 21[m
[32m+[m[32m 14 31  3 26 30 22[m
[32m+[m[32m 13 36 32  4 25 23[m
[32m+[m[32m 12 35 34 33  5 24[m
[32m+[m[32m 11 10  9  8  7  6[m
[32m+[m
[32m+[m[32m------------------------------[m
[32m+[m[32mInput: 7[m
[32m+[m[32mOutput:[m
[32m+[m[32m  1 19 20 21 22 23 24[m
[32m+[m[32m 18  2 33 34 35 36 25[m
[32m+[m[32m 17 40  3 32 39 37 26[m
[32m+[m[32m 16 48 41  4 31 38 27[m
[32m+[m[32m 15 47 49 42  5 30 28[m
[32m+[m[32m 14 46 45 44 43  6 29[m
[32m+[m[32m 13 12 11 10  9  8  7[m
[32m+[m
[32m+[m[32m------------------------------[m
[32m+[m[32mInput: 8[m
[32m+[m[32mOutput:[m
[32m+[m[32m  1 22 23 24 25 26 27 28[m
[32m+[m[32m 21  2 39 40 41 42 43 29[m
[32m+[m[32m 20 50  3 38 48 49 44 30[m
[32m+[m[32m 19 61 51  4 37 47 45 31[m
[32m+[m[32m 18 60 62 52  5 36 46 32[m
[32m+[m[32m 17 59 64 63 53  6 35 33[m
[32m+[m[32m 16 58 57 56 55 54  7 34[m
[32m+[m[32m 15 14 13 12 11 10  9  8[m
[32m+[m
[32m+[m[32m------------------------------[m
[32m+[m[32mInput: 9[m
[32m+[m[32mOutput:[m
[32m+[m[32m  1 25 26 27 28 29 30 31 32[m
[32m+[m[32m 24  2 45 46 47 48 49 50 33[m
[32m+[m[32m 23 61  3 44 57 58 59 51 34[m
[32m+[m[32m 22 75 62  4 43 56 60 52 35[m
[32m+[m[32m 21 74 76 63  5 42 55 53 36[m
[32m+[m[32m 20 73 81 77 64  6 41 54 37[m
[32m+[m[32m 19 72 80 79 78 65  7 40 38[m
[32m+[m[32m 18 71 70 69 68 67 66  8 39[m
[32m+[m[32m 17 16 15 14 13 12 11 10  9[m
[32m+[m
[32m+[m[32m------------------------------[m
[32m+[m[32mInput: 10[m
[32m+[m[32mOutput:[m
[32m+[m[32m  1 28 29 30 31 32 33 34 35 36[m
[32m+[m[32m 27  2 51 52 53 54 55 56 57 37[m
[32m+[m[32m 26 73  3 50 66 67 68 69 58 38[m
[32m+[m[32m 25 90 74  4 49 65 72 70 59 39[m
[32m+[m[32m 24 89 91 75  5 48 64 71 60 40[m
[32m+[m[32m 23 88 99 92 76  6 47 63 61 41[m
[32m+[m[32m 22 87 98100 93 77  7 46 62 42[m
[32m+[m[32m 21 86 97 96 95 94 78  8 45 43[m
[32m+[m[32m 20 85 84 83 82 81 80 79  9 44[m
[32m+[m[32m 19 18 17 16 15 14 13 12 11 10[m
[32m+[m
[32m+[m[32m------------------------------[m
[1mdiff --git a/High Quality Code/Trash/Debugging Lab/Debugging Lab.sln b/High Quality Code/Trash/Debugging Lab/Debugging Lab.sln[m
[1mnew file mode 100644[m
[1mindex 0000000..3b15d10[m
[1m--- /dev/null[m
[1m+++ b/High Quality Code/Trash/Debugging Lab/Debugging Lab.sln[m	
[36m@@ -0,0 +1,22 @@[m
[32m+[m[32m﻿[m
[32m+[m[32mMicrosoft Visual Studio Solution File, Format Version 12.00[m
[32m+[m[32m# Visual Studio 2013[m
[32m+[m[32mVisualStudioVersion = 12.0.40629.0[m
[32m+[m[32mMinimumVisualStudioVersion = 10.0.40219.1[m
[32m+[m[32mProject("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "Debugging Lab", "Debugging Lab\Debugging Lab.csproj", "{2023E93E-970C-4940-ACAE-14D1CFFEAF3E}"[m
[32m+[m[32mEndProject[m
[32m+[m[32mGlobal[m
[32m+[m	[32mGlobalSection(SolutionConfigurationPlatforms) = preSolution[m
[32m+[m		[32mDebug|Any CPU = Debug|Any CPU[m
[32m+[m		[32mRelease|Any CPU = Release|Any CPU[m
[32m+[m	[32mEndGlobalSection[m
[32m+[m	[32mGlobalSection(ProjectConfigurationPlatforms) = postSolution[m
[32m+[m		[32m{2023E93E-970C-4940-ACAE-14D1CFFEAF3E}.Debug|Any CPU.ActiveCfg = Debug|Any CPU[m
[32m+[m		[32m{2023E93E-970C-4940-ACAE-14D1CFFEAF3E}.Debug|Any CPU.Build.0 = Debug|Any CPU[m
[32m+[m		[32m{2023E93E-970C-4940-ACAE-14D1CFFEAF3E}.Release|Any CPU.ActiveCfg = Release|Any CPU[m
[32m+[m		[32m{2023E93E-970C-4940-ACAE-14D1CFFEAF3E}.Release|Any CPU.Build.0 = Release|Any CPU[m
[32m+[m	[32mEndGlobalSection[m
[32m+[m	[32mGlobalSection(SolutionProperties) = preSolution[m
[32m+[m		[32mHideSolutionNode = FALSE[m
[32m+[m	[32mEndGlobalSection[m
[32m+[m[32mEndGlobal[m
[1mdiff --git a/High Quality Code/Trash/Debugging Lab/Debugging Lab/App.config b/High Quality Code/Trash/Debugging Lab/Debugging Lab/App.config[m
[1mnew file mode 100644[m
[1mindex 0000000..8e15646[m
[1m--- /dev/null[m
[1m+++ b/High Quality Code/Trash/Debugging Lab/Debugging Lab/App.config[m	
[36m@@ -0,0 +1,6 @@[m
[32m+[m[32m﻿<?xml version="1.0" encoding="utf-8" ?>[m
[32m+[m[32m<configuration>[m
[32m+[m[32m    <startup>[m[41m [m
[32m+[m[32m        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />[m
[32m+[m[32m    </startup>[m
[32m+[m[32m</configuration>[m
\ No newline at end of file[m
[1mdiff --git a/High Quality Code/Trash/Debugging Lab/Debugging Lab/Debugging Lab.csproj b/High Quality Code/Trash/Debugging Lab/Debugging Lab/Debugging Lab.csproj[m
[1mnew file mode 100644[m
[1mindex 0000000..a19e486[m
[1m--- /dev/null[m
[1m+++ b/High Quality Code/Trash/Debugging Lab/Debugging Lab/Debugging Lab.csproj[m	
[36m@@ -0,0 +1,58 @@[m
[32m+[m[32m﻿<?xml version="1.0" encoding="utf-8"?>[m
[32m+[m[32m<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">[m
[32m+[m[32m  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />[m
[32m+[m[32m  <PropertyGroup>[m
[32m+[m[32m    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>[m
[32m+[m[32m    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>[m
[32m+[m[32m    <ProjectGuid>{2023E93E-970C-4940-ACAE-14D1CFFEAF3E}</ProjectGuid>[m
[32m+[m[32m    <OutputType>Exe</OutputType>[m
[32m+[m[32m    <AppDesignerFolder>Properties</AppDesignerFolder>[m
[32m+[m[32m    <RootNamespace>Debugging_Lab</RootNamespace>[m
[32m+[m[32m    <AssemblyName>Debugging Lab</AssemblyName>[m
[32m+[m[32m    <TargetFrameworkVersion>v4.5</TargetFrameworkVersion>[m
[32m+[m[32m    <FileAlignment>512</FileAlignment>[m
[32m+[m[32m  </PropertyGroup>[m
[32m+[m[32m  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">[m
[32m+[m[32m    <PlatformTarget>AnyCPU</PlatformTarget>[m
[32m+[m[32m    <DebugSymbols>true</DebugSymbols>[m
[32m+[m[32m    <DebugType>full</DebugType>[m
[32m+[m[32m    <Optimize>false</Optimize>[m
[32m+[m[32m    <OutputPath>bin\Debug\</OutputPath>[m
[32m+[m[32m    <DefineConstants>DEBUG;TRACE</DefineConstants>[m
[32m+[m[32m    <ErrorReport>prompt</ErrorReport>[m
[32m+[m[32m    <WarningLevel>4</WarningLevel>[m
[32m+[m[32m  </PropertyGroup>[m
[32m+[m[32m  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">[m
[32m+[m[32m    <PlatformTarget>AnyCPU</PlatformTarget>[m
[32m+[m[32m    <DebugType>pdbonly</DebugType>[m
[32m+[m[32m    <Optimize>true</Optimize>[m
[32m+[m[32m    <OutputPath>bin\Release\</OutputPath>[m
[32m+[m[32m    <DefineConstants>TRACE</DefineConstants>[m
[32m+[m[32m    <ErrorReport>prompt</ErrorReport>[m
[32m+[m[32m    <WarningLevel>4</WarningLevel>[m
[32m+[m[32m  </PropertyGroup>[m
[32m+[m[32m  <ItemGroup>[m
[32m+[m[32m    <Reference Include="System" />[m
[32m+[m[32m    <Reference Include="System.Core" />[m
[32m+[m[32m    <Reference Include="System.Xml.Linq" />[m
[32m+[m[32m    <Reference Include="System.Data.DataSetExtensions" />[m
[32m+[m[32m    <Reference Include="Microsoft.CSharp" />[m
[32m+[m[32m    <Reference Include="System.Data" />[m
[32m+[m[32m    <Reference Include="System.Xml" />[m
[32m+[m[32m  </ItemGroup>[m
[32m+[m[32m  <ItemGroup>[m
[32m+[m[32m    <Compile Include="Program.cs" />[m
[32m+[m[32m    <Compile Include="Properties\AssemblyInfo.cs" />[m
[32m+[m[32m  </ItemGroup>[m
[32m+[m[32m  <ItemGroup>[m
[32m+[m[32m    <None Include="App.config" />[m
[32m+[m[32m  </ItemGroup>[m
[32m+[m[32m  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />[m
[32m+[m[32m  <!-- To modify your build process, add your task inside one of the targets below and uncomment it.[m[41m [m
[32m+[m[32m       Other similar extension points exist, see Microsoft.Common.targets.[m
[32m+[m[32m  <Target Name="BeforeBuild">[m
[32m+[m[32m  </Target>[m
[32m+[m[32m  <Target Name="AfterBuild">[m
[32m+[m[32m  </Target>[m
[32m+[m[32m  -->[m
[32m+[m[32m</Project>[m
\ No newline at end of file[m
[1mdiff --git a/High Quality Code/Trash/Debugging Lab/Debugging Lab/Program.cs b/High Quality Code/Trash/Debugging Lab/Debugging Lab/Program.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..d5c83f1[m
[1m--- /dev/null[m
[1m+++ b/High Quality Code/Trash/Debugging Lab/Debugging Lab/Program.cs[m	
[36m@@ -0,0 +1,38 @@[m
[32m+[m[32m﻿namespace Debugging_BitCarousel[m
[32m+[m[32m{[m
[32m+[m[32m    using System;[m
[32m+[m
[32m+[m[32m    class BitCarousel_broken[m
[32m+[m[32m    {[m
[32m+[m[32m        static void Main()[m
[32m+[m[32m        {[m
[32m+[m[32m            byte number = byte.Parse(Console.ReadLine());[m
[32m+[m[32m            byte rotations = byte.Parse(Console.ReadLine());[m
[32m+[m
[32m+[m[32m            for (int i = 0; i < rotations; i++)[m
[32m+[m[32m            {[m
[32m+[m[32m                string direction = Console.ReadLine();[m
[32m+[m
[32m+[m[32m                if (direction == "right")[m
[32m+[m[32m                {[m
[32m+[m[32m                    int rightMostBit = number & 1;[m
[32m+[m[32m                    number >>= 1;[m
[32m+[m[32m                    number |= (byte)(rightMostBit << 5);[m
[32m+[m[32m                }[m
[32m+[m[32m                else if (direction == "left")[m
[32m+[m[32m                {[m
[32m+[m[32m                    int leftMostBit = (number >> 5) & 1;[m
[32m+[m[32m                    if (leftMostBit == 1)[m
[32m+[m[32m                    {[m
[32m+[m[32m                        int reversed = ~(1 << 5);[m
[32m+[m[32m                        number &= (byte) reversed;[m
[32m+[m[32m                    }[m
[32m+[m[32m                    number <<= 1;[m
[32m+[m[32m                    number |= (byte) leftMostBit;[m
[32m+[m[32m                }[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m            Console.WriteLine(number);[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/High Quality Code/Trash/Debugging Lab/Debugging Lab/Properties/AssemblyInfo.cs b/High Quality Code/Trash/Debugging Lab/Debugging Lab/Properties/AssemblyInfo.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..60a83c1[m
[1m--- /dev/null[m
[1m+++ b/High Quality Code/Trash/Debugging Lab/Debugging Lab/Properties/AssemblyInfo.cs[m	
[36m@@ -0,0 +1,36 @@[m
[32m+[m[32m﻿using System.Reflection;[m
[32m+[m[32musing System.Runtime.CompilerServices;[m
[32m+[m[32musing System.Runtime.InteropServices;[m
[32m+[m
[32m+[m[32m// General Information about an assembly is controlled through the following[m[41m [m
[32m+[m[32m// set of attributes. Change these attribute values to modify the information[m
[32m+[m[32m// associated with an assembly.[m
[32m+[m[32m[assembly: AssemblyTitle("Debugging Lab")][m
[32m+[m[32m[assembly: AssemblyDescription("")][m
[32m+[m[32m[assembly: AssemblyConfiguration("")][m
[32m+[m[32m[assembly: AssemblyCompany("")][m
[32m+[m[32m[assembly: AssemblyProduct("Debugging Lab")][m
[32m+[m[32m[assembly: AssemblyCopyright("Copyright ©  2016")][m
[32m+[m[32m[assembly: AssemblyTrademark("")][m
[32m+[m[32m[assembly: AssemblyCulture("")][m
[32m+[m
[32m+[m[32m// Setting ComVisible to false makes the types in this assembly not visible[m[41m [m
[32m+[m[32m// to COM components.  If you need to access a type in this assembly from[m[41m [m
[32m+[m[32m// COM, set the ComVisible attribute to true on that type.[m
[32m+[m[32m[assembly: ComVisible(false)][m
[32m+[m
[32m+[m[32m// The following GUID is for the ID of the typelib if this project is exposed to COM[m
[32m+[m[32m[assembly: Guid("08d0a5a2-a670-4292-84bd-93db48521bf6")][m
[32m+[m
[32m+[m[32m// Version information for an assembly consists of the following four values:[m
[32m+[m[32m//[m
[32m+[m[32m//      Major Version[m
[32m+[m[32m//      Minor Version[m[41m [m
[32m+[m[32m//      Build Number[m
[32m+[m[32m//      Revision[m
[32m+[m[32m//[m
[32m+[m[32m// You can specify all the values or you can default the Build and Revision Numbers[m[41m [m
[32m+[m[32m// by using the '*' as shown below:[m
[32m+[m[32m// [assembly: AssemblyVersion("1.0.*")][m
[32m+[m[32m[assembly: AssemblyVersion("1.0.0.0")][m
[32m+[m[32m[assembly: AssemblyFileVersion("1.0.0.0")][m
[1mdiff --git a/JavaScript Basics/Exersizes/.idea/.name b/JavaScript Basics/Exersizes/.idea/.name[m
[1mnew file mode 100644[m
[1mindex 0000000..40ab76a[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/.idea/.name[m	
[36m@@ -0,0 +1 @@[m
[32m+[m[32mExersizes[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Exersizes/.idea/Exersizes.iml b/JavaScript Basics/Exersizes/.idea/Exersizes.iml[m
[1mnew file mode 100644[m
[1mindex 0000000..c956989[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/.idea/Exersizes.iml[m	
[36m@@ -0,0 +1,8 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<module type="WEB_MODULE" version="4">[m
[32m+[m[32m  <component name="NewModuleRootManager">[m
[32m+[m[32m    <content url="file://$MODULE_DIR$" />[m
[32m+[m[32m    <orderEntry type="inheritedJdk" />[m
[32m+[m[32m    <orderEntry type="sourceFolder" forTests="false" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m</module>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Exersizes/.idea/misc.xml b/JavaScript Basics/Exersizes/.idea/misc.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..19f74da[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/.idea/misc.xml[m	
[36m@@ -0,0 +1,14 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ProjectLevelVcsManager" settingsEditedManually="false">[m
[32m+[m[32m    <OptionsSetting value="true" id="Add" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Remove" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Checkout" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Update" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Status" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Edit" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Add" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Remove" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectRootManager" version="2" />[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Exersizes/.idea/modules.xml b/JavaScript Basics/Exersizes/.idea/modules.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..0026061[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/.idea/modules.xml[m	
[36m@@ -0,0 +1,8 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ProjectModuleManager">[m
[32m+[m[32m    <modules>[m
[32m+[m[32m      <module fileurl="file://$PROJECT_DIR$/.idea/Exersizes.iml" filepath="$PROJECT_DIR$/.idea/Exersizes.iml" />[m
[32m+[m[32m    </modules>[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Exersizes/.idea/vcs.xml b/JavaScript Basics/Exersizes/.idea/vcs.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..6564d52[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/.idea/vcs.xml[m	
[36m@@ -0,0 +1,6 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="VcsDirectoryMappings">[m
[32m+[m[32m    <mapping directory="" vcs="" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Exersizes/.idea/workspace.xml b/JavaScript Basics/Exersizes/.idea/workspace.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..31d10a8[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/.idea/workspace.xml[m	
[36m@@ -0,0 +1,401 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ChangeListManager">[m
[32m+[m[32m    <list default="true" id="b028b616-ee08-46fa-99e9-26ebdf00ceaf" name="Default" comment="" />[m
[32m+[m[32m    <ignored path="Exersizes.iws" />[m
[32m+[m[32m    <ignored path=".idea/workspace.xml" />[m
[32m+[m[32m    <ignored path=".idea/dataSources.local.xml" />[m
[32m+[m[32m    <option name="EXCLUDED_CONVERTED_TO_IGNORED" value="true" />[m
[32m+[m[32m    <option name="TRACKING_ENABLED" value="true" />[m
[32m+[m[32m    <option name="SHOW_DIALOG" value="false" />[m
[32m+[m[32m    <option name="HIGHLIGHT_CONFLICTS" value="true" />[m
[32m+[m[32m    <option name="HIGHLIGHT_NON_ACTIVE_CHANGELIST" value="false" />[m
[32m+[m[32m    <option name="LAST_RESOLUTION" value="IGNORE" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ChangesViewManager" flattened_view="true" show_ignored="false" />[m
[32m+[m[32m  <component name="CreatePatchCommitExecutor">[m
[32m+[m[32m    <option name="PATCH_PATH" value="" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ExecutionTargetManager" SELECTED_TARGET="default_target" />[m
[32m+[m[32m  <component name="FavoritesManager">[m
[32m+[m[32m    <favorites_list name="Exersizes" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="FileEditorManager">[m
[32m+[m[32m    <leaf>[m
[32m+[m[32m      <file leaf-file-name="index.html" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/Layout/index.html">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="-14.0">[m
[32m+[m[32m              <caret line="92" column="20" selection-start-line="92" selection-start-column="20" selection-end-line="92" selection-end-column="20" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="main.css" pinned="false" current-in-tab="true">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/Layout/styles/main.css">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.41880342">[m
[32m+[m[32m              <caret line="131" column="30" selection-start-line="131" selection-start-column="30" selection-end-line="131" selection-end-column="30" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m    </leaf>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="FileTemplateManagerImpl">[m
[32m+[m[32m    <option name="RECENT_TEMPLATES">[m
[32m+[m[32m      <list>[m
[32m+[m[32m        <option value="JavaScript File" />[m
[32m+[m[32m        <option value="Html5" />[m
[32m+[m[32m        <option value="CSS File" />[m
[32m+[m[32m      </list>[m
[32m+[m[32m    </option>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="IdeDocumentHistory">[m
[32m+[m[32m    <option name="CHANGED_PATHS">[m
[32m+[m[32m      <list>[m
[32m+[m[32m        <option value="$PROJECT_DIR$/Dices/js/dices.js" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/Dices/js/side-scrolling-text.js" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/Dices/styles/style.css" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/Dices/index.html" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/Layout/index.html" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/Layout/styles/main.css" />[m
[32m+[m[32m      </list>[m
[32m+[m[32m    </option>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="JsBuildToolGruntFileManager" detection-done="true" />[m
[32m+[m[32m  <component name="JsGulpfileManager">[m
[32m+[m[32m    <detection-done>true</detection-done>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="NamedScopeManager">[m
[32m+[m[32m    <order />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PhpServers">[m
[32m+[m[32m    <servers />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PhpWorkspaceProjectConfiguration" backward_compatibility_performed="true" />[m
[32m+[m[32m  <component name="ProjectFrameBounds">[m
[32m+[m[32m    <option name="x" value="-8" />[m
[32m+[m[32m    <option name="y" value="-8" />[m
[32m+[m[32m    <option name="width" value="1382" />[m
[32m+[m[32m    <option name="height" value="744" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectLevelVcsManager" settingsEditedManually="false">[m
[32m+[m[32m    <OptionsSetting value="true" id="Add" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Remove" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Checkout" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Update" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Status" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Edit" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Add" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Remove" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectView">[m
[32m+[m[32m    <navigator currentView="ProjectPane" proportions="" version="1">[m
[32m+[m[32m      <flattenPackages />[m
[32m+[m[32m      <showMembers />[m
[32m+[m[32m      <showModules />[m
[32m+[m[32m      <showLibraryContents />[m
[32m+[m[32m      <hideEmptyPackages />[m
[32m+[m[32m      <abbreviatePackageNames />[m
[32m+[m[32m      <autoscrollToSource />[m
[32m+[m[32m      <autoscrollFromSource />[m
[32m+[m[32m      <sortByType />[m
[32m+[m[32m    </navigator>[m
[32m+[m[32m    <panes>[m
[32m+[m[32m      <pane id="ProjectPane">[m
[32m+[m[32m        <subPane>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Layout" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Layout" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="styles" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Layout" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="images" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Dices" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Dices" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="styles" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Exersizes" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Dices" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="js" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m        </subPane>[m
[32m+[m[32m      </pane>[m
[32m+[m[32m      <pane id="Scope" />[m
[32m+[m[32m      <pane id="Scratches" />[m
[32m+[m[32m    </panes>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PropertiesComponent">[m
[32m+[m[32m    <property name="WebServerToolWindowFactoryState" value="false" />[m
[32m+[m[32m    <property name="DefaultHtmlFileTemplate" value="Html5" />[m
[32m+[m[32m    <property name="list.type.of.created.stylesheet" value="CSS" />[m
[32m+[m[32m    <property name="FullScreen" value="false" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="RunManager">[m
[32m+[m[32m    <configuration default="true" type="JavascriptDebugType" factoryName="JavaScript Debug">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="NodeJSConfigurationType" factoryName="Node.js" working-dir="">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PHPUnitRunConfigurationType" factoryName="PHPUnit">[m
[32m+[m[32m      <TestRunner />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PhpBehatConfigurationType" factoryName="Behat">[m
[32m+[m[32m      <BehatRunner />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PhpLocalRunConfigurationType" factoryName="PHP Console">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PhpUnitRemoteRunConfigurationType" factoryName="PHPUnit on Server">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="js.build_tools.gulp" factoryName="Gulp.js">[m
[32m+[m[32m      <node-options />[m
[32m+[m[32m      <gulpfile />[m
[32m+[m[32m      <tasks />[m
[32m+[m[32m      <arguments />[m
[32m+[m[32m      <pass-parent-envs>true</pass-parent-envs>[m
[32m+[m[32m      <envs />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ShelveChangesManager" show_recycled="false" />[m
[32m+[m[32m  <component name="SvnConfiguration">[m
[32m+[m[32m    <configuration />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="TaskManager">[m
[32m+[m[32m    <task active="true" id="Default" summary="Default task">[m
[32m+[m[32m      <changelist id="b028b616-ee08-46fa-99e9-26ebdf00ceaf" name="Default" comment="" />[m
[32m+[m[32m      <created>1454191208272</created>[m
[32m+[m[32m      <option name="number" value="Default" />[m
[32m+[m[32m      <updated>1454191208272</updated>[m
[32m+[m[32m    </task>[m
[32m+[m[32m    <servers />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ToolWindowManager">[m
[32m+[m[32m    <frame x="-8" y="-8" width="1382" height="744" extended-state="6" />[m
[32m+[m[32m    <editor active="true" />[m
[32m+[m[32m    <layout>[m
[32m+[m[32m      <window_info id="Project" active="false" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="true" weight="0.25718608" sideWeight="0.5" order="0" side_tool="false" content_ui="combo" />[m
[32m+[m[32m      <window_info id="TODO" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="6" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Event Log" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.32952693" sideWeight="0.5" order="7" side_tool="true" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Application Servers" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="7" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Database" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="3" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Version Control" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="7" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Structure" active="false" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="1" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Terminal" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="7" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Favorites" active="false" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="2" side_tool="true" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Cvs" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="4" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Message" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="0" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Commander" active="false" anchor="right" auto_hide="false" internal_type="SLIDING" type="SLIDING" visible="false" weight="0.4" sideWeight="0.5" order="0" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Inspection" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.4" sideWeight="0.5" order="5" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Run" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="2" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Hierarchy" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="2" side_tool="false" content_ui="combo" />[m
[32m+[m[32m      <window_info id="Find" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="1" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Ant Build" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="1" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Debug" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.4" sideWeight="0.5" order="3" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m    </layout>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="Vcs.Log.UiProperties">[m
[32m+[m[32m    <option name="RECENTLY_FILTERED_USER_GROUPS">[m
[32m+[m[32m      <collection />[m
[32m+[m[32m    </option>[m
[32m+[m[32m    <option name="RECENTLY_FILTERED_BRANCH_GROUPS">[m
[32m+[m[32m      <collection />[m
[32m+[m[32m    </option>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="VcsContentAnnotationSettings">[m
[32m+[m[32m    <option name="myLimit" value="2678400000" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="XDebuggerManager">[m
[32m+[m[32m    <breakpoint-manager />[m
[32m+[m[32m    <watches-manager />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="editorHistoryManager">[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Layout/index.html">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="77" column="20" selection-start-line="77" selection-start-column="20" selection-end-line="77" selection-end-column="20" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Layout/styles/main.css">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="0" column="0" selection-start-line="0" selection-start-column="0" selection-end-line="0" selection-end-column="0" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Dices/index.html">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="0" column="0" selection-start-line="0" selection-start-column="0" selection-end-line="0" selection-end-column="0" />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Dices/js/dices.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="32" column="34" selection-start-line="32" selection-start-column="34" selection-end-line="32" selection-end-column="34" />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Dices/js/side-scrolling-text.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="21" column="43" selection-start-line="21" selection-start-column="43" selection-end-line="21" selection-end-column="43" />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Dices/styles/style.css">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="17" column="21" selection-start-line="17" selection-start-column="21" selection-end-line="17" selection-end-column="21" />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Dices/js/dices.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="32" column="34" selection-start-line="32" selection-start-column="34" selection-end-line="32" selection-end-column="34" />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Dices/js/side-scrolling-text.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="21" column="43" selection-start-line="21" selection-start-column="43" selection-end-line="21" selection-end-column="43" />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Dices/index.html">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="-16.346153">[m
[32m+[m[32m          <caret line="25" column="7" selection-start-line="25" selection-start-column="7" selection-end-line="25" selection-end-column="7" />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Dices/styles/style.css">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.52307695">[m
[32m+[m[32m          <caret line="18" column="1" selection-start-line="18" selection-start-column="1" selection-end-line="18" selection-end-column="1" />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Layout/index.html">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="-14.0">[m
[32m+[m[32m          <caret line="92" column="20" selection-start-line="92" selection-start-column="20" selection-end-line="92" selection-end-column="20" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/Layout/styles/main.css">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.41880342">[m
[32m+[m[32m          <caret line="131" column="30" selection-start-line="131" selection-start-column="30" selection-end-line="131" selection-end-column="30" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Exersizes/Dices/index.html b/JavaScript Basics/Exersizes/Dices/index.html[m
[1mnew file mode 100644[m
[1mindex 0000000..37b2d6a[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/Dices/index.html[m	
[36m@@ -0,0 +1,26 @@[m
[32m+[m[32m<!DOCTYPE html>[m
[32m+[m[32m<html lang="en">[m
[32m+[m[32m<head>[m
[32m+[m[32m    <meta charset="UTF-8">[m
[32m+[m[32m    <title>Dices</title>[m
[32m+[m[32m    <link rel="stylesheet" href="styles/style.css">[m
[32m+[m[32m    <script src="js/dices.js"></script>[m
[32m+[m[32m    <script src="js/side-scrolling-text.js"></script>[m
[32m+[m[32m</head>[m
[32m+[m[32m<body>[m
[32m+[m[32m    <canvas id="first-dice" width="60" height="60">[m
[32m+[m[32m        Your browser do not support canvas.[m
[32m+[m[32m    </canvas>[m
[32m+[m[32m    <canvas id="second-dice" width="60" height="60">[m
[32m+[m[32m        Your browser do not support canvas.[m
[32m+[m[32m    </canvas>[m
[32m+[m[32m    <p id="log"></p>[m
[32m+[m[32m<button onclick="rollDices()">Roll Dices</button>[m
[32m+[m[32m<button onclick="scrollText()">Scroll Text</button>[m
[32m+[m[32m    <marquee behavior="scroll" scrollamount="10" direction="left"[m
[32m+[m[32m             onmouseover="this.stop();" onmouseout="this.start();">[m
[32m+[m[32m        I am rolling from Left to Right(HACKED)[m
[32m+[m[32m    </marquee>[m
[32m+[m[32m<span id="scrolling-text">Lorem ipsum ala bala blablabalb i'm rolliiiiin left and right, not up and down, some other text ablablababa</span>[m
[32m+[m[32m</body>[m
[32m+[m[32m</html>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Exersizes/Dices/js/dices.js b/JavaScript Basics/Exersizes/Dices/js/dices.js[m
[1mnew file mode 100644[m
[1mindex 0000000..b8809d7[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/Dices/js/dices.js[m	
[36m@@ -0,0 +1,58 @@[m
[32m+[m[32mfunction rollDices() {[m
[32m+[m[32m    var firstNum = getRandomNumberInRange(6);[m
[32m+[m[32m    var secondNum = getRandomNumberInRange(6);[m
[32m+[m[32m    var log = document.getElementById('log');[m
[32m+[m
[32m+[m[32m    drawNumber(firstNum, 'first-dice');[m
[32m+[m[32m    drawNumber(secondNum, 'second-dice');[m
[32m+[m
[32m+[m[32m    log.innerText = 'Score: ' + (firstNum + secondNum);[m
[32m+[m
[32m+[m[32m    if(firstNum === secondNum) {[m
[32m+[m[32m        log.innerText = 'Congratulations, you have rolled a pair!'[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    if(firstNum + secondNum === 12) {[m
[32m+[m[32m        log.innerText = 'WOW!!! YOU HAVE WON THE JACKPOT!'[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mfunction getRandomNumberInRange(range) {[m
[32m+[m[32m    var randomNumber = Math.floor(Math.random() * range) + 1;[m
[32m+[m
[32m+[m[32m    return randomNumber;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mfunction drawNumber(num, diceId) {[m
[32m+[m[32m    var canvas = document.getElementById(diceId);[m
[32m+[m[32m    var ctx = canvas.getContext('2d');[m
[32m+[m[32m    ctx.clearRect(0, 0, canvas.width, canvas.height);[m
[32m+[m
[32m+[m[32m    if (num === 1) {[m
[32m+[m[32m        var coords = [[30, 30]];[m
[32m+[m[32m        drawOnCanvas(ctx, coords);[m
[32m+[m[32m    } else if (num === 2) {[m
[32m+[m[32m        var coords = [[45, 15], [15, 45]];[m
[32m+[m[32m        drawOnCanvas(ctx, coords);[m
[32m+[m[32m    } else if (num === 3) {[m
[32m+[m[32m        var coords = [[45, 15], [15, 45], [30, 30]];[m
[32m+[m[32m        drawOnCanvas(ctx, coords);[m
[32m+[m[32m    } else if (num === 4) {[m
[32m+[m[32m        var coords = [[45, 15], [15, 45], [15, 15], [45, 45]];[m
[32m+[m[32m        drawOnCanvas(ctx, coords);[m
[32m+[m[32m    } else if (num === 5) {[m
[32m+[m[32m        var coords = [[45, 15], [15, 45], [15, 15], [45, 45], [30, 30]];[m
[32m+[m[32m        drawOnCanvas(ctx, coords);[m
[32m+[m[32m    } else if (num === 6) {[m
[32m+[m[32m        var coords = [[45, 15], [15, 45], [15, 15], [45, 45], [15, 30], [45, 30]];[m
[32m+[m[32m        drawOnCanvas(ctx, coords);[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mfunction drawOnCanvas(ctx, coords) {[m
[32m+[m[32m    for(var i = 0; i < coords.length; i++){[m
[32m+[m[32m        ctx.beginPath();[m
[32m+[m[32m        ctx.arc(coords[i][0], coords[i][1], 5, 0, Math.PI * 2, true);[m
[32m+[m[32m        ctx.fill();[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Exersizes/Dices/js/side-scrolling-text.js b/JavaScript Basics/Exersizes/Dices/js/side-scrolling-text.js[m
[1mnew file mode 100644[m
[1mindex 0000000..a511b39[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/Dices/js/side-scrolling-text.js[m	
[36m@@ -0,0 +1,22 @@[m
[32m+[m[32mfunction scrollText() {[m
[32m+[m[32m    var scrollingLabel = document.getElementById('scrolling-text');[m
[32m+[m
[32m+[m[32m    var labelWidth = scrollingLabel.offsetWidth;[m
[32m+[m
[32m+[m[32m    var currentPosition = scrollingLabel.offsetLeft - 1;[m
[32m+[m
[32m+[m[32m    if(labelWidth + currentPosition == 0) {[m
[32m+[m[32m        currentPosition = window.innerWidth - 1;[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    if(currentPosition > 0) {[m
[32m+[m[32m        var wdth = window.innerWidth - currentPosition;[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    scrollingLabel.style.left = currentPosition + 'px';[m
[32m+[m[32m    scrollingLabel.style.width = wdth + 'px';[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32m//scrolling-text[m
[32m+[m
[32m+[m[32mwindow.onload = setInterval(scrollText, 1);[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Exersizes/Dices/styles/style.css b/JavaScript Basics/Exersizes/Dices/styles/style.css[m
[1mnew file mode 100644[m
[1mindex 0000000..bb96087[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/Dices/styles/style.css[m	
[36m@@ -0,0 +1,19 @@[m
[32m+[m[32mbody {[m
[32m+[m[32m    border: none;[m
[32m+[m[32m    padding: 0;[m
[32m+[m[32m    margin: 0;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mcanvas {[m
[32m+[m[32m    border: 1px solid #daa;[m
[32m+[m[32m    -webkit-border-radius: 5px;[m
[32m+[m[32m    -moz-border-radius: 5px;[m
[32m+[m[32m    border-radius: 5px;[m
[32m+[m[32m    display: inline-block;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32m#scrolling-text {[m
[32m+[m[32m    position: absolute;[m
[32m+[m[32m    white-space: nowrap;[m
[32m+[m[32m    overflow: hidden;[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Exersizes/Layout/images/0003.jpg b/JavaScript Basics/Exersizes/Layout/images/0003.jpg[m
[1mnew file mode 100644[m
[1mindex 0000000..d745fee[m
Binary files /dev/null and b/JavaScript Basics/Exersizes/Layout/images/0003.jpg differ
[1mdiff --git a/JavaScript Basics/Exersizes/Layout/images/0004.jpg b/JavaScript Basics/Exersizes/Layout/images/0004.jpg[m
[1mnew file mode 100644[m
[1mindex 0000000..f6a20fd[m
Binary files /dev/null and b/JavaScript Basics/Exersizes/Layout/images/0004.jpg differ
[1mdiff --git a/JavaScript Basics/Exersizes/Layout/images/0005.jpg b/JavaScript Basics/Exersizes/Layout/images/0005.jpg[m
[1mnew file mode 100644[m
[1mindex 0000000..789446f[m
Binary files /dev/null and b/JavaScript Basics/Exersizes/Layout/images/0005.jpg differ
[1mdiff --git a/JavaScript Basics/Exersizes/Layout/images/headerBackground.jpg b/JavaScript Basics/Exersizes/Layout/images/headerBackground.jpg[m
[1mnew file mode 100644[m
[1mindex 0000000..f20279e[m
Binary files /dev/null and b/JavaScript Basics/Exersizes/Layout/images/headerBackground.jpg differ
[1mdiff --git a/JavaScript Basics/Exersizes/Layout/index.html b/JavaScript Basics/Exersizes/Layout/index.html[m
[1mnew file mode 100644[m
[1mindex 0000000..c1b575b[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/Layout/index.html[m	
[36m@@ -0,0 +1,111 @@[m
[32m+[m[32m<!DOCTYPE html>[m
[32m+[m[32m<html lang="en">[m
[32m+[m[32m<head>[m
[32m+[m[32m    <meta charset="UTF-8">[m
[32m+[m[32m    <link rel="stylesheet" href="styles/main.css">[m
[32m+[m[32m    <title>Pretty Website</title>[m
[32m+[m[32m</head>[m
[32m+[m[32m<body>[m
[32m+[m[32m    <div id="wrapper">[m
[32m+[m[32m        <header>[m
[32m+[m[32m            <strong>[m
[32m+[m[32m                <a href="#">[m
[32m+[m[32m                    <img src="images/headerBackground.jpg" alt="Header Background">[m
[32m+[m[32m                    <h1>In the twilight of one's life</h1>[m
[32m+[m[32m                </a>[m
[32m+[m[32m            </strong>[m
[32m+[m[32m        </header>[m
[32m+[m[32m        <nav>[m
[32m+[m[32m            <ul>[m
[32m+[m[32m                <li><a href="#">Home</a></li>[m
[32m+[m[32m                <li><a href="#">About</a></li>[m
[32m+[m[32m                <li><a href="#">Blog</a></li>[m
[32m+[m[32m                <li><a href="#">Gallery</a></li>[m
[32m+[m[32m                <li><a href="#">Contact</a></li>[m
[32m+[m[32m            </ul>[m
[32m+[m[32m        </nav>[m
[32m+[m[32m        <main>[m
[32m+[m[32m            <article>[m
[32m+[m[32m                <h2>WELCOME TO HOME PAGE</h2>[m
[32m+[m[32m                <p>[m
[32m+[m[32m                    <strong>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque sit amet elementum sapien, et interdum risus.</strong>[m
[32m+[m[32m                    Integer ultrices neque vel est posuere, vel aliquam urna ultricies. Maecenas convallis a tortor vitae vestibulum.[m
[32m+[m[32m                    Morbi posuere id dolor in bibendum. Nunc dolor felis, sagittis at aliquam ac, euismod vitae mi.[m
[32m+[m[32m                    Maecenas dignissim eu orci iaculis iaculis. Sed semper, leo vel mattis congue, arcu enim luctus orci,[m
[32m+[m[32m                    eu finibus nunc leo ut nulla. Duis at metus turpis. Class aptent taciti sociosqu ad litora torquent per conubia[m
[32m+[m[32m                    nostra, per inceptos himenaeos. Nam laoreet aliquam tristique. Duis molestie leo vel vulputate suscipit.[m
[32m+[m[32m                    Pellentesque placerat id est eu dignissim. Nunc dictum ac metus quis mattis. Nullam vel egestas orci.[m
[32m+[m[32m                </p>[m
[32m+[m[32m            </article>[m
[32m+[m[32m            <article>[m
[32m+[m[32m                <h2>Our Free Products</h2>[m
[32m+[m[32m                <div class="products-box">[m
[32m+[m[32m                    <img src="images/0003.jpg" alt="Just try to find me">[m
[32m+[m[32m                    <h3>Just try to find me</h3>[m
[32m+[m[32m                    <p>[m
[32m+[m[32m                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.[m
[32m+[m[32m                        Quisque sit amet elementum sapien, et interdum risus.[m
[32m+[m[32m                        Integer ultrices neque vel est posuere, vel aliquam urna ultricies.[m
[32m+[m[32m                        Maecenas convallis a tortor vitae                             vestibulum.[m
[32m+[m[32m                    </p>[m
[32m+[m[32m                </div>[m
[32m+[m[32m                <div class="products-box">[m
[32m+[m[32m                    <img src="images/0004.jpg" alt="Meeting place">[m
[32m+[m[32m                    <h3>Meeting place</h3>[m
[32m+[m[32m                    <p>[m
[32m+[m[32m                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.[m
[32m+[m[32m                        Quisque sit amet elementum sapien, et interdum risus.[m
[32m+[m[32m                        Integer ultrices neque vel est posuere, vel aliquam urna ultricies.[m
[32m+[m[32m                        Maecenas convallis a tortor vitae                             vestibulum.[m
[32m+[m[32m                    </p>[m
[32m+[m[32m                </div>[m
[32m+[m[32m                <div class="products-box">[m
[32m+[m[32m                    <img src="images/0005.jpg" alt="Skate show">[m
[32m+[m[32m                    <h3>Skate show</h3>[m
[32m+[m[32m                    <p>[m
[32m+[m[32m                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.[m
[32m+[m[32m                        Quisque sit amet elementum sapien, et interdum risus.[m
[32m+[m[32m                        Integer ultrices neque vel est posuere, vel aliquam urna ultricies.[m
[32m+[m[32m                        Maecenas convallis a tortor vitae                             vestibulum.[m
[32m+[m[32m                    </p>[m
[32m+[m[32m                </div>[m
[32m+[m[32m            </article>[m
[32m+[m[32m        </main>[m
[32m+[m[32m        <aside>[m
[32m+[m[32m            <section>[m
[32m+[m[32m                <h2>NEWS</h2>[m
[32m+[m[32m                <article>[m
[32m+[m[32m                    <h3>August 2, 2015</h3>[m
[32m+[m[32m                    <p>Aliuqam aru getsu</p>[m
[32m+[m[32m                    <a href="#">See more...</a>[m
[32m+[m[32m                </article>[m
[32m+[m[32m                <article>[m
[32m+[m[32m                    <h3>October 7, 2014</h3>[m
[32m+[m[32m                    <p>Aliuqam aru getsu</p>[m
[32m+[m[32m                    <a href="#">See more...</a>[m
[32m+[m[32m                </article>[m
[32m+[m[32m                <article>[m
[32m+[m[32m                    <h3>January 28, 2014</h3>[m
[32m+[m[32m                    <p>Aliuqam aru getsu</p>[m
[32m+[m[32m                    <a href="#">See more...</a>[m
[32m+[m[32m                </article>[m
[32m+[m[32m            </section>[m
[32m+[m[32m            <section>[m
[32m+[m[32m                <h2>MESSAGES</h2>[m
[32m+[m[32m                <article>[m
[32m+[m[32m                    <h3>November 11, 2015</h3>[m
[32m+[m[32m                    <p>Fusce pulvinar, leo quis auctor lobortis, nibh nibh semper massa, at elementum orci metus at enim.[m
[32m+[m[32m                        Sed et velit ullamcorper, ullamcorper risus eget, dictum tellus. Nam eget tristique ligula.[m
[32m+[m[32m                        Aenean non suscipit elit. In venenatis velit at nibh suscipit finibus vitae sit amet ex.[m
[32m+[m[32m                    </p>[m
[32m+[m[32m                    <p>Author: <span>SoftUni</span></p>[m
[32m+[m[32m                    <a href="#">See all testimonials...</a>[m
[32m+[m[32m                </article>[m
[32m+[m[32m            </section>[m
[32m+[m[32m        </aside>[m
[32m+[m[32m        <footer>[m
[32m+[m[32m            <p>In the twilight of one's life Copyright &copy; 2 August 2015 | <a href="#">XHTML</a> | <a href="#">CSS</a></p>[m
[32m+[m[32m        </footer>[m
[32m+[m[32m    </div>[m
[32m+[m[32m</body>[m
[32m+[m[32m</html>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Exersizes/Layout/styles/main.css b/JavaScript Basics/Exersizes/Layout/styles/main.css[m
[1mnew file mode 100644[m
[1mindex 0000000..16eb115[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Exersizes/Layout/styles/main.css[m	
[36m@@ -0,0 +1,149 @@[m
[32m+[m[32m* {[m
[32m+[m[32m    margin: 0;[m
[32m+[m[32m    padding: 0;[m
[32m+[m[32m    border: none;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody {[m
[32m+[m[32m    background-color: #111;[m
[32m+[m[32m    font-family: Arial;[m
[32m+[m[32m    font-size: 14px;[m
[32m+[m[32m}[m
[32m+[m[32mp {[m
[32m+[m[32m    font-size: 0.9em;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32m    body div#wrapper {[m
[32m+[m[32m        background-color: #fff;[m
[32m+[m[32m        width: 900px;[m
[32m+[m[32m        margin: 0 auto;[m
[32m+[m[32m        overflow: auto;[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m        body div#wrapper header {[m
[32m+[m[32m            margin: 0 auto;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m                body div#wrapper header strong a {[m
[32m+[m[32m                    text-decoration: none;[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                    body div#wrapper header strong a h1 {[m
[32m+[m[32m                        color: #fff;[m
[32m+[m[32m                        margin-top: -70px;[m
[32m+[m[32m                        margin-right: 50px;[m
[32m+[m[32m                        text-align: right;[m
[32m+[m[32m                    }[m
[32m+[m
[32m+[m[32m        body div#wrapper nav {[m
[32m+[m[32m            width: 100%;[m
[32m+[m[32m            background-color: #d7cfc0;[m
[32m+[m[32m            padding-bottom: 2px;[m
[32m+[m[32m            margin-top: 38px;[m
[32m+[m[32m            margin-bottom: 20px;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m            body div#wrapper nav ul {[m
[32m+[m[32m                margin-top: -3px;[m
[32m+[m[32m                list-style-type: none;[m
[32m+[m[32m                border-bottom: 1px solid #fff;[m
[32m+[m[32m                width: 100%;[m
[32m+[m[32m                height: 40px;[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m                body div#wrapper nav ul li {[m
[32m+[m[32m                    float: left;[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                    body div#wrapper nav ul li a {[m
[32m+[m[32m                        display: block;[m
[32m+[m[32m                        color: #555;[m
[32m+[m[32m                        text-decoration: none;[m
[32m+[m[32m                        text-transform: uppercase;[m
[32m+[m[32m                        font-size: 1.3em;[m
[32m+[m[32m                        border-right: 1px solid #fff;[m
[32m+[m[32m                        line-height: 40px;[m
[32m+[m[32m                        padding: 0 30px;[m
[32m+[m[32m                    }[m
[32m+[m
[32m+[m[32m                    body div#wrapper nav ul li a:hover {[m
[32m+[m[32m                        background-color: #aea697;[m
[32m+[m[32m                        color: #fff;[m
[32m+[m[32m                    }[m
[32m+[m
[32m+[m[32m            body div#wrapper main {[m
[32m+[m[32m                float: left;[m
[32m+[m[32m                display: inline-block;[m
[32m+[m[32m                width: 61%;[m
[32m+[m[32m                padding-left: 6%;[m
[32m+[m[32m                padding-right: 3%;[m
[32m+[m[32m                /*background-color: coral;*/[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32m                body div#wrapper main>article,[m
[32m+[m[32m                body div#wrapper aside>section {[m
[32m+[m[32m                    padding: 20px 20px 10px 20px;[m
[32m+[m[32m                    border: 1px solid #d7cfc0;[m
[32m+[m[32m                    border-radius: 10px;[m
[32m+[m[32m                    margin-bottom: 20px;[m
[32m+[m[32m                }[m
[32m+[m
[32m+[m[32m                    body div#wrapper main>article h2,[m
[32m+[m[32m                    body div#wrapper aside>section h2{[m
[32m+[m[32m                        margin-bottom: 15px;[m
[32m+[m[32m                        color: #8ee01c;[m
[32m+[m[32m                    }[m
[32m+[m
[32m+[m[32m                    body div#wrapper main article div.products-box{[m
[32m+[m[32m                        overflow: auto;[m
[32m+[m[32m                        margin-bottom: 17px;[m
[32m+[m[32m                    }[m
[32m+[m
[32m+[m[32m                        body div#wrapper main article div.products-box h3 {[m
[32m+[m[32m                            font-size: 0.9em;[m
[32m+[m[32m                            margin-bottom: 17px;[m
[32m+[m[32m                        }[m
[32m+[m
[32m+[m[32m                        body div#wrapper main article div.products-box img {[m
[32m+[m[32m                            float: left;[m
[32m+[m[32m                            margin-right: 17px;[m
[32m+[m[32m                        }[m
[32m+[m
[32m+[m[32m            body div#wrapper aside {[m
[32m+[m[32m                display: inline-block;[m
[32m+[m[32m                width: 21%;[m
[32m+[m[32m                padding-left: 3%;[m
[32m+[m[32m                padding-right: 6%;[m
[32m+[m[32m                /*background-color: chocolate;*/[m
[32m+[m[32m            }[m
[32m+[m
[32m+[m[32mbody div#wrapper aside section article:not(:last-child) {[m
[32m+[m[32m    margin-bottom: 10px;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper aside section article h3 {[m
[32m+[m[32m    font-size: 0.9em;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper aside section article a {[m
[32m+[m[32m    color: #9bd61f;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper aside section article p>span {[m
[32m+[m[32m    font-weight: bold;[m
[32m+[m[32m    display: inline-block;[m
[32m+[m[32m    margin-bottom: 20px;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper footer {[m
[32m+[m[32m    clear: both;[m
[32m+[m[32m    margin-top: 30px;[m
[32m+[m[32m    padding: 1px 0 50px 0;[m
[32m+[m[32m    background-color: #9bd61f;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper footer p {[m
[32m+[m[32m    padding-top: 30px;[m
[32m+[m[32m    padding-left: 120px;[m
[32m+[m[32m    border-top: 1px solid #baff25;[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects.zip b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects.zip[m
[1mnew file mode 100644[m
[1mindex 0000000..38d8293[m
Binary files /dev/null and b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects.zip differ
[1mdiff --git a/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/.name b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/.name[m
[1mnew file mode 100644[m
[1mindex 0000000..6f013ad[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/.name[m	
[36m@@ -0,0 +1 @@[m
[32m+[m[32m04. Loops Associative Arrays Objects[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/04. Loops Associative Arrays Objects.iml b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/04. Loops Associative Arrays Objects.iml[m
[1mnew file mode 100644[m
[1mindex 0000000..c956989[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/04. Loops Associative Arrays Objects.iml[m	
[36m@@ -0,0 +1,8 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<module type="WEB_MODULE" version="4">[m
[32m+[m[32m  <component name="NewModuleRootManager">[m
[32m+[m[32m    <content url="file://$MODULE_DIR$" />[m
[32m+[m[32m    <orderEntry type="inheritedJdk" />[m
[32m+[m[32m    <orderEntry type="sourceFolder" forTests="false" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m</module>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/misc.xml b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/misc.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..19f74da[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/misc.xml[m	
[36m@@ -0,0 +1,14 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ProjectLevelVcsManager" settingsEditedManually="false">[m
[32m+[m[32m    <OptionsSetting value="true" id="Add" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Remove" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Checkout" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Update" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Status" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Edit" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Add" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Remove" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectRootManager" version="2" />[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/modules.xml b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/modules.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..f580bee[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/modules.xml[m	
[36m@@ -0,0 +1,8 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ProjectModuleManager">[m
[32m+[m[32m    <modules>[m
[32m+[m[32m      <module fileurl="file://$PROJECT_DIR$/.idea/04. Loops Associative Arrays Objects.iml" filepath="$PROJECT_DIR$/.idea/04. Loops Associative Arrays Objects.iml" />[m
[32m+[m[32m    </modules>[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/vcs.xml b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/vcs.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..6564d52[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/vcs.xml[m	
[36m@@ -0,0 +1,6 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="VcsDirectoryMappings">[m
[32m+[m[32m    <mapping directory="" vcs="" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/workspace.xml b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/workspace.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..7a5a581[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/.idea/workspace.xml[m	
[36m@@ -0,0 +1,392 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ChangeListManager">[m
[32m+[m[32m    <list default="true" id="e6d43a87-a6a0-4d09-b298-11407f3ef688" name="Default" comment="" />[m
[32m+[m[32m    <ignored path="04. Loops Associative Arrays Objects.iws" />[m
[32m+[m[32m    <ignored path=".idea/workspace.xml" />[m
[32m+[m[32m    <ignored path=".idea/dataSources.local.xml" />[m
[32m+[m[32m    <option name="EXCLUDED_CONVERTED_TO_IGNORED" value="true" />[m
[32m+[m[32m    <option name="TRACKING_ENABLED" value="true" />[m
[32m+[m[32m    <option name="SHOW_DIALOG" value="false" />[m
[32m+[m[32m    <option name="HIGHLIGHT_CONFLICTS" value="true" />[m
[32m+[m[32m    <option name="HIGHLIGHT_NON_ACTIVE_CHANGELIST" value="false" />[m
[32m+[m[32m    <option name="LAST_RESOLUTION" value="IGNORE" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ChangesViewManager" flattened_view="true" show_ignored="false" />[m
[32m+[m[32m  <component name="CreatePatchCommitExecutor">[m
[32m+[m[32m    <option name="PATCH_PATH" value="" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ExecutionTargetManager" SELECTED_TARGET="default_target" />[m
[32m+[m[32m  <component name="FavoritesManager">[m
[32m+[m[32m    <favorites_list name="04. Loops Associative Arrays Objects" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="FileEditorManager">[m
[32m+[m[32m    <leaf>[m
[32m+[m[32m      <file leaf-file-name="group-people.js" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/01. Group People/group-people.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m              <caret line="33" column="72" selection-start-line="33" selection-start-column="72" selection-end-line="33" selection-end-column="72" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="uncle-scrooges-bag.js" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/02. Exam Problems/01. Uncle Scrooge's Bag/uncle-scrooges-bag.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m              <caret line="17" column="1" selection-start-line="17" selection-start-column="1" selection-end-line="17" selection-end-column="1" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="flea-racing.js" pinned="false" current-in-tab="true">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/02. Exam Problems/02. Flea Racing/flea-racing.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.16752137">[m
[32m+[m[32m              <caret line="24" column="7" selection-start-line="24" selection-start-column="7" selection-end-line="24" selection-end-column="7" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m    </leaf>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="FileTemplateManagerImpl">[m
[32m+[m[32m    <option name="RECENT_TEMPLATES">[m
[32m+[m[32m      <list>[m
[32m+[m[32m        <option value="Html5" />[m
[32m+[m[32m        <option value="JavaScript File" />[m
[32m+[m[32m      </list>[m
[32m+[m[32m    </option>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="IdeDocumentHistory">[m
[32m+[m[32m    <option name="CHANGED_PATHS">[m
[32m+[m[32m      <list>[m
[32m+[m[32m        <option value="$PROJECT_DIR$/01. Group People/test.html" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/01. Group People/group-people.js" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/02. Exam Problems/01. Uncle Scrooge's Bag/uncle-scrooges-bag.js" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/02. Exam Problems/02. Flea Racing/flea-racing.js" />[m
[32m+[m[32m      </list>[m
[32m+[m[32m    </option>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="JsBuildToolGruntFileManager" detection-done="true" />[m
[32m+[m[32m  <component name="JsGulpfileManager">[m
[32m+[m[32m    <detection-done>true</detection-done>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="NamedScopeManager">[m
[32m+[m[32m    <order />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PhpServers">[m
[32m+[m[32m    <servers />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PhpWorkspaceProjectConfiguration" backward_compatibility_performed="true" />[m
[32m+[m[32m  <component name="ProjectFrameBounds">[m
[32m+[m[32m    <option name="x" value="-8" />[m
[32m+[m[32m    <option name="y" value="-8" />[m
[32m+[m[32m    <option name="width" value="1382" />[m
[32m+[m[32m    <option name="height" value="744" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectLevelVcsManager" settingsEditedManually="false">[m
[32m+[m[32m    <OptionsSetting value="true" id="Add" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Remove" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Checkout" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Update" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Status" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Edit" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Add" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Remove" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectView">[m
[32m+[m[32m    <navigator currentView="ProjectPane" proportions="" version="1">[m
[32m+[m[32m      <flattenPackages />[m
[32m+[m[32m      <showMembers />[m
[32m+[m[32m      <showModules />[m
[32m+[m[32m      <showLibraryContents />[m
[32m+[m[32m      <hideEmptyPackages />[m
[32m+[m[32m      <abbreviatePackageNames />[m
[32m+[m[32m      <autoscrollToSource />[m
[32m+[m[32m      <autoscrollFromSource />[m
[32m+[m[32m      <sortByType />[m
[32m+[m[32m    </navigator>[m
[32m+[m[32m    <panes>[m
[32m+[m[32m      <pane id="ProjectPane">[m
[32m+[m[32m        <subPane>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="04. Loops Associative Arrays Objects" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m        </subPane>[m
[32m+[m[32m      </pane>[m
[32m+[m[32m      <pane id="Scope" />[m
[32m+[m[32m      <pane id="Scratches" />[m
[32m+[m[32m    </panes>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PropertiesComponent">[m
[32m+[m[32m    <property name="WebServerToolWindowFactoryState" value="false" />[m
[32m+[m[32m    <property name="DefaultHtmlFileTemplate" value="Html5" />[m
[32m+[m[32m    <property name="FullScreen" value="false" />[m
[32m+[m[32m    <property name="recentsLimit" value="5" />[m
[32m+[m[32m    <property name="settings.editor.selected.configurable" value="preferences.pluginManager" />[m
[32m+[m[32m    <property name="settings.editor.splitter.proportion" value="0.2" />[m
[32m+[m[32m    <property name="js.buildTools.gulp.node_interpreter" value="C:\Program Files\nodejs\node.exe" />[m
[32m+[m[32m    <property name="js.buildTools.gulp.gulp_package_dir" value="" />[m
[32m+[m[32m    <property name="js.buildTools.grunt.node_interpreter" value="C:\Program Files\nodejs\node.exe" />[m
[32m+[m[32m    <property name="js.buildTools.grunt.grunt-cli.package" value="" />[m
[32m+[m[32m    <property name="last_opened_file_path" value="C:/Program Files/nodejs/node.exe" />[m
[32m+[m[32m    <property name="restartRequiresConfirmation" value="true" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="RunManager" selected="Node.js.flea-racing.js">[m
[32m+[m[32m    <configuration default="false" name="flea-racing.js" type="NodeJSConfigurationType" factoryName="Node.js" temporary="true" path-to-node="C:/Program Files/nodejs/node" path-to-js-file="flea-racing.js" working-dir="$PROJECT_DIR$/02. Exam Problems/02. Flea Racing">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="ChromiumRemoteDebugType" factoryName="Chromium Remote">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="FirefoxRemoteDebugType" factoryName="Firefox Remote">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="JavascriptDebugType" factoryName="JavaScript Debug">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="NodeJSConfigurationType" factoryName="Node.js" working-dir="">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="NodeJSRemoteDebug" factoryName="Node.js Remote Debug">[m
[32m+[m[32m      <node-js-remote-debug />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="NodeWebKit" factoryName="NW.js" exePath="C:/Program Files/nodejs/node.exe">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="NodeunitConfigurationType" factoryName="Nodeunit">[m
[32m+[m[32m      <setting name="nodePath" value="C:/Program Files/nodejs/node" />[m
[32m+[m[32m      <envs />[m
[32m+[m[32m      <setting name="passParentEnvVars" value="true" />[m
[32m+[m[32m      <setting name="nodeunitModuleDir" value="" />[m
[32m+[m[32m      <setting name="workingDirectory" value="$PROJECT_DIR$" />[m
[32m+[m[32m      <setting name="testType" value="JS_FILE" />[m
[32m+[m[32m      <setting name="jsFile" value="" />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PHPUnitRunConfigurationType" factoryName="PHPUnit">[m
[32m+[m[32m      <TestRunner />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PhpBehatConfigurationType" factoryName="Behat">[m
[32m+[m[32m      <BehatRunner />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PhpHttpRequestRunConfigurationType" factoryName="PHP HTTP Request">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PhpLocalRunConfigurationType" factoryName="PHP Console">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PhpUnitRemoteRunConfigurationType" factoryName="PHPUnit on Server">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="js.build_tools.grunt" factoryName="Grunt.js">[m
[32m+[m[32m      <pass-parent-env-vars value="true" />[m
[32m+[m[32m      <force value="false" />[m
[32m+[m[32m      <verbose value="false" />[m
[32m+[m[32m      <envs />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="js.build_tools.gulp" factoryName="Gulp.js">[m
[32m+[m[32m      <node-options />[m
[32m+[m[32m      <gulpfile />[m
[32m+[m[32m      <tasks />[m
[32m+[m[32m      <arguments />[m
[32m+[m[32m      <pass-parent-envs>true</pass-parent-envs>[m
[32m+[m[32m      <envs />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <list size="1">[m
[32m+[m[32m      <item index="0" class="java.lang.String" itemvalue="Node.js.flea-racing.js" />[m
[32m+[m[32m    </list>[m
[32m+[m[32m    <recent_temporary>[m
[32m+[m[32m      <list size="1">[m
[32m+[m[32m        <item index="0" class="java.lang.String" itemvalue="Node.js.flea-racing.js" />[m
[32m+[m[32m      </list>[m
[32m+[m[32m    </recent_temporary>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ShelveChangesManager" show_recycled="false" />[m
[32m+[m[32m  <component name="SvnConfiguration">[m
[32m+[m[32m    <configuration />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="TaskManager">[m
[32m+[m[32m    <task active="true" id="Default" summary="Default task">[m
[32m+[m[32m      <changelist id="e6d43a87-a6a0-4d09-b298-11407f3ef688" name="Default" comment="" />[m
[32m+[m[32m      <created>1453053464668</created>[m
[32m+[m[32m      <option name="number" value="Default" />[m
[32m+[m[32m      <updated>1453053464668</updated>[m
[32m+[m[32m    </task>[m
[32m+[m[32m    <servers />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ToolWindowManager">[m
[32m+[m[32m    <frame x="-8" y="-8" width="1382" height="744" extended-state="6" />[m
[32m+[m[32m    <editor active="false" />[m
[32m+[m[32m    <layout>[m
[32m+[m[32m      <window_info id="Project" active="true" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="true" weight="0.2647504" sideWeight="0.5" order="0" side_tool="false" content_ui="combo" />[m
[32m+[m[32m      <window_info id="TODO" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="6" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Event Log" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.32952693" sideWeight="0.5" order="7" side_tool="true" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Application Servers" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="7" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Database" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="3" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Version Control" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="7" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Structure" active="false" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="1" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Terminal" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="7" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Favorites" active="false" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="2" side_tool="true" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Cvs" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="4" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Message" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="0" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Commander" active="false" anchor="right" auto_hide="false" internal_type="SLIDING" type="SLIDING" visible="false" weight="0.4" sideWeight="0.5" order="0" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Inspection" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.4" sideWeight="0.5" order="5" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Run" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.32952693" sideWeight="0.5" order="2" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Hierarchy" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="2" side_tool="false" content_ui="combo" />[m
[32m+[m[32m      <window_info id="Find" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="1" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Ant Build" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="1" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Debug" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.4" sideWeight="0.5" order="3" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m    </layout>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="Vcs.Log.UiProperties">[m
[32m+[m[32m    <option name="RECENTLY_FILTERED_USER_GROUPS">[m
[32m+[m[32m      <collection />[m
[32m+[m[32m    </option>[m
[32m+[m[32m    <option name="RECENTLY_FILTERED_BRANCH_GROUPS">[m
[32m+[m[32m      <collection />[m
[32m+[m[32m    </option>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="VcsContentAnnotationSettings">[m
[32m+[m[32m    <option name="myLimit" value="2678400000" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="XDebuggerManager">[m
[32m+[m[32m    <breakpoint-manager />[m
[32m+[m[32m    <watches-manager />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="editorHistoryManager">[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/01. Group People/group-people.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="33" column="72" selection-start-line="33" selection-start-column="72" selection-end-line="33" selection-end-column="72" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Exam Problems/01. Uncle Scrooge's Bag/uncle-scrooges-bag.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="17" column="1" selection-start-line="17" selection-start-column="1" selection-end-line="17" selection-end-column="1" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Exam Problems/02. Flea Racing/flea-racing.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="0" column="0" selection-start-line="0" selection-start-column="0" selection-end-line="0" selection-end-column="0" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/01. Group People/group-people.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="33" column="72" selection-start-line="33" selection-start-column="72" selection-end-line="33" selection-end-column="72" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Exam Problems/01. Uncle Scrooge's Bag/uncle-scrooges-bag.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="17" column="1" selection-start-line="17" selection-start-column="1" selection-end-line="17" selection-end-column="1" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Exam Problems/02. Flea Racing/flea-racing.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="0" column="0" selection-start-line="0" selection-start-column="0" selection-end-line="0" selection-end-column="0" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/01. Group People/group-people.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="33" column="72" selection-start-line="33" selection-start-column="72" selection-end-line="33" selection-end-column="72" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Exam Problems/01. Uncle Scrooge's Bag/uncle-scrooges-bag.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="17" column="1" selection-start-line="17" selection-start-column="1" selection-end-line="17" selection-end-column="1" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Exam Problems/02. Flea Racing/flea-racing.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="0" column="0" selection-start-line="0" selection-start-column="0" selection-end-line="0" selection-end-column="0" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/01. Group People/group-people.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="33" column="72" selection-start-line="33" selection-start-column="72" selection-end-line="33" selection-end-column="72" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Exam Problems/01. Uncle Scrooge's Bag/uncle-scrooges-bag.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="17" column="1" selection-start-line="17" selection-start-column="1" selection-end-line="17" selection-end-column="1" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Exam Problems/02. Flea Racing/flea-racing.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="0" column="0" selection-start-line="0" selection-start-column="0" selection-end-line="0" selection-end-column="0" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/01. Group People/group-people.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="33" column="72" selection-start-line="33" selection-start-column="72" selection-end-line="33" selection-end-column="72" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Exam Problems/01. Uncle Scrooge's Bag/uncle-scrooges-bag.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="17" column="1" selection-start-line="17" selection-start-column="1" selection-end-line="17" selection-end-column="1" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Exam Problems/02. Flea Racing/flea-racing.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.16752137">[m
[32m+[m[32m          <caret line="24" column="7" selection-start-line="24" selection-start-column="7" selection-end-line="24" selection-end-column="7" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/01. Group People/group-people.js b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/01. Group People/group-people.js[m
[1mnew file mode 100644[m
[1mindex 0000000..e5b76a4[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/01. Group People/group-people.js[m	
[36m@@ -0,0 +1,36 @@[m
[32m+[m[32mfunction Person(firstName, lastName, age) {[m
[32m+[m[32m    this.firstName = firstName;[m
[32m+[m[32m    this.lastName = lastName;[m
[32m+[m[32m    this.age = age;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mvar people = [[m
[32m+[m[32m    new Person("Scott", "Guthrie", 38),[m
[32m+[m[32m    new Person("Scott", "Johns", 36),[m
[32m+[m[32m    new Person("Scott", "Hanselman", 39),[m
[32m+[m[32m    new Person("Jesse", "Liberty", 57),[m
[32m+[m[32m    new Person("Jon", "Skeet", 38)[m
[32m+[m[32m];[m
[32m+[m
[32m+[m[32mfunction groupBy(criteria) {[m
[32m+[m[32m    var groupedPeople = {};[m
[32m+[m[32m    for(var index in people) {[m
[32m+[m[32m        var key = people[index][criteria];[m
[32m+[m[32m        if(groupedPeople[key] == undefined){[m
[32m+[m[32m            groupedPeople[key] = [];[m
[32m+[m[32m        }[m
[32m+[m[32m        groupedPeople[key].unshift(people[index]);[m
[32m+[m[32m    }[m
[32m+[m[32m    return groupedPeople;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mfunction printPeople(groupedPeople) {[m
[32m+[m[32m    for(var group in groupedPeople) {[m
[32m+[m[32m        var curGroup = [];[m
[32m+[m[32m        for(var index in groupedPeople[group]) {[m
[32m+[m[32m            var curPerson = groupedPeople[group][index];[m
[32m+[m[32m            curGroup.unshift(curPerson.firstName + ' ' + curPerson.lastName + '(age ' + curPerson.age + ')');[m
[32m+[m[32m        }[m
[32m+[m[32m        console.log("Group " + group + " : [" + curGroup.join(', ') + ']');[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/02. Exam Problems/01. Uncle Scrooge's Bag/uncle-scrooges-bag.js b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/02. Exam Problems/01. Uncle Scrooge's Bag/uncle-scrooges-bag.js[m
[1mnew file mode 100644[m
[1mindex 0000000..71bba53[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/02. Exam Problems/01. Uncle Scrooge's Bag/uncle-scrooges-bag.js[m	
[36m@@ -0,0 +1,18 @@[m
[32m+[m[32mfunction solve(input) {[m
[32m+[m[32m    var sum = 0;[m
[32m+[m[32m    for(var index in input) {[m
[32m+[m[32m        var coin = input[index].split(' ')[0];[m
[32m+[m[32m        var coinValue = (Number)(input[index].split(' ')[1]);[m
[32m+[m
[32m+[m[32m        if(coin.toLowerCase() == 'coin' && coinValue % 1 == 0 && coinValue > 0) {[m
[32m+[m[32m            sum += coinValue;[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    var gold = Math.floor(sum / 100);[m
[32m+[m[32m    var silver = Math.floor((sum - gold * 100) / 10);[m
[32m+[m[32m    var bronze = (sum - gold * 100) - silver * 10;[m
[32m+[m[32m    console.log('gold : ' + gold);[m
[32m+[m[32m    console.log('silver : ' + silver);[m
[32m+[m[32m    console.log('bronze : ' + bronze);[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/02. Exam Problems/02. Flea Racing/flea-racing.js b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/02. Exam Problems/02. Flea Racing/flea-racing.js[m
[1mnew file mode 100644[m
[1mindex 0000000..12ed03e[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/04. Loops Associative Arrays Objects/02. Exam Problems/02. Flea Racing/flea-racing.js[m	
[36m@@ -0,0 +1,49 @@[m
[32m+[m[32mfunction solve(input) {[m
[32m+[m[32m    var jumpsAllowed = (Number)(input[0]);[m
[32m+[m[32m    var trackLength = (Number)(input[1]);[m
[32m+[m[32m    var fleas = [];[m
[32m+[m[32m    for(var fleaIndex = 2; fleaIndex < input.length; fleaIndex++) {[m
[32m+[m[32m        var flea = {name: input[fleaIndex].split(', ')[0], jumps: (Number)(input[fleaIndex].split(', ')[1]), currentPosition: 1};[m
[32m+[m[32m        fleas.unshift(flea);[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    var reversedFleas = fleas.reverse();[m
[32m+[m
[32m+[m[32m    var winner;[m
[32m+[m[32m    for(var move = 0; move <= jumpsAllowed; move++) {[m
[32m+[m[32m        var hasBreak = false;[m
[32m+[m[32m        for(var fleaInd in reversedFleas) {[m
[32m+[m[32m            var currentFlea = reversedFleas[fleaInd];[m
[32m+[m[32m            currentFlea.currentPosition += currentFlea.jumps;[m
[32m+[m[32m            if(currentFlea.currentPosition >= trackLength) {[m
[32m+[m[32m                currentFlea.currentPosition = trackLength;[m
[32m+[m[32m                winner = currentFlea;[m
[32m+[m[32m                hasBreak = true;[m
[32m+[m[32m                break;[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
[32m+[m[32m        if(hasBreak) {[m
[32m+[m[32m            break;[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    if(winner == undefined) {[m
[32m+[m[32m        var maxDistance = 0;[m
[32m+[m[32m        for(var ind in fleas) {[m
[32m+[m[32m            if(flea[ind].currentPosition >= maxDistance) {[m
[32m+[m[32m                winner = flea[ind];[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    var audience = Array(trackLength + 1).join('#');[m
[32m+[m[32m    console.log(audience);[m
[32m+[m[32m    console.log(audience);[m
[32m+[m[32m    for(var fleaInd in fleas) {[m
[32m+[m[32m        var currentFlea = reversedFleas[fleaInd];[m
[32m+[m[32m        console.log(Array(currentFlea.currentPosition).join('.') + currentFlea.name.toUpperCase()[0] + Array(trackLength + 1 - currentFlea.currentPosition).join('.'));[m
[32m+[m[32m    }[m
[32m+[m[32m    console.log(audience);[m
[32m+[m[32m    console.log(audience);[m
[32m+[m[32m    console.log('Winner: ' + winner.name);[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions.zip b/JavaScript Basics/Homeworks/05. Functions.zip[m
[1mnew file mode 100644[m
[1mindex 0000000..0700785[m
Binary files /dev/null and b/JavaScript Basics/Homeworks/05. Functions.zip differ
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/.idea/.name b/JavaScript Basics/Homeworks/05. Functions/.idea/.name[m
[1mnew file mode 100644[m
[1mindex 0000000..2cef358[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/.idea/.name[m	
[36m@@ -0,0 +1 @@[m
[32m+[m[32m05. Functions[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/.idea/05. Functions.iml b/JavaScript Basics/Homeworks/05. Functions/.idea/05. Functions.iml[m
[1mnew file mode 100644[m
[1mindex 0000000..c956989[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/.idea/05. Functions.iml[m	
[36m@@ -0,0 +1,8 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<module type="WEB_MODULE" version="4">[m
[32m+[m[32m  <component name="NewModuleRootManager">[m
[32m+[m[32m    <content url="file://$MODULE_DIR$" />[m
[32m+[m[32m    <orderEntry type="inheritedJdk" />[m
[32m+[m[32m    <orderEntry type="sourceFolder" forTests="false" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m</module>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/.idea/misc.xml b/JavaScript Basics/Homeworks/05. Functions/.idea/misc.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..19f74da[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/.idea/misc.xml[m	
[36m@@ -0,0 +1,14 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ProjectLevelVcsManager" settingsEditedManually="false">[m
[32m+[m[32m    <OptionsSetting value="true" id="Add" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Remove" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Checkout" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Update" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Status" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Edit" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Add" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Remove" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectRootManager" version="2" />[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/.idea/modules.xml b/JavaScript Basics/Homeworks/05. Functions/.idea/modules.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..61c18c1[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/.idea/modules.xml[m	
[36m@@ -0,0 +1,8 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ProjectModuleManager">[m
[32m+[m[32m    <modules>[m
[32m+[m[32m      <module fileurl="file://$PROJECT_DIR$/.idea/05. Functions.iml" filepath="$PROJECT_DIR$/.idea/05. Functions.iml" />[m
[32m+[m[32m    </modules>[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/.idea/vcs.xml b/JavaScript Basics/Homeworks/05. Functions/.idea/vcs.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..6564d52[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/.idea/vcs.xml[m	
[36m@@ -0,0 +1,6 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="VcsDirectoryMappings">[m
[32m+[m[32m    <mapping directory="" vcs="" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/.idea/workspace.xml b/JavaScript Basics/Homeworks/05. Functions/.idea/workspace.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..4ee809f[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/.idea/workspace.xml[m	
[36m@@ -0,0 +1,554 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ChangeListManager">[m
[32m+[m[32m    <list default="true" id="5800bb93-8c2d-4ab4-8b7b-b11f5899c8d4" name="Default" comment="" />[m
[32m+[m[32m    <ignored path="05. Functions.iws" />[m
[32m+[m[32m    <ignored path=".idea/workspace.xml" />[m
[32m+[m[32m    <ignored path=".idea/dataSources.local.xml" />[m
[32m+[m[32m    <option name="EXCLUDED_CONVERTED_TO_IGNORED" value="true" />[m
[32m+[m[32m    <option name="TRACKING_ENABLED" value="true" />[m
[32m+[m[32m    <option name="SHOW_DIALOG" value="false" />[m
[32m+[m[32m    <option name="HIGHLIGHT_CONFLICTS" value="true" />[m
[32m+[m[32m    <option name="HIGHLIGHT_NON_ACTIVE_CHANGELIST" value="false" />[m
[32m+[m[32m    <option name="LAST_RESOLUTION" value="IGNORE" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ChangesViewManager" flattened_view="true" show_ignored="false" />[m
[32m+[m[32m  <component name="CreatePatchCommitExecutor">[m
[32m+[m[32m    <option name="PATCH_PATH" value="" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ExecutionTargetManager" SELECTED_TARGET="default_target" />[m
[32m+[m[32m  <component name="FavoritesManager">[m
[32m+[m[32m    <favorites_list name="05. Functions" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="FileEditorManager">[m
[32m+[m[32m    <leaf>[m
[32m+[m[32m      <file leaf-file-name="array-object-extractor.js" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/01. Array Object Extractor/array-object-extractor.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m              <caret line="13" column="36" selection-start-line="13" selection-start-column="36" selection-end-line="13" selection-end-column="36" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="strings-letter-organiser.js" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/02. Strings Letter Organiser/strings-letter-organiser.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m              <caret line="13" column="46" selection-start-line="13" selection-start-column="46" selection-end-line="13" selection-end-column="46" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="find-youngest-person.js" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/03. Find Youngest Person That Has A Smartphone/find-youngest-person.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m              <caret line="23" column="27" selection-start-line="23" selection-start-column="27" selection-end-line="23" selection-end-column="27" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="count-of-divs.js" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/04. Count Number Of Divs/count-of-divs.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m              <caret line="21" column="13" selection-start-line="21" selection-start-column="13" selection-end-line="21" selection-end-column="13" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="array-prototype-function.js" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/05. Array Prototype Function/array-prototype-function.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m              <caret line="15" column="36" selection-start-line="15" selection-start-column="36" selection-end-line="15" selection-end-column="36" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="deep-copy-of-object.js" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/06. Deep Copy Of Object/deep-copy-of-object.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m              <caret line="19" column="32" selection-start-line="19" selection-start-column="32" selection-end-line="19" selection-end-column="32" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="prices-trends.js" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/07. Exam Problems/01. Prices Trends/prices-trends.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m              <caret line="24" column="1" selection-start-line="24" selection-start-column="1" selection-end-line="24" selection-end-column="1" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="biggest-table-row.js" pinned="false" current-in-tab="true">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/07. Exam Problems/03. Biggest Table Row/biggest-table-row.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.74871796">[m
[32m+[m[32m              <caret line="30" column="56" selection-start-line="30" selection-start-column="56" selection-end-line="30" selection-end-column="56" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m    </leaf>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="FileTemplateManagerImpl">[m
[32m+[m[32m    <option name="RECENT_TEMPLATES">[m
[32m+[m[32m      <list>[m
[32m+[m[32m        <option value="JavaScript File" />[m
[32m+[m[32m      </list>[m
[32m+[m[32m    </option>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="IdeDocumentHistory">[m
[32m+[m[32m    <option name="CHANGED_PATHS">[m
[32m+[m[32m      <list>[m
[32m+[m[32m        <option value="$PROJECT_DIR$/01. Array Object Extractor/array-object-extractor.js" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/02. Strings Letter Organiser/strings-letter-organiser.js" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/03. Find Youngest Person That Has A Smartphone/find-youngest-person.js" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/04. Count Number Of Divs/count-of-divs.js" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/05. Array Prototype Function/array-prototype-function.js" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/06. Deep Copy Of Object/deep-copy-of-object.js" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/07. Exam Problems/01. Prices Trends/prices-trends.js" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/07. Exam Problems/03. Biggest Table Row/biggest-table-row.js" />[m
[32m+[m[32m      </list>[m
[32m+[m[32m    </option>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="JsBuildToolGruntFileManager" detection-done="true" />[m
[32m+[m[32m  <component name="JsGulpfileManager">[m
[32m+[m[32m    <detection-done>true</detection-done>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="NamedScopeManager">[m
[32m+[m[32m    <order />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PhpServers">[m
[32m+[m[32m    <servers />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PhpWorkspaceProjectConfiguration" backward_compatibility_performed="true" />[m
[32m+[m[32m  <component name="ProjectFrameBounds">[m
[32m+[m[32m    <option name="x" value="-8" />[m
[32m+[m[32m    <option name="y" value="-8" />[m
[32m+[m[32m    <option name="width" value="1382" />[m
[32m+[m[32m    <option name="height" value="744" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectLevelVcsManager" settingsEditedManually="false">[m
[32m+[m[32m    <OptionsSetting value="true" id="Add" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Remove" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Checkout" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Update" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Status" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Edit" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Add" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Remove" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectView">[m
[32m+[m[32m    <navigator currentView="ProjectPane" proportions="" version="1">[m
[32m+[m[32m      <flattenPackages />[m
[32m+[m[32m      <showMembers />[m
[32m+[m[32m      <showModules />[m
[32m+[m[32m      <showLibraryContents />[m
[32m+[m[32m      <hideEmptyPackages />[m
[32m+[m[32m      <abbreviatePackageNames />[m
[32m+[m[32m      <autoscrollToSource />[m
[32m+[m[32m      <autoscrollFromSource />[m
[32m+[m[32m      <sortByType />[m
[32m+[m[32m    </navigator>[m
[32m+[m[32m    <panes>[m
[32m+[m[32m      <pane id="Scratches" />[m
[32m+[m[32m      <pane id="ProjectPane">[m
[32m+[m[32m        <subPane>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="07. Exam Problems" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="03. Biggest Table Row" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="07. Exam Problems" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="01. Prices Trends" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="06. Deep Copy Of Object" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Array Prototype Function" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="04. Count Number Of Divs" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="03. Find Youngest Person That Has A Smartphone" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="02. Strings Letter Organiser" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="05. Functions" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="01. Array Object Extractor" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m        </subPane>[m
[32m+[m[32m      </pane>[m
[32m+[m[32m      <pane id="Scope" />[m
[32m+[m[32m    </panes>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PropertiesComponent">[m
[32m+[m[32m    <property name="WebServerToolWindowFactoryState" value="false" />[m
[32m+[m[32m    <property name="recentsLimit" value="5" />[m
[32m+[m[32m    <property name="settings.editor.selected.configurable" value="preferences.keymap" />[m
[32m+[m[32m    <property name="settings.editor.splitter.proportion" value="0.2" />[m
[32m+[m[32m    <property name="FullScreen" value="false" />[m
[32m+[m[32m    <property name="last_opened_file_path" value="C:/Workplace/Maxverf/Maxverf" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="RunManager" selected="Node.js.biggest-table-row.js">[m
[32m+[m[32m    <configuration default="false" name="count-of-divs.js" type="NodeJSConfigurationType" factoryName="Node.js" temporary="true" path-to-node="C:/Program Files/nodejs/node" path-to-js-file="count-of-divs.js" working-dir="$PROJECT_DIR$/04. Count Number Of Divs">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="false" name="array-prototype-function.js" type="NodeJSConfigurationType" factoryName="Node.js" temporary="true" path-to-node="C:/Program Files/nodejs/node" path-to-js-file="array-prototype-function.js" working-dir="$PROJECT_DIR$/05. Array Prototype Function">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="false" name="deep-copy-of-object.js" type="NodeJSConfigurationType" factoryName="Node.js" temporary="true" path-to-node="C:/Program Files/nodejs/node" path-to-js-file="deep-copy-of-object.js" working-dir="$PROJECT_DIR$/06. Deep Copy Of Object">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="false" name="prices-trends.js" type="NodeJSConfigurationType" factoryName="Node.js" temporary="true" path-to-node="C:/Program Files/nodejs/node" path-to-js-file="prices-trends.js" working-dir="$PROJECT_DIR$/07. Exam Problems/01. Prices Trends">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="false" name="biggest-table-row.js" type="NodeJSConfigurationType" factoryName="Node.js" temporary="true" path-to-node="C:/Program Files/nodejs/node" path-to-js-file="biggest-table-row.js" working-dir="$PROJECT_DIR$/07. Exam Problems/03. Biggest Table Row">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="JavascriptDebugType" factoryName="JavaScript Debug">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="NodeJSConfigurationType" factoryName="Node.js" working-dir="">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PHPUnitRunConfigurationType" factoryName="PHPUnit">[m
[32m+[m[32m      <TestRunner />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PhpBehatConfigurationType" factoryName="Behat">[m
[32m+[m[32m      <BehatRunner />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PhpLocalRunConfigurationType" factoryName="PHP Console">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="PhpUnitRemoteRunConfigurationType" factoryName="PHPUnit on Server">[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <configuration default="true" type="js.build_tools.gulp" factoryName="Gulp.js">[m
[32m+[m[32m      <node-options />[m
[32m+[m[32m      <gulpfile />[m
[32m+[m[32m      <tasks />[m
[32m+[m[32m      <arguments />[m
[32m+[m[32m      <pass-parent-envs>true</pass-parent-envs>[m
[32m+[m[32m      <envs />[m
[32m+[m[32m      <method />[m
[32m+[m[32m    </configuration>[m
[32m+[m[32m    <list size="5">[m
[32m+[m[32m      <item index="0" class="java.lang.String" itemvalue="Node.js.count-of-divs.js" />[m
[32m+[m[32m      <item index="1" class="java.lang.String" itemvalue="Node.js.array-prototype-function.js" />[m
[32m+[m[32m      <item index="2" class="java.lang.String" itemvalue="Node.js.deep-copy-of-object.js" />[m
[32m+[m[32m      <item index="3" class="java.lang.String" itemvalue="Node.js.prices-trends.js" />[m
[32m+[m[32m      <item index="4" class="java.lang.String" itemvalue="Node.js.biggest-table-row.js" />[m
[32m+[m[32m    </list>[m
[32m+[m[32m    <recent_temporary>[m
[32m+[m[32m      <list size="5">[m
[32m+[m[32m        <item index="0" class="java.lang.String" itemvalue="Node.js.biggest-table-row.js" />[m
[32m+[m[32m        <item index="1" class="java.lang.String" itemvalue="Node.js.prices-trends.js" />[m
[32m+[m[32m        <item index="2" class="java.lang.String" itemvalue="Node.js.deep-copy-of-object.js" />[m
[32m+[m[32m        <item index="3" class="java.lang.String" itemvalue="Node.js.array-prototype-function.js" />[m
[32m+[m[32m        <item index="4" class="java.lang.String" itemvalue="Node.js.count-of-divs.js" />[m
[32m+[m[32m      </list>[m
[32m+[m[32m    </recent_temporary>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ShelveChangesManager" show_recycled="false" />[m
[32m+[m[32m  <component name="SvnConfiguration">[m
[32m+[m[32m    <configuration />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="TaskManager">[m
[32m+[m[32m    <task active="true" id="Default" summary="Default task">[m
[32m+[m[32m      <changelist id="5800bb93-8c2d-4ab4-8b7b-b11f5899c8d4" name="Default" comment="" />[m
[32m+[m[32m      <created>1453214984777</created>[m
[32m+[m[32m      <option name="number" value="Default" />[m
[32m+[m[32m      <updated>1453214984777</updated>[m
[32m+[m[32m    </task>[m
[32m+[m[32m    <servers />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ToolWindowManager">[m
[32m+[m[32m    <frame x="-8" y="-8" width="1382" height="744" extended-state="6" />[m
[32m+[m[32m    <editor active="true" />[m
[32m+[m[32m    <layout>[m
[32m+[m[32m      <window_info id="Project" active="false" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="true" weight="0.25340393" sideWeight="0.5" order="1" side_tool="false" content_ui="combo" />[m
[32m+[m[32m      <window_info id="TODO" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="10" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Event Log" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.32952693" sideWeight="0.5" order="0" side_tool="true" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Application Servers" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="1" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Database" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="0" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Version Control" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="2" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Structure" active="false" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="2" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Terminal" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="3" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Favorites" active="false" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="0" side_tool="true" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Cvs" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="8" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Message" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="4" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Commander" active="false" anchor="right" auto_hide="false" internal_type="SLIDING" type="SLIDING" visible="false" weight="0.4" sideWeight="0.5" order="1" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Inspection" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.4" sideWeight="0.5" order="9" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Run" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.32952693" sideWeight="0.5" order="6" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Hierarchy" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="3" side_tool="false" content_ui="combo" />[m
[32m+[m[32m      <window_info id="Find" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.32952693" sideWeight="0.5" order="5" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Ant Build" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="2" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Debug" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.4" sideWeight="0.5" order="7" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m    </layout>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="Vcs.Log.UiProperties">[m
[32m+[m[32m    <option name="RECENTLY_FILTERED_USER_GROUPS">[m
[32m+[m[32m      <collection />[m
[32m+[m[32m    </option>[m
[32m+[m[32m    <option name="RECENTLY_FILTERED_BRANCH_GROUPS">[m
[32m+[m[32m      <collection />[m
[32m+[m[32m    </option>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="VcsContentAnnotationSettings">[m
[32m+[m[32m    <option name="myLimit" value="2678400000" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="XDebuggerManager">[m
[32m+[m[32m    <breakpoint-manager />[m
[32m+[m[32m    <watches-manager />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="editorHistoryManager">[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/01. Array Object Extractor/array-object-extractor.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="13" column="36" selection-start-line="13" selection-start-column="36" selection-end-line="13" selection-end-column="36" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Strings Letter Organiser/strings-letter-organiser.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="13" column="46" selection-start-line="13" selection-start-column="46" selection-end-line="13" selection-end-column="46" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/03. Find Youngest Person That Has A Smartphone/find-youngest-person.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="23" column="27" selection-start-line="23" selection-start-column="27" selection-end-line="23" selection-end-column="27" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/04. Count Number Of Divs/count-of-divs.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="21" column="13" selection-start-line="21" selection-start-column="13" selection-end-line="21" selection-end-column="13" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/05. Array Prototype Function/array-prototype-function.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="15" column="36" selection-start-line="15" selection-start-column="36" selection-end-line="15" selection-end-column="36" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/06. Deep Copy Of Object/deep-copy-of-object.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="19" column="32" selection-start-line="19" selection-start-column="32" selection-end-line="19" selection-end-column="32" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/07. Exam Problems/01. Prices Trends/prices-trends.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="24" column="1" selection-start-line="24" selection-start-column="1" selection-end-line="24" selection-end-column="1" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/07. Exam Problems/03. Biggest Table Row/biggest-table-row.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="0" column="0" selection-start-line="0" selection-start-column="0" selection-end-line="0" selection-end-column="0" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/01. Array Object Extractor/array-object-extractor.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="13" column="36" selection-start-line="13" selection-start-column="36" selection-end-line="13" selection-end-column="36" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/02. Strings Letter Organiser/strings-letter-organiser.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="13" column="46" selection-start-line="13" selection-start-column="46" selection-end-line="13" selection-end-column="46" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/03. Find Youngest Person That Has A Smartphone/find-youngest-person.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="23" column="27" selection-start-line="23" selection-start-column="27" selection-end-line="23" selection-end-column="27" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/06. Deep Copy Of Object/deep-copy-of-object.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="19" column="32" selection-start-line="19" selection-start-column="32" selection-end-line="19" selection-end-column="32" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/07. Exam Problems/01. Prices Trends/prices-trends.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="24" column="1" selection-start-line="24" selection-start-column="1" selection-end-line="24" selection-end-column="1" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/05. Array Prototype Function/array-prototype-function.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="15" column="36" selection-start-line="15" selection-start-column="36" selection-end-line="15" selection-end-column="36" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/04. Count Number Of Divs/count-of-divs.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="21" column="13" selection-start-line="21" selection-start-column="13" selection-end-line="21" selection-end-column="13" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/07. Exam Problems/03. Biggest Table Row/biggest-table-row.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.74871796">[m
[32m+[m[32m          <caret line="30" column="56" selection-start-line="30" selection-start-column="56" selection-end-line="30" selection-end-column="56" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/01. Array Object Extractor/array-object-extractor.js b/JavaScript Basics/Homeworks/05. Functions/01. Array Object Extractor/array-object-extractor.js[m
[1mnew file mode 100644[m
[1mindex 0000000..4bf4d92[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/01. Array Object Extractor/array-object-extractor.js[m	
[36m@@ -0,0 +1,27 @@[m
[32m+[m[32mfunction extractObjects(array) {[m
[32m+[m[32m    var newArray = [];[m
[32m+[m[32m    array.forEach(function (element) {[m
[32m+[m[32m       if(isObject(element)) {[m
[32m+[m[32m           newArray.unshift(element);[m
[32m+[m[32m       }[m
[32m+[m[32m    });[m
[32m+[m
[32m+[m[32m    return newArray;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32misObject = function(a) {[m
[32m+[m[32m    //console.log(a.constructor);  // If you don't know how .constructor works, uncomment this[m
[32m+[m[32m    return a.constructor === Object;[m
[32m+[m[32m};[m
[32m+[m
[32m+[m[32mconsole.log(extractObjects([[m
[32m+[m[32m        "Pesho",[m
[32m+[m[32m        4,[m
[32m+[m[32m        4.21,[m
[32m+[m[32m        { name : 'Valyo', age : 16 },[m
[32m+[m[32m        { type : 'fish', model : 'zlatna ribka' },[m
[32m+[m[32m        [1,2,3],[m
[32m+[m[32m        "Gosho",[m
[32m+[m[32m        { name : 'Penka', height: 1.65}[m
[32m+[m[32m    ][m
[32m+[m[32m));[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/02. Strings Letter Organiser/strings-letter-organiser.js b/JavaScript Basics/Homeworks/05. Functions/02. Strings Letter Organiser/strings-letter-organiser.js[m
[1mnew file mode 100644[m
[1mindex 0000000..37e74b9[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/02. Strings Letter Organiser/strings-letter-organiser.js[m	
[36m@@ -0,0 +1,14 @@[m
[32m+[m[32mfunction sortLetters(word, reversed) {[m
[32m+[m[32m    var sorted = word.split('').sort(function (a, b) {[m
[32m+[m[32m        return a.toLowerCase() > b.toLowerCase();[m
[32m+[m[32m    });[m
[32m+[m
[32m+[m[32m    if(!reversed) {[m
[32m+[m[32m        return sorted.reverse().join("");[m
[32m+[m[32m    } else {[m
[32m+[m[32m        return sorted.join("");[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mconsole.log(sortLetters('HelloWorld', true));[m
[32m+[m[32mconsole.log(sortLetters('HelloWorld', false));[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/03. Find Youngest Person That Has A Smartphone/find-youngest-person.js b/JavaScript Basics/Homeworks/05. Functions/03. Find Youngest Person That Has A Smartphone/find-youngest-person.js[m
[1mnew file mode 100644[m
[1mindex 0000000..bcb4c06[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/03. Find Youngest Person That Has A Smartphone/find-youngest-person.js[m	
[36m@@ -0,0 +1,24 @@[m
[32m+[m[32mfunction findYoungestPerson(array) {[m
[32m+[m[32m    var peopleWithSmartphones = array.filter(function (person) {[m
[32m+[m[32m        return person.hasSmartphone;[m
[32m+[m[32m    });[m
[32m+[m
[32m+[m[32m    var youngestPerson = peopleWithSmartphones[0];[m
[32m+[m
[32m+[m[32m    for (var index in peopleWithSmartphones) {[m
[32m+[m[32m        var currentPerson = peopleWithSmartphones[index];[m
[32m+[m[32m        if (currentPerson.age < youngestPerson.age) {[m
[32m+[m[32m            youngestPerson = currentPerson;[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    console.log('The youngest person is ' + youngestPerson.firstname + ' ' + youngestPerson.lastname);[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mvar people = [[m
[32m+[m[32m    { firstname : 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },[m
[32m+[m[32m    { firstname : 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },[m
[32m+[m[32m    { firstname : 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },[m
[32m+[m[32m    { firstname : 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }];[m
[32m+[m
[32m+[m[32mfindYoungestPerson(people);[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/04. Count Number Of Divs/count-of-divs.js b/JavaScript Basics/Homeworks/05. Functions/04. Count Number Of Divs/count-of-divs.js[m
[1mnew file mode 100644[m
[1mindex 0000000..cf12da2[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/04. Count Number Of Divs/count-of-divs.js[m	
[36m@@ -0,0 +1,28 @@[m
[32m+[m[32mfunction countOfDivs(html) {[m
[32m+[m[32m    var count = 0;[m
[32m+[m[32m    var regex = /\<div.*?\>/g;[m
[32m+[m[32m    while (regex.exec(html)) {[m
[32m+[m[32m        count++;[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    return count;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mconsole.log(countOfDivs('<!DOCTYPE html>' +[m
[32m+[m[32m    '<html>' +[m
[32m+[m[32m    '<head lang="en">' +[m
[32m+[m[32m    '<meta charset="UTF-8">' +[m
[32m+[m[32m    '<title>index</title>' +[m
[32m+[m[32m    '<script src="/yourScript.js" defer></script>' +[m
[32m+[m[32m    '</head>' +[m
[32m+[m[32m    '<body>' +[m
[32m+[m[32m    '<div id="outerDiv">' +[m
[32m+[m[32m    '<div' +[m
[32m+[m[32m    'class="first">' +[m
[32m+[m[32m    '<div><div>hello</div></div>' +[m
[32m+[m[32m    '</div>' +[m
[32m+[m[32m    '<div>hi<div></div></div>' +[m
[32m+[m[32m    '<div>I am a div</div>' +[m
[32m+[m[32m    '</div>' +[m
[32m+[m[32m    '</body>' +[m
[32m+[m[32m    '</html>'));[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/05. Array Prototype Function/array-prototype-function.js b/JavaScript Basics/Homeworks/05. Functions/05. Array Prototype Function/array-prototype-function.js[m
[1mnew file mode 100644[m
[1mindex 0000000..6f0bf6d[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/05. Array Prototype Function/array-prototype-function.js[m	
[36m@@ -0,0 +1,19 @@[m
[32m+[m[32mArray.prototype.removeItem = (function (item){[m
[32m+[m[32m    var newArray = [];[m
[32m+[m[32m    for (var index in this) {[m
[32m+[m[32m        if(this[index] !== item && typeof this[index] !== "function") {[m
[32m+[m[32m            newArray.push(this[index]);[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    return newArray;[m
[32m+[m[32m});[m
[32m+[m
[32m+[m[32mvar arr1 = [1, 2, 3, 2];[m
[32m+[m[32mconsole.log(arr1.removeItem(3));[m
[32m+[m
[32m+[m[32mvar arr2 = ['hi', 'bye', 'hello' ];[m
[32m+[m[32mconsole.log(arr2.removeItem('bye'));[m
[32m+[m
[32m+[m[32mvar arr3 = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];[m
[32m+[m[32mconsole.log(arr3.removeItem(1));[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/06. Deep Copy Of Object/deep-copy-of-object.js b/JavaScript Basics/Homeworks/05. Functions/06. Deep Copy Of Object/deep-copy-of-object.js[m
[1mnew file mode 100644[m
[1mindex 0000000..0aa41f0[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/06. Deep Copy Of Object/deep-copy-of-object.js[m	
[36m@@ -0,0 +1,26 @@[m
[32m+[m[32mfunction clone(obj) {[m
[32m+[m[32m    if(obj == null || typeof obj != 'object') {[m
[32m+[m[32m        return obj;[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    var copy = obj.constructor();[m
[32m+[m[32m    for (var attr in obj) {[m
[32m+[m[32m        if(obj.hasOwnProperty(attr)) {[m
[32m+[m[32m            copy[attr] = obj[attr];[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    return copy;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mfunction compareObjects(a, b) {[m
[32m+[m[32m    console.log(a == b);[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mvar a = {name: 'Pesho', age: 21}[m
[32m+[m[32mvar b = clone(a); // a deep copy[m
[32m+[m[32mcompareObjects(a, b);[m
[32m+[m
[32m+[m[32mvar c = {name: 'Pesho', age: 21} ;[m
[32m+[m[32mvar d = c; // not a deep copy[m
[32m+[m[32mcompareObjects(c, d);[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/07. Exam Problems/01. Prices Trends/prices-trends.js b/JavaScript Basics/Homeworks/05. Functions/07. Exam Problems/01. Prices Trends/prices-trends.js[m
[1mnew file mode 100644[m
[1mindex 0000000..954cd5c[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/07. Exam Problems/01. Prices Trends/prices-trends.js[m	
[36m@@ -0,0 +1,25 @@[m
[32m+[m[32mfunction solve(input) {[m
[32m+[m[32m    var numbers = input.map(Number);[m
[32m+[m
[32m+[m[32m    console.log('<table>\n<tr><th>Price</th><th>Trend</th></tr>');[m
[32m+[m
[32m+[m[32m    var previous = numbers.firstChild;[m
[32m+[m[32m    for (var index in numbers) {[m
[32m+[m[32m        var current = numbers[index].toFixed(2);[m
[32m+[m[32m        if(previous == undefined) {[m
[32m+[m[32m            previous = current;[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        if(current < previous) {[m
[32m+[m[32m            console.log('<tr><td>' + current + '</td><td><img src="down.png"/></td></td>');[m
[32m+[m[32m        } else if (current > previous) {[m
[32m+[m[32m            console.log('<tr><td>' + current + '</td><td><img src="up.png"/></td></td>');[m
[32m+[m[32m        } else {[m
[32m+[m[32m            console.log('<tr><td>' + current + '</td><td><img src="fixed.png"/></td></td>');[m
[32m+[m[32m        }[m
[32m+[m
[32m+[m[32m        previous = current;[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    console.log('</table>');[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Homeworks/05. Functions/07. Exam Problems/03. Biggest Table Row/biggest-table-row.js b/JavaScript Basics/Homeworks/05. Functions/07. Exam Problems/03. Biggest Table Row/biggest-table-row.js[m
[1mnew file mode 100644[m
[1mindex 0000000..8357d45[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Homeworks/05. Functions/07. Exam Problems/03. Biggest Table Row/biggest-table-row.js[m	
[36m@@ -0,0 +1,35 @@[m
[32m+[m[32mfunction solve(input) {[m
[32m+[m[32m    var maxSum = Number.NEGATIVE_INFINITY;[m
[32m+[m[32m    for(var index = 2; index < input.length - 1; index++) {[m
[32m+[m[32m        var line = input[index];[m
[32m+[m[32m        var matches = line.match(/<td>(.*?)<\/td>/g);[m
[32m+[m[32m        var sum = 0, values = [];[m
[32m+[m[32m        for(var matchIndex = 1; matchIndex < matches.length; matchIndex++) {[m
[32m+[m[32m            var currentMatch = matches[matchIndex];[m
[32m+[m[32m            var value = currentMatch.substring(4).substring(0, currentMatch.length - 9);[m
[32m+[m[32m            var num = Number(value.trim());[m
[32m+[m[32m            if(!isNaN(num)) {[m
[32m+[m[32m                sum += num;[m
[32m+[m[32m                values.push(value);[m
[32m+[m[32m            }[m
[32m+[m[32m        }[m
[32m+[m[32m        if(sum > maxSum && values.length > 0) {[m
[32m+[m[32m            maxSum = sum;[m
[32m+[m[32m            var output = sum + ' = ' + values.join(' + ');[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    if(maxSum != Number.NEGATIVE_INFINITY) {[m
[32m+[m[32m        console.log(output);[m
[32m+[m[32m    } else {[m
[32m+[m[32m        console.log('no data');[m
[32m+[m[32m    }[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32msolve(['<table>',[m
[32m+[m[32m        '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',[m
[32m+[m[32m        '<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>',[m
[32m+[m[32m        '<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>',[m
[32m+[m[32m        '<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',[m
[32m+[m[32m        '<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',[m
[32m+[m[32m    '</table>']);[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Other/Slider Test/.idea/.name b/JavaScript Basics/Other/Slider Test/.idea/.name[m
[1mnew file mode 100644[m
[1mindex 0000000..bcfc4fd[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Other/Slider Test/.idea/.name[m	
[36m@@ -0,0 +1 @@[m
[32m+[m[32mSlider Test[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Other/Slider Test/.idea/Slider Test.iml b/JavaScript Basics/Other/Slider Test/.idea/Slider Test.iml[m
[1mnew file mode 100644[m
[1mindex 0000000..c956989[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Other/Slider Test/.idea/Slider Test.iml[m	
[36m@@ -0,0 +1,8 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<module type="WEB_MODULE" version="4">[m
[32m+[m[32m  <component name="NewModuleRootManager">[m
[32m+[m[32m    <content url="file://$MODULE_DIR$" />[m
[32m+[m[32m    <orderEntry type="inheritedJdk" />[m
[32m+[m[32m    <orderEntry type="sourceFolder" forTests="false" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m</module>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Other/Slider Test/.idea/misc.xml b/JavaScript Basics/Other/Slider Test/.idea/misc.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..19f74da[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Other/Slider Test/.idea/misc.xml[m	
[36m@@ -0,0 +1,14 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ProjectLevelVcsManager" settingsEditedManually="false">[m
[32m+[m[32m    <OptionsSetting value="true" id="Add" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Remove" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Checkout" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Update" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Status" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Edit" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Add" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Remove" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectRootManager" version="2" />[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Other/Slider Test/.idea/modules.xml b/JavaScript Basics/Other/Slider Test/.idea/modules.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..08ece40[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Other/Slider Test/.idea/modules.xml[m	
[36m@@ -0,0 +1,8 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ProjectModuleManager">[m
[32m+[m[32m    <modules>[m
[32m+[m[32m      <module fileurl="file://$PROJECT_DIR$/.idea/Slider Test.iml" filepath="$PROJECT_DIR$/.idea/Slider Test.iml" />[m
[32m+[m[32m    </modules>[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Other/Slider Test/.idea/vcs.xml b/JavaScript Basics/Other/Slider Test/.idea/vcs.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..6564d52[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Other/Slider Test/.idea/vcs.xml[m	
[36m@@ -0,0 +1,6 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="VcsDirectoryMappings">[m
[32m+[m[32m    <mapping directory="" vcs="" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Other/Slider Test/.idea/workspace.xml b/JavaScript Basics/Other/Slider Test/.idea/workspace.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..2b8a0b3[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Other/Slider Test/.idea/workspace.xml[m	
[36m@@ -0,0 +1,287 @@[m
[32m+[m[32m<?xml version="1.0" encoding="UTF-8"?>[m
[32m+[m[32m<project version="4">[m
[32m+[m[32m  <component name="ChangeListManager">[m
[32m+[m[32m    <list default="true" id="cb0aa3bb-c111-4eb8-ad78-00e55d44cc25" name="Default" comment="" />[m
[32m+[m[32m    <ignored path="Slider Test.iws" />[m
[32m+[m[32m    <ignored path=".idea/workspace.xml" />[m
[32m+[m[32m    <ignored path=".idea/dataSources.local.xml" />[m
[32m+[m[32m    <option name="EXCLUDED_CONVERTED_TO_IGNORED" value="true" />[m
[32m+[m[32m    <option name="TRACKING_ENABLED" value="true" />[m
[32m+[m[32m    <option name="SHOW_DIALOG" value="false" />[m
[32m+[m[32m    <option name="HIGHLIGHT_CONFLICTS" value="true" />[m
[32m+[m[32m    <option name="HIGHLIGHT_NON_ACTIVE_CHANGELIST" value="false" />[m
[32m+[m[32m    <option name="LAST_RESOLUTION" value="IGNORE" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ChangesViewManager" flattened_view="true" show_ignored="false" />[m
[32m+[m[32m  <component name="CreatePatchCommitExecutor">[m
[32m+[m[32m    <option name="PATCH_PATH" value="" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ExecutionTargetManager" SELECTED_TARGET="default_target" />[m
[32m+[m[32m  <component name="FavoritesManager">[m
[32m+[m[32m    <favorites_list name="Slider Test" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="FileEditorManager">[m
[32m+[m[32m    <leaf>[m
[32m+[m[32m      <file leaf-file-name="index.html" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/index.html">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m              <caret line="24" column="14" selection-start-line="24" selection-start-column="14" selection-end-line="24" selection-end-column="14" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="style.css" pinned="false" current-in-tab="false">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/styles/style.css">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m              <caret line="84" column="16" selection-start-line="84" selection-start-column="16" selection-end-line="84" selection-end-column="16" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m      <file leaf-file-name="slider-animation.js" pinned="false" current-in-tab="true">[m
[32m+[m[32m        <entry file="file://$PROJECT_DIR$/js/slider-animation.js">[m
[32m+[m[32m          <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m            <state vertical-scroll-proportion="0.2905983">[m
[32m+[m[32m              <caret line="17" column="25" selection-start-line="17" selection-start-column="25" selection-end-line="17" selection-end-column="25" />[m
[32m+[m[32m              <folding />[m
[32m+[m[32m            </state>[m
[32m+[m[32m          </provider>[m
[32m+[m[32m        </entry>[m
[32m+[m[32m      </file>[m
[32m+[m[32m    </leaf>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="IdeDocumentHistory">[m
[32m+[m[32m    <option name="CHANGED_PATHS">[m
[32m+[m[32m      <list>[m
[32m+[m[32m        <option value="$PROJECT_DIR$/index.html" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/styles/style.css" />[m
[32m+[m[32m        <option value="$PROJECT_DIR$/js/slider-animation.js" />[m
[32m+[m[32m      </list>[m
[32m+[m[32m    </option>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="JsBuildToolGruntFileManager" detection-done="true" />[m
[32m+[m[32m  <component name="JsGulpfileManager">[m
[32m+[m[32m    <detection-done>true</detection-done>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="NamedScopeManager">[m
[32m+[m[32m    <order />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PhpServers">[m
[32m+[m[32m    <servers />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PhpWorkspaceProjectConfiguration" backward_compatibility_performed="true" />[m
[32m+[m[32m  <component name="ProjectFrameBounds">[m
[32m+[m[32m    <option name="x" value="-8" />[m
[32m+[m[32m    <option name="y" value="-8" />[m
[32m+[m[32m    <option name="width" value="1382" />[m
[32m+[m[32m    <option name="height" value="744" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectInspectionProfilesVisibleTreeState">[m
[32m+[m[32m    <entry key="Project Default">[m
[32m+[m[32m      <profile-state>[m
[32m+[m[32m        <expanded-state>[m
[32m+[m[32m          <State>[m
[32m+[m[32m            <id />[m
[32m+[m[32m          </State>[m
[32m+[m[32m          <State>[m
[32m+[m[32m            <id>CSS</id>[m
[32m+[m[32m          </State>[m
[32m+[m[32m          <State>[m
[32m+[m[32m            <id>Invalid elementsCSS</id>[m
[32m+[m[32m          </State>[m
[32m+[m[32m        </expanded-state>[m
[32m+[m[32m        <selected-state>[m
[32m+[m[32m          <State>[m
[32m+[m[32m            <id>CssInvalidPropertyValue</id>[m
[32m+[m[32m          </State>[m
[32m+[m[32m        </selected-state>[m
[32m+[m[32m      </profile-state>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectLevelVcsManager" settingsEditedManually="false">[m
[32m+[m[32m    <OptionsSetting value="true" id="Add" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Remove" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Checkout" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Update" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Status" />[m
[32m+[m[32m    <OptionsSetting value="true" id="Edit" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Add" />[m
[32m+[m[32m    <ConfirmationsSetting value="0" id="Remove" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ProjectView">[m
[32m+[m[32m    <navigator currentView="ProjectPane" proportions="" version="1">[m
[32m+[m[32m      <flattenPackages />[m
[32m+[m[32m      <showMembers />[m
[32m+[m[32m      <showModules />[m
[32m+[m[32m      <showLibraryContents />[m
[32m+[m[32m      <hideEmptyPackages />[m
[32m+[m[32m      <abbreviatePackageNames />[m
[32m+[m[32m      <autoscrollToSource />[m
[32m+[m[32m      <autoscrollFromSource />[m
[32m+[m[32m      <sortByType />[m
[32m+[m[32m    </navigator>[m
[32m+[m[32m    <panes>[m
[32m+[m[32m      <pane id="ProjectPane">[m
[32m+[m[32m        <subPane>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Slider Test" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Slider Test" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Slider Test" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Slider Test" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Slider Test" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="styles" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m          <PATH>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Slider Test" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.ProjectViewProjectNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="Slider Test" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m            <PATH_ELEMENT>[m
[32m+[m[32m              <option name="myItemId" value="js" />[m
[32m+[m[32m              <option name="myItemType" value="com.intellij.ide.projectView.impl.nodes.PsiDirectoryNode" />[m
[32m+[m[32m            </PATH_ELEMENT>[m
[32m+[m[32m          </PATH>[m
[32m+[m[32m        </subPane>[m
[32m+[m[32m      </pane>[m
[32m+[m[32m      <pane id="Scope" />[m
[32m+[m[32m      <pane id="Scratches" />[m
[32m+[m[32m    </panes>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="PropertiesComponent">[m
[32m+[m[32m    <property name="WebServerToolWindowFactoryState" value="false" />[m
[32m+[m[32m    <property name="last_opened_file_path" value="$PROJECT_DIR$/.." />[m
[32m+[m[32m    <property name="FullScreen" value="false" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ShelveChangesManager" show_recycled="false" />[m
[32m+[m[32m  <component name="SvnConfiguration">[m
[32m+[m[32m    <configuration />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="TaskManager">[m
[32m+[m[32m    <task active="true" id="Default" summary="Default task">[m
[32m+[m[32m      <changelist id="cb0aa3bb-c111-4eb8-ad78-00e55d44cc25" name="Default" comment="" />[m
[32m+[m[32m      <created>1453375118180</created>[m
[32m+[m[32m      <option name="number" value="Default" />[m
[32m+[m[32m      <updated>1453375118180</updated>[m
[32m+[m[32m    </task>[m
[32m+[m[32m    <servers />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="ToolWindowManager">[m
[32m+[m[32m    <frame x="-8" y="-8" width="1382" height="744" extended-state="6" />[m
[32m+[m[32m    <editor active="false" />[m
[32m+[m[32m    <layout>[m
[32m+[m[32m      <window_info id="Project" active="true" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="true" weight="0.25340393" sideWeight="0.5" order="0" side_tool="false" content_ui="combo" />[m
[32m+[m[32m      <window_info id="TODO" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="6" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Event Log" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.32952693" sideWeight="0.5" order="7" side_tool="true" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Application Servers" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="7" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Database" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="3" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Version Control" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="7" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Structure" active="false" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="1" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Terminal" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="7" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Favorites" active="false" anchor="left" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="2" side_tool="true" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Cvs" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="4" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Message" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="0" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Commander" active="false" anchor="right" auto_hide="false" internal_type="SLIDING" type="SLIDING" visible="false" weight="0.4" sideWeight="0.5" order="0" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Inspection" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.4" sideWeight="0.5" order="5" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Run" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="2" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Hierarchy" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="2" side_tool="false" content_ui="combo" />[m
[32m+[m[32m      <window_info id="Find" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.33" sideWeight="0.5" order="1" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Ant Build" active="false" anchor="right" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.25" sideWeight="0.5" order="1" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m      <window_info id="Debug" active="false" anchor="bottom" auto_hide="false" internal_type="DOCKED" type="DOCKED" visible="false" weight="0.4" sideWeight="0.5" order="3" side_tool="false" content_ui="tabs" />[m
[32m+[m[32m    </layout>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="Vcs.Log.UiProperties">[m
[32m+[m[32m    <option name="RECENTLY_FILTERED_USER_GROUPS">[m
[32m+[m[32m      <collection />[m
[32m+[m[32m    </option>[m
[32m+[m[32m    <option name="RECENTLY_FILTERED_BRANCH_GROUPS">[m
[32m+[m[32m      <collection />[m
[32m+[m[32m    </option>[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="VcsContentAnnotationSettings">[m
[32m+[m[32m    <option name="myLimit" value="2678400000" />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="XDebuggerManager">[m
[32m+[m[32m    <breakpoint-manager />[m
[32m+[m[32m    <watches-manager />[m
[32m+[m[32m  </component>[m
[32m+[m[32m  <component name="editorHistoryManager">[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/index.html">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="21" column="14" selection-start-line="21" selection-start-column="14" selection-end-line="21" selection-end-column="14" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/styles/style.css">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="75" column="65" selection-start-line="75" selection-start-column="65" selection-end-line="75" selection-end-column="65" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/js/slider-animation.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="0" column="0" selection-start-line="0" selection-start-column="0" selection-end-line="0" selection-end-column="0" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/styles/style.css">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="84" column="16" selection-start-line="84" selection-start-column="16" selection-end-line="84" selection-end-column="16" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/index.html">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.0">[m
[32m+[m[32m          <caret line="24" column="14" selection-start-line="24" selection-start-column="14" selection-end-line="24" selection-end-column="14" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m    <entry file="file://$PROJECT_DIR$/js/slider-animation.js">[m
[32m+[m[32m      <provider selected="true" editor-type-id="text-editor">[m
[32m+[m[32m        <state vertical-scroll-proportion="0.2905983">[m
[32m+[m[32m          <caret line="17" column="25" selection-start-line="17" selection-start-column="25" selection-end-line="17" selection-end-column="25" />[m
[32m+[m[32m          <folding />[m
[32m+[m[32m        </state>[m
[32m+[m[32m      </provider>[m
[32m+[m[32m    </entry>[m
[32m+[m[32m  </component>[m
[32m+[m[32m</project>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Other/Slider Test/images/1.jpg b/JavaScript Basics/Other/Slider Test/images/1.jpg[m
[1mnew file mode 100644[m
[1mindex 0000000..d7a9b7e[m
Binary files /dev/null and b/JavaScript Basics/Other/Slider Test/images/1.jpg differ
[1mdiff --git a/JavaScript Basics/Other/Slider Test/images/2.jpg b/JavaScript Basics/Other/Slider Test/images/2.jpg[m
[1mnew file mode 100644[m
[1mindex 0000000..bbe81bb[m
Binary files /dev/null and b/JavaScript Basics/Other/Slider Test/images/2.jpg differ
[1mdiff --git a/JavaScript Basics/Other/Slider Test/images/3.jpg b/JavaScript Basics/Other/Slider Test/images/3.jpg[m
[1mnew file mode 100644[m
[1mindex 0000000..36c075e[m
Binary files /dev/null and b/JavaScript Basics/Other/Slider Test/images/3.jpg differ
[1mdiff --git a/JavaScript Basics/Other/Slider Test/images/4.jpg b/JavaScript Basics/Other/Slider Test/images/4.jpg[m
[1mnew file mode 100644[m
[1mindex 0000000..e259e6f[m
Binary files /dev/null and b/JavaScript Basics/Other/Slider Test/images/4.jpg differ
[1mdiff --git a/JavaScript Basics/Other/Slider Test/images/5.jpg b/JavaScript Basics/Other/Slider Test/images/5.jpg[m
[1mnew file mode 100644[m
[1mindex 0000000..375d422[m
Binary files /dev/null and b/JavaScript Basics/Other/Slider Test/images/5.jpg differ
[1mdiff --git a/JavaScript Basics/Other/Slider Test/images/6.jpg b/JavaScript Basics/Other/Slider Test/images/6.jpg[m
[1mnew file mode 100644[m
[1mindex 0000000..7fa6a7e[m
Binary files /dev/null and b/JavaScript Basics/Other/Slider Test/images/6.jpg differ
[1mdiff --git a/JavaScript Basics/Other/Slider Test/index.html b/JavaScript Basics/Other/Slider Test/index.html[m
[1mnew file mode 100644[m
[1mindex 0000000..e3207cf[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Other/Slider Test/index.html[m	
[36m@@ -0,0 +1,47 @@[m
[32m+[m[32m<!DOCTYPE html>[m
[32m+[m[32m<html lang="en">[m
[32m+[m[32m<head>[m
[32m+[m[32m    <meta charset="UTF-8">[m
[32m+[m[32m    <link rel="stylesheet" href="styles/style.css">[m
[32m+[m[32m    <script src="js/slider-animation.js"></script>[m
[32m+[m[32m    <title>Slider Animation</title>[m
[32m+[m[32m</head>[m
[32m+[m[32m<body>[m
[32m+[m[32m    <div id="wrapper">[m
[32m+[m[32m        <header>[m
[32m+[m[32m            <nav>[m
[32m+[m[32m                <ul>[m
[32m+[m[32m                    <li><a href="#">Home</a></li>[m
[32m+[m[32m                    <li><a href="#">Gallery</a></li>[m
[32m+[m[32m                    <li><a href="#">Shop</a></li>[m
[32m+[m[32m                    <li><a href="#">Contacts</a></li>[m
[32m+[m[32m                    <li><a href="#">About</a></li>[m
[32m+[m[32m                </ul>[m
[32m+[m[32m            </nav>[m
[32m+[m[32m        </header>[m
[32m+[m[32m        <main>[m
[32m+[m[32m            <div id="slider">[m
[32m+[m[32m                <div class="image-container"><img src="images/2.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/3.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/1.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/3.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/1.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/4.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/2.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/3.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/1.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/5.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/4.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/5.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/4.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/2.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m                <div class="image-container"><img src="images/4.jpg" alt="Planet" onclick="showImage(this)"></div>[m
[32m+[m[32m            </div>[m
[32m+[m[32m            <div id="largeImgPanel" onclick="this.style.display='none'">[m
[32m+[m[32m            <img id="largeImg"[m
[32m+[m[32m                 style="height:100%; margin:0; padding:0;" />[m
[32m+[m[32m        </div>[m
[32m+[m[32m        </main>[m
[32m+[m[32m    </div>[m
[32m+[m[32m</body>[m
[32m+[m[32m</html>[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Other/Slider Test/js/slider-animation.js b/JavaScript Basics/Other/Slider Test/js/slider-animation.js[m
[1mnew file mode 100644[m
[1mindex 0000000..78ccb1a[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Other/Slider Test/js/slider-animation.js[m	
[36m@@ -0,0 +1,39 @@[m
[32m+[m[32mfunction changeId() {[m
[32m+[m[32m    var images = document.getElementsByTagName("img");[m
[32m+[m[32m    var imagesList = Array.prototype.slice.call(images);[m
[32m+[m[41m    [m
[32m+[m	[32mfor(var ind in imagesList) {[m
[32m+[m		[32mimagesList[ind].onclick = function (img) {[m
[32m+[m			[32mdocument.getElementById('largeImg').src = img.src;[m
[32m+[m			[32mshowLargeImagePanel();[m
[32m+[m			[32munselectAll();[m
[32m+[m			[32msetTimeout(function() {[m
[32m+[m				[32mdocument.getElementById('largeImg').src = img.src;[m
[32m+[m			[32m}, 1)[m
[32m+[m		[32m};[m
[32m+[m	[32m}[m
[32m+[m[41m	[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mfunction showImage(img) {[m
[32m+[m	[32mdocument.getElementById('largeImg').src = img.src;[m
[32m+[m	[32mshowLargeImagePanel();[m
[32m+[m	[32munselectAll();[m
[32m+[m	[32msetTimeout(function() {[m
[32m+[m		[32mdocument.getElementById('largeImg').src = img.src;[m
[32m+[m	[32m}, 1)[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mfunction showLargeImagePanel() {[m
[32m+[m	[32mdocument.getElementById('largeImgPanel').style.display = 'block';[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mfunction unselectAll() {[m
[32m+[m	[32mif(document.selection)[m
[32m+[m		[32mdocument.selection.empty();[m
[32m+[m	[32mif(window.getSelection)[m
[32m+[m		[32mwindow.getSelection().removeAllRanges();[m
[32m+[m[32m}[m
[32m+[m
[32m+[m
[32m+[m
[1mdiff --git a/JavaScript Basics/Other/Slider Test/styles/style.css b/JavaScript Basics/Other/Slider Test/styles/style.css[m
[1mnew file mode 100644[m
[1mindex 0000000..6fdc91d[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Other/Slider Test/styles/style.css[m	
[36m@@ -0,0 +1,92 @@[m
[32m+[m[32m* {[m
[32m+[m[32m    padding: 0;[m
[32m+[m[32m    margin: 0;[m
[32m+[m[32m    border: 0;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody {[m
[32m+[m[32m    font-family: Arial;[m
[32m+[m[32m    background-color: burlywood;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper {[m
[32m+[m[32m    width: 1200px;[m
[32m+[m[32m    margin: 0 auto;[m
[32m+[m[32m    background-color: aliceblue;[m
[32m+[m[32m    box-shadow: 0 0 3px 0 #000;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper header {[m
[32m+[m[32m    width: 100%;[m
[32m+[m[32m    height: 50px;[m
[32m+[m[32m    background-color: beige;[m
[32m+[m[32m    border-bottom: 3px solid #aea;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper header nav ul {[m
[32m+[m[32m    list-style-type: none;[m
[32m+[m[32m    width: 100%;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper header nav ul li {[m
[32m+[m[32m    display: inline-block;[m
[32m+[m[32m    width: 19%;[m
[32m+[m[32m    text-align: center;[m
[32m+[m[32m    font-size: 20pt;[m
[32m+[m[32m    font-family: Calibri;[m
[32m+[m[32m    text-transform: uppercase;[m
[32m+[m[32m    line-height: 50px;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper header nav ul li a {[m
[32m+[m[32m    text-decoration: none;[m
[32m+[m[32m    color: coral;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper header nav ul li a:hover {[m
[32m+[m[32m    color: chocolate;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper main {[m
[32m+[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper main div#slider {[m
[32m+[m[32m    width: 100%;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper main div#slider div.image-container {[m
[32m+[m[32m    overflow: visible;[m
[32m+[m[32m    float: left;[m
[32m+[m[32m    width: 240px;[m
[32m+[m[32m    height: 150px;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper main div#slider div.image-container img {[m
[32m+[m[32m    width: 240px;[m
[32m+[m[32m    height: 150px;[m
[32m+[m[32m    -webkit-transition: all 0.1s;[m
[32m+[m[32m    -moz-transition: all 0.1s;[m
[32m+[m[32m    -ms-transition: all 0.1s;[m
[32m+[m[32m    -o-transition: all 0.1s;[m
[32m+[m[32m    transition: all 0.1s;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32mbody div#wrapper main div#slider div.image-container img:hover,[m
[32m+[m[32mbody div#wrapper main div#slider div.image-container img#hovered {[m
[32m+[m[32m    position: absolute;[m
[32m+[m[32m    margin: -10px 0 0 -10px;[m
[32m+[m[32m    z-index: 1;[m
[32m+[m[32m    width: 260px;[m
[32m+[m[32m    height: 170px;[m
[32m+[m[32m    box-shadow: 2px 2px 10px 0px #000;[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32m#largeImgPanel {[m
[32m+[m[32m    text-align: center;[m
[32m+[m[32m    display: block;[m
[32m+[m[32m    position: fixed;[m
[32m+[m[32m    z-index: 100;[m
[32m+[m[32m    top: 0; left: 0; width: 100%; height: 100%;[m
[32m+[m[32m    background-color: rgba(0, 0, 0, 0.8);[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/JavaScript Basics/Other/Slider Test/thumbnails.html b/JavaScript Basics/Other/Slider Test/thumbnails.html[m
[1mnew file mode 100644[m
[1mindex 0000000..291d4f3[m
[1m--- /dev/null[m
[1m+++ b/JavaScript Basics/Other/Slider Test/thumbnails.html[m	
[36m@@ -0,0 +1,53 @@[m
[32m+[m[32m<!DOCTYPE html>[m
[32m+[m[32m<html>[m
[32m+[m[32m    <head>[m
[32m+[m[32m        <title>Sample</title>[m
[32m+[m
[32m+[m[32m        <script type="text/javascript">[m
[32m+[m[32m            function showImage(smSrc, lgSrc) {[m
[32m+[m[32m                document.getElementById('largeImg').src = smSrc;[m
[32m+[m[32m                showLargeImagePanel();[m
[32m+[m[32m                unselectAll();[m
[32m+[m[32m                setTimeout(function() {[m
[32m+[m[32m                    document.getElementById('largeImg').src = lgSrc;[m
[32m+[m[32m                }, 1)[m
[32m+[m[32m            }[m
[32m+[m[32m            function showLargeImagePanel() {[m
[32m+[m[32m                document.getElementById('largeImgPanel').style.display = 'block';[m
[32m+[m[32m            }[m
[32m+[m[32m            function unselectAll() {[m
[32m+[m[32m                if(document.selection)[m
[32m+[m[32m                    document.selection.empty();[m
[32m+[m[32m                if(window.getSelection)[m
[32m+[m[32m                    window.getSelection().removeAllRanges();[m
[32m+[m[32m            }[m
[32m+[m[32m        </script>[m
[32m+[m
[32m+[m[32m        <style type="text/css">[m
[32m+[m[32m            #largeImgPanel {[m
[32m+[m[32m                text-align: center;[m
[32m+[m[32m                display: block;[m
[32m+[m[32m                position: fixed;[m
[32m+[m[32m                z-index: 100;[m
[32m+[m[32m                top: 0; left: 0; width: 100%; height: 100%;[m
[32m+[m[32m                background-color: rgba(0, 0, 0, 0.8);[m
[32m+[m[32m            }[m
[32m+[m[32m        </style>[m
[32m+[m[32m    </head>[m
[32m+[m
[32m+[m[32m    <body>[m
[32m+[m[32m        <p>Click on any image thumbnail to enlarge. Click again to hide:</p>[m
[32m+[m
[32m+[m[32m        <img src="images/1.jpg" style="cursor:pointer; width: 200px;"[m
[32m+[m[32m             onclick="showImage(this.src, 'images/1.jpg');" />[m
[32m+[m[32m        <img src="images/2.jpg" style="cursor:pointer; width: 200px;"[m
[32m+[m[32m             onclick="showImage(this.src, 'images/2.jpg');" />[m
[32m+[m[32m        <img src="images/3.jpg" style="cursor:pointer; width: 200px;"[m
[32m+[m[32m             onclick="showImage(this.src, 'images/3.jpg');" />[m
[32m+[m
[32m+[m[32m        <div id="largeImgPanel" onclick="this.style.display='none'">[m
[32m+[m[32m            <img id="largeImg"[m
[32m+[m[32m                 style="height:100%; margin:0; padding:0;" />[m
[32m+[m[32m        </div>[m
[32m+[m[32m    </body>[m
[32m+[m[32m</html>[m
\ No newline at end of file[m
