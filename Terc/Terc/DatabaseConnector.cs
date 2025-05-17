namespace Terc
{
    using MySqlConnector;
    using Gtk;
    using System.Data;

    public class DatabaseConnector
    {
        private readonly string _connectionString;

        public DatabaseConnector(string port, string address, string username, string password, string database)
        {
            _connectionString = $"Server={address};Port={port};Database={database};Uid={username};Pwd={password};";
            
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();
                Console.WriteLine("Database connection established in DatabaseConnector.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error establishing database connection: {ex.Message}");
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            var dataTable = new DataTable();
            
            using var connection = new MySqlConnection(_connectionString);
            try
            {
                connection.Open();
                using var command = new MySqlCommand(query, connection);
                using var adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error executing query '{query}': {ex.Message}");
            }

            return dataTable;
        }
    }

    public class ShowScoresWindow : Window
    {
        private readonly DatabaseConnector _databaseConnector;
        private readonly ScrolledWindow _scrolledWindow;
        private readonly TreeView _treeView;
        private readonly ListStore _listStore;

        public ShowScoresWindow(DatabaseConnector databaseConnector) : base("Skore")
        {
            _databaseConnector = databaseConnector;
            
            SetDefaultSize(400, 300);
            BorderWidth = 10;
            
            var vbox = new VBox();
            _scrolledWindow = new ScrolledWindow();
            _treeView = new TreeView();
            _scrolledWindow.Add(_treeView);
            vbox.PackStart(_scrolledWindow, true, true, 0);
            Add(vbox);

            _listStore = new ListStore(typeof(string), typeof(int), typeof(int), typeof(int));
            _treeView.Model = _listStore;
            
            LoadScores();
            SetupColumns();
        }

        private void SetupColumns()
        {
            _treeView.AppendColumn("Meno", new CellRendererText(), "text", 0);
            _treeView.AppendColumn("Najlepsie skore", new CellRendererText(), "text", 1);
            _treeView.AppendColumn("Celkove skore", new CellRendererText(), "text", 2);
            _treeView.AppendColumn("Pokusy", new CellRendererText(), "text", 3);
        }

        private void LoadScores()
        {
            _listStore.Clear();
            const string query = "SELECT Meno, NajSkore, CelkoveSkore, Pokusy FROM Players ORDER BY NajSkore DESC;";
            var scores = _databaseConnector.ExecuteQuery(query);

            foreach (DataRow row in scores.Rows)
            {
                try
                {
                    string name = row["Meno"].ToString();
                    int bestScore = Convert.ToInt32(row["NajSkore"]);
                    int totalScore = Convert.ToInt32(row["CelkoveSkore"]);
                    int attempts = Convert.ToInt32(row["Pokusy"]);
                    
                    _listStore.AppendValues(name, bestScore, totalScore, attempts);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing row: {ex.Message}");
                }
            }
        }
    }
}
