
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/02/2025 23:36:39
-- Generated from EDMX file: C:\Users\ACER\source\repos\Nhan Xích Thành-Đồ án(BE)-LTW\Nhan Xích Thành-Đồ án(BE)-LTW\Models\TechPhoneModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TechPhone];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Customer_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK_Customer_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Import_Supplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImportReceipt] DROP CONSTRAINT [FK_Import_Supplier];
GO
IF OBJECT_ID(N'[dbo].[FK_ImportDetail_Import]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImportDetail] DROP CONSTRAINT [FK_ImportDetail_Import];
GO
IF OBJECT_ID(N'[dbo].[FK_ImportDetail_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImportDetail] DROP CONSTRAINT [FK_ImportDetail_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderDetail_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetail] DROP CONSTRAINT [FK_OrderDetail_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderDetail_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderDetail] DROP CONSTRAINT [FK_OrderDetail_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Brand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Brand];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_Category];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Brand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brand];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[ImportDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImportDetail];
GO
IF OBJECT_ID(N'[dbo].[ImportReceipt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImportReceipt];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[OrderDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderDetail];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Supplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Supplier];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Brands'
CREATE TABLE [dbo].[Brands] (
    [BrandID] int IDENTITY(1,1) NOT NULL,
    [BrandName] nvarchar(100)  NOT NULL,
    [Country] nvarchar(50)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(100)  NOT NULL,
    [Description] nvarchar(255)  NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerID] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(100)  NOT NULL,
    [Phone] nvarchar(15)  NOT NULL,
    [Email] nvarchar(100)  NULL,
    [Address] nvarchar(255)  NULL,
    [Username] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'ImportDetails'
CREATE TABLE [dbo].[ImportDetails] (
    [ImportDetailID] int IDENTITY(1,1) NOT NULL,
    [ImportID] int  NOT NULL,
    [ProductID] int  NOT NULL,
    [Quantity] int  NOT NULL,
    [UnitCost] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'ImportReceipts'
CREATE TABLE [dbo].[ImportReceipts] (
    [ImportID] int IDENTITY(1,1) NOT NULL,
    [SupplierID] int  NOT NULL,
    [ImportDate] datetime  NULL,
    [TotalCost] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [CustomerID] int  NOT NULL,
    [OrderDate] datetime  NOT NULL,
    [TotalAmount] decimal(18,2)  NOT NULL,
    [PaymentStatus] nvarchar(50)  NULL,
    [ShippingAddress] nvarchar(255)  NOT NULL,
    [DeliveryStatus] nvarchar(50)  NULL,
    [DeliveryMethod] nvarchar(100)  NULL,
    [PaymentMethod] nvarchar(100)  NULL
);
GO

-- Creating table 'OrderDetails'
CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailID] int IDENTITY(1,1) NOT NULL,
    [OrderID] int  NOT NULL,
    [ProductID] int  NOT NULL,
    [Quantity] int  NOT NULL,
    [UnitPrice] decimal(18,2)  NOT NULL,
    [TotalPrice] decimal(29,2)  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [CategoryID] int  NOT NULL,
    [BrandID] int  NOT NULL,
    [ProductName] nvarchar(150)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Price] decimal(18,2)  NOT NULL,
    [StockQuantity] int  NOT NULL,
    [ImageURL] nvarchar(max)  NULL,
    [WarrantyMonths] int  NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [SupplierID] int IDENTITY(1,1) NOT NULL,
    [SupplierName] nvarchar(100)  NOT NULL,
    [Phone] nvarchar(15)  NULL,
    [Email] nvarchar(100)  NULL,
    [Address] nvarchar(255)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Username] nvarchar(100)  NOT NULL,
    [Password] nvarchar(100)  NOT NULL,
    [UserRole] char(1)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BrandID] in table 'Brands'
ALTER TABLE [dbo].[Brands]
ADD CONSTRAINT [PK_Brands]
    PRIMARY KEY CLUSTERED ([BrandID] ASC);
GO

-- Creating primary key on [CategoryID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [CustomerID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [ImportDetailID] in table 'ImportDetails'
ALTER TABLE [dbo].[ImportDetails]
ADD CONSTRAINT [PK_ImportDetails]
    PRIMARY KEY CLUSTERED ([ImportDetailID] ASC);
GO

-- Creating primary key on [ImportID] in table 'ImportReceipts'
ALTER TABLE [dbo].[ImportReceipts]
ADD CONSTRAINT [PK_ImportReceipts]
    PRIMARY KEY CLUSTERED ([ImportID] ASC);
GO

-- Creating primary key on [OrderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [OrderDetailID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [PK_OrderDetails]
    PRIMARY KEY CLUSTERED ([OrderDetailID] ASC);
GO

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [SupplierID] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([SupplierID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Username] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Username] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BrandID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Brand]
    FOREIGN KEY ([BrandID])
    REFERENCES [dbo].[Brands]
        ([BrandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Brand'
CREATE INDEX [IX_FK_Product_Brand]
ON [dbo].[Products]
    ([BrandID]);
GO

-- Creating foreign key on [CategoryID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_Category]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_Category'
CREATE INDEX [IX_FK_Product_Category]
ON [dbo].[Products]
    ([CategoryID]);
GO

-- Creating foreign key on [Username] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_Customer_User]
    FOREIGN KEY ([Username])
    REFERENCES [dbo].[Users]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Customer_User'
CREATE INDEX [IX_FK_Customer_User]
ON [dbo].[Customers]
    ([Username]);
GO

-- Creating foreign key on [CustomerID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Order_Customer]
    FOREIGN KEY ([CustomerID])
    REFERENCES [dbo].[Customers]
        ([CustomerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Customer'
CREATE INDEX [IX_FK_Order_Customer]
ON [dbo].[Orders]
    ([CustomerID]);
GO

-- Creating foreign key on [ImportID] in table 'ImportDetails'
ALTER TABLE [dbo].[ImportDetails]
ADD CONSTRAINT [FK_ImportDetail_Import]
    FOREIGN KEY ([ImportID])
    REFERENCES [dbo].[ImportReceipts]
        ([ImportID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImportDetail_Import'
CREATE INDEX [IX_FK_ImportDetail_Import]
ON [dbo].[ImportDetails]
    ([ImportID]);
GO

-- Creating foreign key on [ProductID] in table 'ImportDetails'
ALTER TABLE [dbo].[ImportDetails]
ADD CONSTRAINT [FK_ImportDetail_Product]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImportDetail_Product'
CREATE INDEX [IX_FK_ImportDetail_Product]
ON [dbo].[ImportDetails]
    ([ProductID]);
GO

-- Creating foreign key on [SupplierID] in table 'ImportReceipts'
ALTER TABLE [dbo].[ImportReceipts]
ADD CONSTRAINT [FK_Import_Supplier]
    FOREIGN KEY ([SupplierID])
    REFERENCES [dbo].[Suppliers]
        ([SupplierID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Import_Supplier'
CREATE INDEX [IX_FK_Import_Supplier]
ON [dbo].[ImportReceipts]
    ([SupplierID]);
GO

-- Creating foreign key on [OrderID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK_OrderDetail_Order]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Orders]
        ([OrderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderDetail_Order'
CREATE INDEX [IX_FK_OrderDetail_Order]
ON [dbo].[OrderDetails]
    ([OrderID]);
GO

-- Creating foreign key on [ProductID] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK_OrderDetail_Product]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderDetail_Product'
CREATE INDEX [IX_FK_OrderDetail_Product]
ON [dbo].[OrderDetails]
    ([ProductID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------