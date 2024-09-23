USE Emedicine;
Go

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Users FOREIGN KEY (UserId)
REFERENCES Users(ID);
-- Insert demo users into Users table
Use Emedicine
INSERT INTO Users (FirstName, LastName, Password, Email, Fund, Type, Status, CreatedOn)
VALUES 
('John', 'Doe', 'password123', 'john.doe@example.com', 500.00, 'Customer', 1, GETDATE()),
('Jane', 'Smith', 'password456', 'jane.smith@example.com', 300.00, 'Customer', 1, GETDATE()),
('Alice', 'Johnson', 'password789', 'alice.johnson@example.com', 1000.00, 'Customer', 1, GETDATE());

USE Emedicine;

INSERT INTO Orders (UserId, OrderNo, OrderTotal, OrderStatus)
VALUES 
(1, 1001, 150.00, 'Processing'), 
(2, 1002, 200.00, 'Shipped'),    
(3, 1003, 75.00, 'Delivered'),    
(1, 1004, 300.00, 'Processing'),  
(2, 1005, 500.00, 'Cancelled'); 


DELETE FROM Orders
WHERE ID = 3; 
select * From Users

use Emedicine;

select * from Orders;

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




