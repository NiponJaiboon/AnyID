using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnyIDAdmin.ExcelUtil
{
    public class ExcelCreator
    {
        private WorkbookPart _wbPart;
        public ExcelCreator(WorkbookPart wbPart)
        {
            _wbPart = wbPart;
        }

        // Given a Worksheet and an address (like "AZ254"), either return a 
        // cell reference, or create the cell reference and return it.
        private Cell InsertCellInWorksheet(Worksheet ws, string addressName)
        {
            SheetData sheetData = ws.GetFirstChild<SheetData>();
            Cell cell = null;

            UInt32 rowNumber = GetRowIndex(addressName);
            Row row = GetRow(sheetData, rowNumber);

            // If the cell you need already exists, return it.
            // If there is not a cell with the specified column name, insert one.  
            Cell refCell = row.Elements<Cell>().
                Where(c => c.CellReference.Value == addressName).FirstOrDefault();
            if (refCell != null)
            {
                cell = refCell;
            }
            else
            {
                cell = CreateCell(row, addressName);
            }
            return cell;
        }

        // Add a cell with the specified address to a row.
        private Cell CreateCell(Row row, String address)
        {
            Cell cellResult;
            Cell refCell = null;

            // Cells must be in sequential order according to CellReference. 
            // Determine where to insert the new cell.
            foreach (Cell cell in row.Elements<Cell>())
            {
                if (string.Compare(cell.CellReference.Value, address, true) > 0)
                {
                    refCell = cell;
                    break;
                }
            }

            cellResult = new Cell();
            cellResult.CellReference = address;

            row.InsertBefore(cellResult, refCell);
            return cellResult;
        }

        // Return the row at the specified rowIndex located within
        // the sheet data passed in via wsData. If the row does not
        // exist, create it.
        private Row GetRow(SheetData wsData, UInt32 rowIndex)
        {
            var row = wsData.Elements<Row>().
            Where(r => r.RowIndex.Value == rowIndex).FirstOrDefault();
            if (row == null)
            {
                row = new Row();
                row.RowIndex = rowIndex;
                wsData.Append(row);
            }
            return row;
        }

        // Given an Excel address such as E5 or AB128, GetRowIndex
        // parses the address and returns the row index.
        private UInt32 GetRowIndex(string address)
        {
            string rowPart;
            UInt32 l;
            UInt32 result = 0;

            for (int i = 0; i < address.Length; i++)
            {
                if (UInt32.TryParse(address.Substring(i, 1), out l))
                {
                    rowPart = address.Substring(i, address.Length - i);
                    if (UInt32.TryParse(rowPart, out l))
                    {
                        result = l;
                        break;
                    }
                }
            }
            return result;
        }

        public bool UpdateValue(string sheetName, string addressName, string value,
                              UInt32Value styleIndex, bool isString)
        {
            // Assume failure.
            bool updated = false;

            Sheet sheet = _wbPart.Workbook.Descendants<Sheet>().Where(
                (s) => s.Name == sheetName).FirstOrDefault();

            if (sheet != null)
            {
                Worksheet ws = ((WorksheetPart)(_wbPart.GetPartById(sheet.Id))).Worksheet;
                Cell cell = InsertCellInWorksheet(ws, addressName);

                if (isString)
                {
                    // Either retrieve the index of an existing string,
                    // or insert the string into the shared string table
                    // and get the index of the new item.
                    int stringIndex = InsertSharedStringItem(_wbPart, value);

                    cell.CellValue = new CellValue(stringIndex.ToString());
                    cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                }
                else
                {
                    cell.CellValue = new CellValue(value);
                    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                }

                if (styleIndex > 0)
                    cell.StyleIndex = styleIndex;

                // Save the worksheet.
                ws.Save();
                updated = true;
            }

            return updated;
        }

        // Given the main workbook part, and a text value, insert the text into 
        // the shared string table. Create the table if necessary. If the value 
        // already exists, return its index. If it doesn't exist, insert it and 
        // return its new index.
        private int InsertSharedStringItem(WorkbookPart wbPart, string value)
        {
            int index = 0;
            bool found = false;
            var stringTablePart = wbPart
                .GetPartsOfType<SharedStringTablePart>().FirstOrDefault();

            // If the shared string table is missing, something's wrong.
            // Just return the index that you found in the cell.
            // Otherwise, look up the correct text in the table.
            if (stringTablePart == null)
            {
                // Create it.
                stringTablePart = wbPart.AddNewPart<SharedStringTablePart>();
            }

            var stringTable = stringTablePart.SharedStringTable;
            if (stringTable == null)
            {
                stringTablePart.SharedStringTable = new SharedStringTable();
                stringTable = stringTablePart.SharedStringTable;
            }

            // Iterate through all the items in the SharedStringTable. 
            // If the text already exists, return its index.
            foreach (SharedStringItem item in stringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == value)
                {
                    found = true;
                    break;
                }
                index += 1;
            }

            if (!found)
            {
                stringTable.AppendChild(new SharedStringItem(new Text(value)));
                stringTable.Save();
            }

            return index;
        }

        private bool RemoveCellValue(string sheetName, string addressName)
        {
            bool returnValue = false;

            Sheet sheet = _wbPart.Workbook.Descendants<Sheet>().
                Where(s => s.Name == sheetName).FirstOrDefault();
            if (sheet != null)
            {
                Worksheet ws = ((WorksheetPart)(_wbPart.GetPartById(sheet.Id))).Worksheet;
                Cell cell = InsertCellInWorksheet(ws, addressName);

                // If there is a cell value, remove it to force a recalculation
                // on this cell.
                if (cell.CellValue != null)
                {
                    cell.CellValue.Remove();
                }

                // Save the worksheet.
                ws.Save();
                returnValue = true;
            }

            return returnValue;
        }
    }
}