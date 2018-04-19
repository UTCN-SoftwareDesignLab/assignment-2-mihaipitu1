using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Utilities
{
    public class PdfFileGenerator : IFileFactory
    {
        public FileStreamResult GenerateFileStream(List<Book> books)
        {
            MemoryStream mem = new MemoryStream();
            Document doc = new Document();
            PdfWriter.GetInstance(doc, mem).CloseStream = false;

            doc.Open();
            doc.Add(new Paragraph("Report - Out of stock books"));
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph("The books which are out of stock are: "));
            foreach (var book in books)
            {
                doc.Add(new Paragraph(String.Format("{0}. {1} - {2} - Genre: {3} - Price {4}",book.GetId(),book.GetTitle(),book.GetAuthor(),book.GetGenre(),book.GetPrice())));
            }
            doc.Close();
            return new FileStreamResult(mem, "application/pdf") { FileDownloadName = "report.pdf"};
        }
    }
}
