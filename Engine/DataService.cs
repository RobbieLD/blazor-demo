using System.Data;

namespace Engine
{
    public class DataService
    {
        private readonly DataTable _data = new();
        public event EventHandler? DataChanged;

        public DataService()
        {
            _data.Columns.Add("IsError");
            _data.Columns.Add("Value");

            RefreshData(10);
        }

        public DataTable GetData()
        {
            return _data;
        }

        public void RefreshData(int rows)
        {
            _data.Rows.Clear();
            var random = new Random();

            for (int i = 0; i < rows; i++)
            {
                _data.Rows.Add(random.Next(1, 255), random.NextDouble() >= 0.8);
            }

            DataChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}