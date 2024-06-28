using Microsoft.Data.Analysis;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Components.DataProcessors
{
    public interface IDataProcessor
    {
        // Must implement a method to process
        public DataFrame ProcessData(DataFrame data);

    }
}
