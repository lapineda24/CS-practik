using System;
using System.Collections.Generic;

namespace YaP6
{
    class Program
    {
        class Person
        {
            private string Name { get; set; }
            private string Surname { get; set; }
            private DateTime Burndate { get; set; }

            public Person(string name, string surname)
            {
                Name = name;
                Surname = surname;
                Burndate = new DateTime(2020, 11, 23, 17, 54, 36);
            }

            public Person()
            {
                Name = "Вера";
                Surname = "Воробьева";
                Burndate = DateTime.Now;
            }

            public override string ToString()
            {
                return "Имя: " + Name + "\nФамилия: " + Surname + "\nДата рождения: " + Burndate + "\n";
            }

            public virtual string ToShortString()
            {
                return "Имя: " + Name + "\nФамилия: " + Surname + "\n";
            }
        }

        class Exam
        {
            public string Subject;
            public int Mark;
            DateTime ExamsDate;

            public Exam(string subject, int mark)
            {
                Subject = subject;
                Mark = mark;
                ExamsDate = new DateTime(2020, 10, 2, 12, 12, 12); 
            }

            public Exam()
            {
                Subject = "Языки программирования";
                Mark = 5;
                ExamsDate = DateTime.Now;
            }

            public override string ToString()
            {
                return "Предмет: " + Subject + "\nОценка: " + Mark + "\nДата проведения экзамена: " + ExamsDate + "\n";
            }
        }

        public enum Education
        {
            Specialist,
            Вachelor,
            SecondEducation
        }

        class Student
        {
            private Person person { get; set; }
            private Education education { get; set; }
            private int Group { get; set; }
            private List<Exam> exam { get; set; }

            public Student(string name, string surname, Education education1, int group, string subject, int mark)
            {
                person = new Person(name, surname);
                education= education1;
                Group = group;
                exam = new List<Exam>();
                exam.Add(new Exam(subject, mark));
            }

            public Student()
            {
                person = new Person();
                education = Education.Вachelor;
                Group = 5;
                exam = new List<Exam>();
                exam.Add(new Exam());
            }
            
            private double srmark
            {
                get
                {
                    double sr = 0;
                    for(int i = 0; i < exam.Count; i++)
                    {
                        sr = sr + exam[i].Mark; 
                    }
                    sr = sr / exam.Count;
                    return sr;
                }
            }

            public bool this[Education education1]
            {
                get
                {
                    return education == education1;
                }
            }
            public void AddExams(string subject, int mark)
            {
                exam.Add(new Exam(subject, mark));
            }

            public override string ToString()
            {
                string vera;
                vera = person.ToString() + "\nГруппа " + Group + "\n";
                for (int i = 0; i < exam.Count; i++)
                {
                    vera = vera + exam[i];
                }
                return vera;
            }

            public virtual string ToShortString()
            {
                
                return person + "\nГруппа " + Group + "\nСредний балл: " + srmark + "\n";
            }
        }
        static void Main()
        {
            Student student = new Student();
            Console.WriteLine(student.ToShortString());

            Console.WriteLine($"Значение индексатора для Education.Specialist: {student[Education.Вachelor]} \nдля Education.Bachelor: {student[Education.Specialist]} \nдля Education.SecondEducation: {student[Education.SecondEducation]}\n");

            Student student1 = new Student("Иван", "Иванов", Education.SecondEducation, 8, "Теория вероятности", 4);
            Console.WriteLine(student1.ToString());

            student.AddExams("Алгебра логики", 4);
            Console.WriteLine(student.ToString());
        }
    }
}
