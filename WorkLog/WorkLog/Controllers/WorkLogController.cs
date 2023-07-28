using Microsoft.AspNetCore.Mvc;
using WorkLog.Models.ViewModel;

namespace WorkLog.Controllers
{
    public class WorkLogController : Controller
    {
        // List that contains data
        private static readonly List<OperationLog> _logs = new List<OperationLog>();

        // Default Values Length in order to check the existence of Default Values
        private const int DEFAULT_LENGTH = 3; 

        public WorkLogController()
        {
            if (_logs.Count < DEFAULT_LENGTH) // If Default Values aren't exist, then add
            {
                SetDefaultValues(); // Add Default Values
            }
        }
        // List Logs
        public IActionResult List()
        {
            return View(_logs.OrderBy(log => log.StartingTime).ToList());
        }

        // Create a new Log (Get method)
        public IActionResult Create()
        {
            return View("Create");
        }

        // Create a new Log (Post method)
        [HttpPost]
        public IActionResult Create(OperationLog newValues)
        {

            // Set Status based on the CheckBox value
            if (newValues.Status == "DURUŞ")
            {
                newValues.Status = "DURUŞ";
            }
            else
            {
                newValues.Status = "ÜRETİM";
            }

            // Add new log
            _logs.Add(newValues);

            return RedirectToAction("List");
        }

        // Sets all the default value (Break times)
        private void SetDefaultValues()
        {

            // Tea Break 1
            DateTime DefaultStartingTimeForTeaBreak1 = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 10, 0, 0);
            DateTime DefaultFinishingTimeForTeaBreak1 = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 10, 15, 0);
            string DefaultStatusForTeaBreak1 = "DURUŞ";
            string DefaultDetailsForTeaBreak1 = "Çay Molası";

            // Lunch Time
            DateTime DefaultStartingTimeForLunch = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 12, 0, 0);
            DateTime DefaultFinishingTimeForLunch = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 12, 30, 0);
            string DefaultStatusForLunch = "DURUŞ";
            string DefaultDetailsForLunch = "Yemek Molası";

            // Tea Break 2
            DateTime DefaultStartingTimeForTeaBreak2 = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 15, 0, 0);
            DateTime DefaultFinishingTimeForTeaBreak2 = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 15, 15, 0);
            string DefaultStatusForTeaBreak2 = "DURUŞ";
            string DefaultDetailsForTeaBreak2 = "Çay Molası";

            // Add Tea Break 1
            _logs.Add(new OperationLog
            {
                StartingTime = DefaultStartingTimeForTeaBreak1,
                FinishingTime = DefaultFinishingTimeForTeaBreak1,
                Status = DefaultStatusForTeaBreak1,
                Details = DefaultDetailsForTeaBreak1
            });

            // Add Lunch Time
            _logs.Add(new OperationLog
            {
                StartingTime = DefaultStartingTimeForLunch,
                FinishingTime = DefaultFinishingTimeForLunch,
                Status = DefaultStatusForLunch,
                Details = DefaultDetailsForLunch
            });

            // Add Tea Break 2
            _logs.Add(new OperationLog
            {
                StartingTime = DefaultStartingTimeForTeaBreak2,
                FinishingTime = DefaultFinishingTimeForTeaBreak2,
                Status = DefaultStatusForTeaBreak2,
                Details = DefaultDetailsForTeaBreak2
            });
        }
    }
}
