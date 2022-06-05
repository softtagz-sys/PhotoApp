using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoApp.Interfaces
{
    internal interface IDBConnectorInterface
    {
        public string getMySQLColumns();
        public string getMySQLValues();
    }
}
