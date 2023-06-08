namespace Backend_OddityVR.Domain.Service
{
    public static class ImportCSV
    {
        public static List<string[]> ImportData(string fileName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + fileName;
            string data = File.ReadAllText(path);

            string[] lines = data.Split("\r\n").Skip(1).ToArray();

            List<string[]> listToReturn = new ();

            foreach (string line in lines)
            {
                if (line.Length < lines[0].Length) continue;
                string[] cells = line.Split(',');
                listToReturn.Add(cells);
            }

            return listToReturn;
        }
    }
}
