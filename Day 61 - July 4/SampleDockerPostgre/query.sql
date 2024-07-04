SELECT e.emp_name AS employee_name, e.age, e.phone, d.dept_name AS department_name, s.salary
FROM Employee e
JOIN Department d ON e.dept_id = d.dept_id
JOIN Salary s ON e.emp_id = s.emp_id;