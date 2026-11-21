using System;
using MySqlConnector;
using System.Windows.Forms;

namespace DiabetesMonitoringSystem.Views
{
    internal static class FormMessages
    {
        public static bool Try(Form form, Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (MySqlException error)
            {
                string message = "Database error (" + error.Number + "). Check XAMPP and App.config. " + error.Message;
                MessageBox.Show(form, message,
                    "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception error) when (error is ArgumentException || error is InvalidOperationException ||
                error is UnauthorizedAccessException)
            {
                MessageBox.Show(form, error.Message, "Diabetes Monitoring", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
        }

        public static void HideId(DataGridView grid, string name)
        {
            if (grid.Columns.Contains(name)) grid.Columns[name].Visible = false;
        }

        public static int SelectedId(DataGridView grid, string column)
        {
            if (grid.SelectedRows.Count == 0) throw new ArgumentException("Select a row first.");
            return (int)grid.SelectedRows[0].Cells[column].Value;
        }
    }
}
