using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Utilities
{
    public class CsvFileGenerator : IFileFactory
    {
        public FileStreamResult GenerateFileStream(List<Book> books)
        {
            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ",";
                csvWriter.WriteField("Title");
                csvWriter.WriteField("Author");
                csvWriter.WriteField("Genre");
                csvWriter.WriteField("Price");
                csvWriter.NextRecord();

                foreach(var book in books)
                {
                    csvWriter.WriteField(book.GetTitle());
                    csvWriter.WriteField(book.GetAuthor());
                    csvWriter.WriteField(book.GetGenre());
                    csvWriter.WriteField(book.GetPrice());
                    csvWriter.NextRecord();
                }

                return new FileStreamResult(mem, "text/csv") { FileDownloadName = "report.csv"; };
            }
        }
    }
}
