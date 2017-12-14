using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebAPITest1.Models;

namespace WebAPITest1.CsvHelper
{
    public class CsvService
    {
        public IEnumerable<Partner> ReadPartners(string filePath)
        {
            using (var stream = File.OpenText(filePath))
            {

                var csv = new CsvReader(stream);
                return csv.GetRecords<Partner>().ToList();

            }
        }

        public void WritePartners(IEnumerable<Partner> partners, string filePath)
        {
            using (var stream = File.CreateText(filePath))
            {
                var csv = new CsvWriter(stream);
                csv.WriteRecords(partners);
            }
        }

    }
}