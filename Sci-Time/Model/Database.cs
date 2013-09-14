﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLite;
using Windows.Storage;
using System.IO;

namespace Sci_Time.Model
{
    class Database
    {
        public static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "Assets/Database/sci_time.db"));
        private SQLiteConnection dbconn;

        public Database() {
            if (dbconn != null) {
                dbconn = new SQLiteConnection(DB_PATH);
            }
        }

        public IEnumerable<YearRanges> QueryYearRanges()
        {
            return dbconn.Query<YearRanges>("select _id, Name from list");
        }

        public IEnumerable<Discoveries> QueryYearRanges(string yearRange)
        {
            return dbconn.Query<Discoveries>("select _id, Title from " + "[" + yearRange +"]");
        }

        public IEnumerable<Article> QueryYearRanges(string yearRange, string title)
        {
            return dbconn.Query<Article>("select _id, Title, Image, Discovery, Year, Discoverer, Tags from " + "[" + yearRange + "]");
        }

    }

    public sealed class YearRanges
    {

        [PrimaryKey, AutoIncrement]
        public int _id { get; set; }
        public string Name { get; set; }

    }

    public sealed class Discoveries {
        [PrimaryKey, AutoIncrement]
        public int _id { get; set; }
        public string Title { get; set; }
    }

    public sealed class Article
    {
        [PrimaryKey, AutoIncrement]
        public int _id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public string Discovery { get; set; }
        public string Year { get; set; }
        public string Discoverer { get; set; }
        public string Tags { get; set; }

    }
}