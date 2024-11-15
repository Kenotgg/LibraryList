using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryList
{
    public class MainWindowViewModel
    {
        private Book _selectedBook;
        public ObservableCollection<Book> Books { get; set; }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                  (_addCommand = new RelayCommand(obj =>
                  {
                      Book book = new Book();
                      Books.Insert(0, book);
                      SelectedBook = book;
                  }));
            }
        }
        public Book SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }

        public MainWindowViewModel()
        {
            Books = new ObservableCollection<Book>
            {
                new Book { Title="1984",Author ="Джордж Оруэлл",  Description="Дистопийский роман о тоталитарном обществе.",YearOfBookRelease=1949,Genre="Фантастика", NumberOfPages=328},
                new Book { Title="Мастер и Маргарита",Author ="Михаил Булгаков",  Description="Роман, сочетающий элементы фантастики и реализма.",YearOfBookRelease=1967,Genre="Роман", NumberOfPages=404},
                new Book { Title="Убить пересмешника",Author ="Харпер Ли",  Description="История о расовых предрассудках в США",YearOfBookRelease=1960  ,Genre="Художественная литература", NumberOfPages=281},
                new Book { Title="Великий Гэтсби",Author ="Ф. Скотт Фицджеральд",  Description="Роман о богатстве и мечтах в 1920-е годы.",YearOfBookRelease=1925  ,Genre=" Классическая проза", NumberOfPages=180},
                new Book { Title="Преступление и наказание ",Author ="Фёдор Достоевский",  Description=" Психологический роман о моральных дилеммах.",YearOfBookRelease=1866,Genre="Классическая литература", NumberOfPages=430},

            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public void AddBook()
        {
            var addBookWindow = new AddEditBook();
            if (addBookWindow.ShowDialog() == true)
            {
                var newBook = addBookWindow.Book;
                if (newBook != null)
                    Books.Add(newBook);
            }
        }

        public void EditBook()
        {
            var addBookWindow = new AddEditBook(SelectedBook);
            if (addBookWindow.ShowDialog() == true)
            {
                var updatedBook = addBookWindow.Book;
                SelectedBook = updatedBook;
            }
        }

        public void DeleteBook()
        {
            Books.Remove(SelectedBook);
        }


    }
}
