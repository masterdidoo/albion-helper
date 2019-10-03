using System;

namespace Albion.Model.Data
{
    public class BuildingData
    {
        public event Action UpdateTax;
        public int Tax { get; set; }
    }
}