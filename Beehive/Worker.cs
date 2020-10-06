using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beehive
{
    class Worker : Bee
    {
        private const double HONEY_UNITS_PER_SHIFT_WORKED = .65;

        private string currentJob = "";
        public string CurrentJob
        {
            get
            {
                return currentJob;
            }
        }

        public int ShiftsLeft
        {
            get
            {
                return shiftsToWork - shiftsWorked;
            }
        }

        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;

        public Worker(string[] jobsICanDo, double weightMg)
            : base(weightMg)
        {
            this.jobsICanDo = jobsICanDo;
        }

        public bool DoThisJob(string job, int numberOfShifts)
        {
            bool result = false;
            if (String.IsNullOrEmpty(currentJob) && jobsICanDo.Contains(job))
            {
                currentJob = jobsICanDo.FirstOrDefault(j => j.Contains(job));
                this.shiftsToWork = numberOfShifts;
                shiftsWorked = 0;
                result = true;
            }
            return result;
        }

        public bool DidYouFinish()
        {
            bool result = false;
            if (!String.IsNullOrEmpty(CurrentJob))
            {
                shiftsWorked++;
                if (shiftsWorked > shiftsToWork)
                {
                    shiftsWorked = 0;
                    shiftsToWork = 0;
                    currentJob = "";
                    result = true;
                }
            }
            return result;
        }

        public override double HoneyConsumptionRate()
        {
            return base.HoneyConsumptionRate() + shiftsWorked * HONEY_UNITS_PER_SHIFT_WORKED;
        }
    }
}
