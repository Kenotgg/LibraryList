using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryList
{
    /// <summary>
    /// Логика взаимодействия для AddEditBook.xaml
    /// </summary>
    public partial class AddEditBook : Window
    {
        public Book Book { get; private set; }

        public AddEditBook(Book book = null)
        {
            InitializeComponent();
            if (book != null)
            {
                Book = book;
                TitleTextBox.Text = book.Title;
                AuthorTextBox.Text = book.Author;
                YearTextBox.Text = book.YearOfBookRelease.ToString();
                GenreTextBox.Text = book.Genre;
                PagesTextBox.Text = book.NumberOfPages.ToString();
            }
            else
            {
                Book = new Book();
            }
        }

        private void SaveBook(object sender, RoutedEventArgs e)
        {
            Book.Title = TitleTextBox.Text;
            Book.Author = AuthorTextBox.Text;
            Book.YearOfBookRelease = Int32.Parse(YearTextBox.Text);
            Book.Genre = GenreTextBox.Text;
            Book.NumberOfPages = Int32.Parse(PagesTextBox.Text);
            DialogResult = true;
            this.Close();
        }

        private void CancelEditing(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

       
    }
}
