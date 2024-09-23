
CREATE PROCEDURE DeleteUser
    @UserId INT
AS
BEGIN
    BEGIN TRY
        -- Attempt to delete the user
        DELETE FROM Users
        WHERE ID = @UserId;
        
        -- If the delete was successful
        PRINT 'User deleted successfully.';
    END TRY
    BEGIN CATCH
        -- Handle any errors, such as referential integrity violations
        PRINT 'Failed to delete user due to referential integrity.';
        PRINT ERROR_MESSAGE();  -- Show the specific error message
    END CATCH
END;

SELECT * 
FROM sys.procedures
WHERE name = 'DeleteUser';
select *from Users;



EXEC dbo.DeleteUser @UserId =1;
GO

USE Emedicine;
GO

SELECT 
    fk.name AS ForeignKeyName,
    tp.name AS ParentTable,
    cp.name AS ParentColumn,
    ref.name AS ReferencedTable,
    cr.name AS ReferencedColumn
FROM 
    sys.foreign_keys AS fk
INNER JOIN 
    sys.foreign_key_columns AS fkc
    ON fk.object_id = fkc.constraint_object_id
INNER JOIN 
    sys.tables AS tp
    ON fkc.parent_object_id = tp.object_id
INNER JOIN 
    sys.columns AS cp
    ON fkc.parent_object_id = cp.object_id
    AND fkc.parent_column_id = cp.column_id
INNER JOIN 
    sys.tables AS ref
    ON fkc.referenced_object_id = ref.object_id
INNER JOIN 
    sys.columns AS cr
    ON fkc.referenced_object_id = cr.object_id
    AND fkc.referenced_column_id = cr.column_id
WHERE 
    tp.name = 'Orders'  -- Child table
    AND ref.name = 'Users';  -- Parent table


USE Emedicine;
GO

-- Insert records into the Orders table
INSERT INTO [dbo].[Orders] ([UserId], [OrderNo], [OrderTotal], [OrderStatus])
VALUES 
(1002, 'ORD1001', 150.00, 'Processing'),
(1003, 'ORD1002', 200.00, 'Shipped'),
(1004, 'ORD1003', 75.00, 'Delivered');
GO



