using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Utilities
{
    public interface IFileFactory
    {
        FileStream GenerateFileStream(List<Book> books);
    }
}
