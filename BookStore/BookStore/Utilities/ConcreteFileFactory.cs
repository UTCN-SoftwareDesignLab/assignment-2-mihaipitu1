using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Utilities
{
    public class ConcreteFileFactory
    {
        public FileStreamResult GetFile(List<Book> books, string fileType)
        {
            switch(fileType)
            {
                case "csv": return new FileStreamResult(new CsvFileGenerator().GenerateFileStream(books),"text/csv");

                case "pdf": return new FileStreamResult(new PdfFileGenerator().GenerateFileStream(books),"application/pdf");
                default: return null;
            }
        }
    }
}
