﻿using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Student student Data
    /// </summary>
    public class Student_Service : IStudent_Service
    {
        //Reference to our crud functions
        private IStudent_Operations _student_operations = new Student_Operations();

        /// <summary>
        /// Obtains all the Student studentes that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<EnrolledClass_ResultSet>>> GetAllStudents()
        {
            Generic_ResultSet<List<EnrolledClass_ResultSet>> result = new Generic_ResultSet<List<EnrolledClass_ResultSet>>();
            try
            {
                //GET ALL Student studentES
                List<Student> Studentes = await _student_operations.ReadAll();
                //MAP DB Student RESULTS
                result.result_set = new List<EnrolledClass_ResultSet>();
                Studentes.ForEach(s =>
                {
                    result.result_set.Add(new EnrolledClass_ResultSet
                    {
                        student_id = s.StudentID,
                        name = s.Student_Name,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Student studentes obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Student_Service: GetAllStudents() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Student studentes from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Student_Service: GetAllStudents(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<EnrolledClass_ResultSet>> GetStudentById(long id)
        {
            Generic_ResultSet<EnrolledClass_ResultSet> result = new Generic_ResultSet<EnrolledClass_ResultSet>();
            try
            {
                //GET by ID Student 
                var Student = await _student_operations.Read(id);

                //MAP DB Student RESULTS
                result.result_set = new EnrolledClass_ResultSet
                {
                    name = Student.Student_Name,
                    student_id = Student.StudentID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Student  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Student_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Student  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Student_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new student to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<EnrolledClass_ResultSet>> AddStudent(string name)
        {
            Generic_ResultSet<EnrolledClass_ResultSet> result = new Generic_ResultSet<EnrolledClass_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Student
                Student Student = new Student
                {
                    Student_Name = name
                };

                //ADD Student TO DB
                Student = await _student_operations.Create(Student);

                //MANUAL MAPPING OF RETURNED Student VALUES TO OUR Student_ResultSet
                EnrolledClass_ResultSet studentAdded = new EnrolledClass_ResultSet
                {
                    name = Student.Student_Name,
                    student_id = Student.StudentID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Student student {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Student_Service: AddStudent() method executed successfully.";
                result.result_set = studentAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Student student supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Student_Service: AddStudent(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Student students name.
        /// </summary>
        /// <param name="student_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<EnrolledClass_ResultSet>> UpdateStudent(Int64 student_id, string name)
        {
            Generic_ResultSet<EnrolledClass_ResultSet> result = new Generic_ResultSet<EnrolledClass_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Student
                Student Student = new Student
                {
                    StudentID = student_id,
                    Student_Name = name,
                    //Student_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Student IN DB
                Student = await _student_operations.Update(Student, student_id);

                //MANUAL MAPPING OF RETURNED Student VALUES TO OUR Student_ResultSet
                EnrolledClass_ResultSet studentUpdated = new EnrolledClass_ResultSet
                {
                    name = Student.Student_Name,
                    student_id = Student.StudentID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Student student {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Student_Service: UpdateStudent() method executed successfully.";
                result.result_set = studentUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Student student supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Student_Service: UpdateStudent(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteStudent(long student_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {               
                //delete Student IN DB
                var studentDeleted= await _student_operations.Delete(student_id);
                
                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Student student {0} was deleted successfully", student_id);
                result.internalMessage = "LOGIC.Services.Implementation.Student_Service: DeleteStudent() method executed successfully.";
                result.result_set = studentDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Student student supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Student_Service: DeleteStudent(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
