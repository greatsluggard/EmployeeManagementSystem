CREATE TABLE "Department"
(
    "DepartmentId" BIGSERIAL PRIMARY KEY,
    "DepartmentName" VARCHAR(100) NOT NULL
);

CREATE TABLE "Employee"
(
    "EmployeeId" BIGSERIAL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL,
    "LastName" VARCHAR(100) NOT NULL,
    "DepartmentId" BIGINT NOT NULL,
    FOREIGN KEY ("DepartmentId") REFERENCES "Department" ("DepartmentId") ON DELETE CASCADE
);