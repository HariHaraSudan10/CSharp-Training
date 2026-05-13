use Employeemanagement;

--creating stored procedure to update salary of the given employee id 
CREATE PROCEDURE sp_updateSalbyID(@empno INT)
AS
BEGIN
	UPDATE Employee_Details SET Empsal = Empsal + 100 
	WHERE Empno = @empno;

END;


