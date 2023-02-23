using System;
using System.Collections.Generic;
using System.Text;
using ims.Model.ViewModel.Base;

namespace ims.Model.ViewModel.UnitOfMeasure
{
    public class ListUnitOfMeasureViewModel : BaseViewModel
    {
        public string UnitOfMeasureName { get; set; }
        public string Isocode { get; set; }
    }
}
