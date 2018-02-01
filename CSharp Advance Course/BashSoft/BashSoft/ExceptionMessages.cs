using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    class ExceptionMessages
    {
        public const string ExampleExceptionMessages = "Example message";

        public const string  InitializingData = "Data is already initialized";

        public const string DataNotInitializedExceptionMessage =
            "The data structure must be initialized first in order to make any operations with it.";

        public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";

        public const string InexistingStudentInDataBase = "The user name for the student you are trying to get does not exist!";
    }
}
