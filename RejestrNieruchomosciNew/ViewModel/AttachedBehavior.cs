using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using wf = System.Windows.Forms;

using Bentley.MicroStation.InteropServices;
using Bentley.Interop.MicroStationDGN;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class LocateClass : ILocateCommandEvents
    {
        Application app = Utilities.ComApp;

        public void Accept(Element elem, ref Point3d Point, View View)
        {
            app.ShowError("Accept()");
        }

        public void Cleanup()
        {
            app.ShowError("Cleanup()");
        }

        public void Dynamics(ref Point3d point, View view, MsdDrawingMode drawMode)
        {
            app.ShowError("Dynamics()");
        }

        public void LocateFailed()
        {
            app.ShowError("LocateFailed()");
        }

        public void LocateFilter(Element element, ref Point3d point, ref bool acc)
        {

        }

        public void LocateReset()
        {
            app.ShowError("LocateReset()");
        }

        public void Start()
        {
            LocateCriteria loc = app.CommandState.CreateLocateCriteria(false);
            loc.IncludeType(MsdElementType.ReferenceAttachment);
            app.CommandState.SetLocateCriteria(loc);

        }
    }
}
