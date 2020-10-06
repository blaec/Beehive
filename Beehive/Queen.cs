using System;
using System.Collections.Generic;
using System.Text;

namespace Beehive
{
    class Queen
    {
        private Worker[] workers;

        private int shiftNumber = 0;

        private const string NEW_LINE = "\r\n";

        public Queen(Worker[] workers)
        {
            this.workers = workers;
        }

        public bool AssignWork(string job, int numberOfShifts)
        {
            bool result = false;
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DoThisJob(job, numberOfShifts))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public string WorkTheNextShift()
        {
            shiftNumber++;
            string report = $"Report for shift #{shiftNumber}{NEW_LINE}";
            for (int i = 0; i < workers.Length; i++)
            {
                string worker = $"Worker #{i + 1}";
                if (workers[i].DidYouFinish())
                {
                    report += $"{worker} finished the job{NEW_LINE}";
                }

                string currentJob = workers[i].CurrentJob;
                report += String.IsNullOrEmpty(currentJob)
                    ? $"{worker} is not working{NEW_LINE}"
                    : workers[i].ShiftsLeft > 0
                        ? $"{worker} is doing `{currentJob}` for {workers[i].ShiftsLeft} more shifts{NEW_LINE}"
                        : $"{worker} will be done with `{currentJob}` after this shift{NEW_LINE}";
            }
            return report;
        }
    }
}
