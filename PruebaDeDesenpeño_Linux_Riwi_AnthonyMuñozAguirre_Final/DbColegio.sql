-- Active: 1717624963824@@bn1sqd1ceofcgqxs5fch-mysql.services.clever-cloud.com@3306
CREATE TABLE Students(
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(125),
    BirthDate DATE,
    Address VARCHAR(125),
    Email VARCHAR(125)
);

CREATE TABLE Teachers(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(125),
    Speciality VARCHAR(125),
    Phone VARCHAR(25),
    Email VARCHAR(125),
    YearsExperience INTEGER
);

CREATE TABLE Courses(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125),
    Description TEXT,
    TeacherId INTEGER,
    Schedule VARCHAR(125),
    Duration VARCHAR(125),
    Capacity INTEGER,
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
);

CREATE TABLE Enrollments(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Date DATE,
    StudentId INTEGER,
    CourseId INTEGER,
    FOREIGN KEY (StudentId) REFERENCES Students(Id),
    FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

INSERT INTO Students (Names, BirthDate, Address, Email) VALUES 
('Juan Perez', '2000-01-01', 'Calle 123', 'juan@gmail.com'),
('Maria Lopez', '2001-02-02', 'Calle 456', 'maria@gmail.com');

INSERT INTO Teachers (Names, Speciality, Phone, Email, YearsExperience) VALUES 
('Pedro Rodriguez', 'Matematicas', '1123123517', 'pedro@gmail.com', 5),
('Ana Martinez', 'Fisica', '111241123518', 'ana@gmail.com', 10);

INSERT INTO Courses (Name, Description, TeacherId, Schedule, Duration, Capacity) VALUES 
('Matematicas I', 'Curso de matematicas nivel basico', 1, 'Lunes y Miercoles 8:00-10:00', '3 meses', 20),
('Fisica I', 'Curso de fisica nivel basico', 2, 'Martes y Jueves 8:00-10:00', '3 meses', 20);

INSERT INTO Enrollments (Date, StudentId, CourseId) VALUES
 ('2021-01-01', 1, 1),
 ('2021-01-01', 2, 2);