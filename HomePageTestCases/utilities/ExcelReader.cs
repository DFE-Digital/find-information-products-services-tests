using ClosedXML.Excel;

namespace find_information_products_services_tests.HomePageTestCases.utilities
{
    internal class ExcelReader
    {
        public static List<FipsSheetRow> getRowsFromExcelFileBySheetName(string fileName, string sheetName)
        {
            string testDirectory = TestContext.CurrentContext.TestDirectory;

            string excelFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName 
                +"//" +fileName;

            if (!File.Exists(excelFilePath))
            {
                Assert.Fail($"Excel file {fileName} not found at: {excelFilePath}");
            }

            // List to hold the data from the Excel file
            var userDataList = new List<FipsSheetRow>();

            using (var workbook = new XLWorkbook(excelFilePath))
            {
                var worksheet = workbook.Worksheet(sheetName);
                if (worksheet == null)
                {
                    Assert.Fail($"Sheet {sheetName} not found in the Excel file.");
                }

                var firstRowUsed = worksheet?.FirstRowUsed();
                if (firstRowUsed == null)
                {
                    Assert.Pass("No data found in the Excel sheet.");
                }

                var dataRows = worksheet.RowsUsed().Skip(1);

                foreach (var row in dataRows)
                {
                    var userData = new FipsSheetRow
                    {
                        //Product_Locator Filter_Tag  Message Heading Filter_Text_Locator Checkbox_Locator
                        Product_Locator = row.Cell(1).Value.ToString(),
                        Filter_Tag = row.Cell(2).Value.ToString(),
                        Message = row.Cell(3).Value.ToString(),
                        Heading = row.Cell(4).Value.ToString(),
                        Filter_Text_Locator = row.Cell(5).Value.ToString(),
                        Checkbox_Locator = row.Cell(6).Value.ToString()
                    };
                    userDataList.Add(userData);
                }
            }
            return userDataList;
        }
    }
}
