using Sql.SQL;
using System.Windows;
using System.Windows.Controls;
using static Sql.Models.Emberek;

namespace Dolgozat.Nezetek
{
    /// <summary>
    /// Interaction logic for SqlView.xaml
    /// </summary>
    public partial class SqlView : UserControl
    {
        private readonly AdatbazisContext _context;
        private User _selectedUser;
        public SqlView()
        {
            InitializeComponent();
            _context = new AdatbazisContext();
            LoadData();
        }



        private void LoadData()
        {
            var users = _context.User.ToList();
            listBox.ItemsSource = users;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                _selectedUser = (User)listBox.SelectedItem;
                nameTextBox.Text = _selectedUser.Name;
                postTextBox.Text = _selectedUser.PostCode;
                buildingTextBox.Text = _selectedUser.Building;
                positionTextBox.Text = _selectedUser.Position;
                transportationTextBox.Text = _selectedUser.Transport;
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUser != null)
            {
                _selectedUser.Name = nameTextBox.Text;
                _selectedUser.PostCode = postTextBox.Text;
                _selectedUser.Building = buildingTextBox.Text;
                _selectedUser.Position = positionTextBox.Text;
                _selectedUser.Transport = transportationTextBox.Text;

                _context.User.Update(_selectedUser);
                await _context.SaveChangesAsync();
                LoadData();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUser != null)
            {
                _context.User.Remove(_selectedUser);
                await _context.SaveChangesAsync();
                LoadData();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            nameTextBox.Text = "";
            postTextBox.Text = "";
            buildingTextBox.Text = "";
            positionTextBox.Text = "";
            transportationTextBox.Text = "";
        }
    }
}
