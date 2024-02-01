using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33 {
    internal class Library {
        public List<string> books = new();
        public uint BookLimit;

        public Library(uint bookLimit) {
            BookLimit = bookLimit;
        }

        public void AddBook(string? book) {
            if (string.IsNullOrWhiteSpace(book)) {
                throw new Exception("Book name cannot be empty");
            }
            if (books.Contains(book)) {
                throw new Exception("Book already exists in library");
            }
            if (books.Count < BookLimit) {
                books.Add(book);
            } else {
                throw new Exception("Book limit reached");
            }
        }

        public bool RemoveBook(string? book) {
            if (string.IsNullOrWhiteSpace(book)) {
                throw new Exception("Book name cannot be empty");
            }
            if (!books.Contains(book)) {
                return false;
            }
            books.Remove(book);
            return true;
        }
    }
}
