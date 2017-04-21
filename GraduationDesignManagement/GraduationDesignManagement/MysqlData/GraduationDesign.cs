using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationDesignManagement.MysqlData
{
    public class GraduationDesign
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }

        public int FirstCheckScore { get; set; }
        public int FirstCheckTeacherId { get; set; }
        public int FirstCheckDateTime { get; set; }

        public int SecondCheckScore { get; set; }
        public int SecondCheckTeacherId { get; set; }
        public int SecondCheckDateTime { get; set; }

        public int ThirdCheckScore { get; set; }
        public int ThirdCheckTeacherId { get; set; }
        public int ThirdCheckDateTime { get; set; }

    }
}
