using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMachineSimulator
{
	class AttendanceMachineSimulator
	{
        private readonly RestClientHelper _clientHelper;

        public AttendanceMachineSimulator(string baseUrl)
        {
            _clientHelper = new RestClientHelper(baseUrl);
        }

        public async Task CheckIn(string employeeId)
        {
            var response = await _clientHelper.PostAsync("/attendance/checkin", new { EmployeeId = employeeId, Timestamp = DateTime.UtcNow });
            if (response.IsSuccessful)
            {
                Console.WriteLine("Check-in successful");
            }
            else
            {
                Console.WriteLine("Check-in failed: " + response.ErrorMessage);
            }
        }

        public async Task CheckOut(string employeeId)
        {
            var response = await _clientHelper.PostAsync("/attendance/checkout", new { EmployeeId = employeeId, Timestamp = DateTime.UtcNow });
            if (response.IsSuccessful)
            {
                Console.WriteLine("Check-out successful");
            }
            else
            {
                Console.WriteLine("Check-out failed: " + response.ErrorMessage);
            }
        }
    }
}
