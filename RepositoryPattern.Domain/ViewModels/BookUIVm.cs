using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain.ViewModels
{
    public class BookUIVm
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }
        public BookDetailUiVM details { get; set; }
    }

    public class BookDetailUiVM
    {
        public double Weight { get; set; }
        public int Chapters { get; set; }
        public int Pages { get; set; }
    }
}
