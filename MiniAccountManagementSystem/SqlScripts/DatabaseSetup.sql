/****** Create User Table ******/
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
Go


/****** Create Roles Table ******/
CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);
Go

/****** Insert RoleName into Roles Table ******/
INSERT INTO Roles (RoleName) VALUES ('Admin'), ('Accountant'), ('Viewer');


/****** Create UserRoles Table ******/
CREATE TABLE UserRoles (
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
    CONSTRAINT PK_UserRoles PRIMARY KEY (UserId, RoleId),
    CONSTRAINT FK_UserRoles_Users FOREIGN KEY (UserId) REFERENCES Users(UserId),
    CONSTRAINT FK_UserRoles_Roles FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);
Go
/****** Create Modules Table  ******/

CREATE TABLE Modules (
    ModuleId INT PRIMARY KEY IDENTITY,
    ModuleName NVARCHAR(100) NOT NULL
);
Go

/****** insert into Modules Table  ******/

INSERT INTO Modules (ModuleName)
VALUES 
('Dashboard'),
('User Management'),
('Role Management'),
('Module Access Control'),
('Accounts'),
('Transactions'),
('Reports');






/****** Create RoleModuleAccess Table  ******/

CREATE TABLE RoleModuleAccess (
    RoleId INT,
    ModuleId INT,
    CanView BIT DEFAULT 0,
    CanEdit BIT DEFAULT 0,
    PRIMARY KEY (RoleId, ModuleId),
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId),
    FOREIGN KEY (ModuleId) REFERENCES Modules(ModuleId)
);
Go



/****** Stored Procedure: Add a New Role ******/
CREATE PROCEDURE AddRole
    @RoleName NVARCHAR(100)
AS
BEGIN
    INSERT INTO Roles (RoleName)
    VALUES (@RoleName)
END;
GO


/****** Stored Procedure: Add a New User ******/
CREATE PROCEDURE AddUser
    @Username NVARCHAR(100),
    @PasswordHash NVARCHAR(255) -- This should be hashed
AS
BEGIN
    INSERT INTO Users (Username, PasswordHash)
    VALUES (@Username, @PasswordHash)
END;
GO


/****** Stored Procedure: Assign Role to User ******/

CREATE PROCEDURE AssignRoleToUser
    @UserId INT,
    @RoleId INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM UserRoles WHERE UserId = @UserId AND RoleId = @RoleId
    )
    BEGIN
        INSERT INTO UserRoles (UserId, RoleId)
        VALUES (@UserId, @RoleId)
    END
END
GO



/****** Stored Procedure: GetUsers ******/

CREATE PROCEDURE GetUsers
AS
BEGIN
    SELECT UserId, Username FROM Users
END
GO


/****** Stored Procedure: GetRoles ******/
CREATE PROCEDURE GetRoles
AS
BEGIN
    SELECT RoleId, RoleName FROM Roles
END
GO

/****** Stored Procedure: Assign Access Rights to Roles ******/
CREATE PROCEDURE AssignModuleAccessToRole
    @RoleId INT,
    @ModuleId INT,
    @CanView BIT,
    @CanEdit BIT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM RoleModuleAccess 
        WHERE RoleId = @RoleId AND ModuleId = @ModuleId
    )
    BEGIN
        -- Update existing permission
        UPDATE RoleModuleAccess
        SET CanView = @CanView, CanEdit = @CanEdit
        WHERE RoleId = @RoleId AND ModuleId = @ModuleId
    END
    ELSE
    BEGIN
        -- Insert new permission
        INSERT INTO RoleModuleAccess (RoleId, ModuleId, CanView, CanEdit)
        VALUES (@RoleId, @ModuleId, @CanView, @CanEdit)
    END
END
GO


/****** Stored Procedure: GetModules ******/
CREATE PROCEDURE GetModules
AS
BEGIN
    SELECT ModuleId, ModuleName
    FROM Modules
    ORDER BY ModuleName
END
GO









