using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using VegamTask.ViewModels;

namespace VegamTask.Models
{
    public class StudentDAL
    {
        //StudentDetailsdbContext db = new StudentDetailsdbContext();

        public StudentDAL(StudentDetailsdbContext context)
        {
            _context = context;
        }

        private StudentDetailsdbContext _context { get; }

        public IEnumerable<Student> getAllStudents()
        {
            return _context.Students.ToList();
        }

        public IEnumerable<FakeModel> getStudentsWithIndividualSubjectMarks(Boolean sortTable = false, Boolean showStatus = false, Boolean addGrace = false)
        {
            List<FakeModel> list = new List<FakeModel>();
            FakeModel obj = new FakeModel();
            var allStudents = getAllStudents();

            //var query = allstudents
            //    .groupby(s => s.fstudentname)
            //    .select(g => new
            //    {
            //        studentname = g.key,
            //        ec1 = g.where(s => s.fsubject == "ec1").select(s => s.fmarks),
            //        ec2 = g.where(s => s.fsubject == "ec2").select(s => s.fmarks),
            //        ec3 = g.where(s => s.fsubject == "ec3").select(s => s.fmarks),
            //        ec4 = g.where(s => s.fsubject == "ec4").select(s => s.fmarks),
            //        ec5 = g.where(s => s.fsubject == "ec5").select(s => s.fmarks)
            //    });
            Console.WriteLine("**********************", allStudents);

            foreach (var q in allStudents)
            {
                if(q.Fsubject == "EC1")
                {
                    obj = new FakeModel();
                    obj.studentName = q.FstudentName;
                    obj.EC1 = q.Fmarks;
                    obj.Total = obj.EC1;
                    if (q.Fmarks < 30)
                    {
                        obj.Status = "Fail";
                        obj.TotalFailedSubjects += 1;
                    }
                    else
                    {
                        obj.Status = "Pass";
                    }
                }
                if (q.Fsubject == "EC2")
                {
                    obj.EC2 = q.Fmarks;
                    obj.Total += obj.EC2;
                    if (q.Fmarks < 30)
                    {
                        obj.Status = "Fail";
                        obj.TotalFailedSubjects += 1;
                    }
                }
                if (q.Fsubject == "EC3")
                {
                    obj.EC3 = q.Fmarks;
                    obj.Total += obj.EC3;
                    if (q.Fmarks < 30)
                    {
                        obj.Status = "Fail";
                        obj.TotalFailedSubjects += 1;
                    }
                }
                if (q.Fsubject == "EC4")
                {
                    obj.EC4 = q.Fmarks;
                    obj.Total += obj.EC4;
                    if (q.Fmarks < 30)
                    {
                        obj.Status = "Fail";
                        obj.TotalFailedSubjects += 1;
                    }
                }
                if (q.Fsubject == "EC5")
                {
                    obj.EC5 = q.Fmarks;
                    obj.Total += obj.EC5;
                    if (q.Fmarks < 30)
                    {
                        obj.Status = "Fail";
                        obj.TotalFailedSubjects += 1;
                    }
                    list.Add(obj);
                } 
            }
            if (sortTable)
            {
                return list.OrderByDescending(q => q.Total);
            }
            if (addGrace)
            {
                return Grace();
            }
            return list;
        }

        public IEnumerable<FakeModel> Grace()
        {
            IEnumerable<FakeModel> newModel = getStudentsWithIndividualSubjectMarks(false, true);

            foreach (var stu in newModel)
            {
                if(stu.TotalFailedSubjects <= 2 && stu.TotalFailedSubjects > 0)
                {
                    var totalGraceNeeded = 6;
                    if (stu.EC1 < 30)
                    {
                        var diff = 30 - stu.EC1; 
                        if (diff < totalGraceNeeded) 
                        {
                            totalGraceNeeded -= (int)diff;
                            stu.EC1 = 30;
                            stu.Status = "Pass";
                        }
                    }
                    if (stu.EC2 < 30)
                    {
                        var diff = 30 - stu.EC2;
                        if (diff < totalGraceNeeded)
                        {
                            totalGraceNeeded -= (int)diff;
                            stu.EC2 = 30;
                            stu.Status = "Pass";
                        }
                    }
                    if (stu.EC3 < 30)
                    {
                        var diff = 30 - stu.EC2;
                        if (diff < totalGraceNeeded)
                        {
                            totalGraceNeeded -= (int)diff;
                            stu.EC3 = 30;
                            stu.Status = "Pass";
                        }
                    }
                    if (stu.EC4 < 30)
                    {
                        var diff = 30 - stu.EC2;
                        if (diff < totalGraceNeeded)
                        {
                            totalGraceNeeded -= (int)diff;
                            stu.EC4 = 30;
                            stu.Status = "Pass";
                        }
                    }
                    if (stu.EC5 < 30)
                    {
                        var diff = 30 - stu.EC2;
                        if (diff < totalGraceNeeded)
                        {
                            totalGraceNeeded -= (int)diff;
                            stu.EC5 = 30;
                            stu.Status = "Pass";
                        }
                    }
                }
            }
            return newModel;
        }
    }
}
