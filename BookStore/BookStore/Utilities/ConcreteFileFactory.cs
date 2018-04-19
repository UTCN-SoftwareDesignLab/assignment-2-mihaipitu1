using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                case "csv": return new CsvFileGenerator().GenerateFileStream(books);
                case "pdf": return new PdfFileGenerator().GenerateFileStream(books);
                default: return null;
            }
        }
    }
}
