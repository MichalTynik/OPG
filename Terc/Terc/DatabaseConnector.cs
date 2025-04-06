namespace Terc
{
    using MySqlConnector;
    using Gtk;
    using System.Data;

    public class DatabaseConnector
    {
        private string connectionString;

        public DatabaseConnector(string port, string address, string username, string password, string database)
        {
            connectionString = $"Server={address};Port={port};Database={database};Uid={username};Pwd={password};";
            Console.WriteLine($"Connection String: {connectionString}"); 
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Database connection established in DatabaseConnector.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error establishing database connection: {ex.Message}");
            }
        }

        /// <summary>
        /// Spusti SQL prikaz
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query '{query}': {ex.Message}");
                }
            }
            return dataTable;
        }
    }

    /// <summary>
    /// Okno na zobrazenie dat z databazy
    /// </summary>
    public class ShowScoresWindow : Window
    {
        private DatabaseConnector _databaseConnector;
        private ScrolledWindow _scrolledWindow;
        private TreeView _treeView;
        private ListStore _listStore;

        public ShowScoresWindow(DatabaseConnector databaseConnector) : base("High Scores")
        {
            _databaseConnector = databaseConnector;
            
            SetDefaultSize(400, 300);
            BorderWidth = 10;
            
            VBox vbox = new VBox();
            _scrolledWindow = new ScrolledWindow();
            _treeView = new TreeView();
            _scrolledWindow.Add(_treeView);
            vbox.PackStart(_scrolledWindow, true, true, 0);
            Add(vbox);

            _listStore = new ListStore(typeof(string), typeof(int), typeof(int), typeof(int));
            _treeView.Model = _listStore;
            LoadScores();
            _treeView.AppendColumn("Name", new CellRendererText(), "text", 0);
            _treeView.AppendColumn("Best Score", new CellRendererText(), "text", 1);
            _treeView.AppendColumn("Total Score", new CellRendererText(), "text", 2);
            _treeView.AppendColumn("Attempts", new CellRendererText(), "text", 3);

            
        }

        /// <summary>
        /// Nacita udaje z databazy
        /// </summary>
        private void LoadScores()
        {
            _listStore.Clear();
            string query = "SELECT Meno, NajSkore, CelkoveSkore, Pokusy FROM Players ORDER BY NajSkore DESC;";
            DataTable scores = _databaseConnector.ExecuteQuery(query);
            Console.WriteLine($"Number of rows retrieved: {scores.Rows.Count}");
            foreach (System.Data.DataRow row in scores.Rows)
            {
                Console.WriteLine($"Raw Name: '{row["Meno"]}', Raw Best Score: '{row["NajSkore"]}', Raw Total Score: '{row["CelkoveSkore"]}', Raw Attempts: '{row["Pokusy"]}'");
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